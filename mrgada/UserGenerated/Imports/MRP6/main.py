import re
import json
import os
from mrgada import DATA_BLOCK_to_json


def tia_to_mrgada(input):
    tia_to_mrgada_dict = {"Int": "Int16", "Bool": "bool", "Word": "Int16"}
    try:
        output = tia_to_mrgada_dict[input]
    except:
        output = "Int64"

    return output


dot_db_path = (
    r"C:\Users\lazar\Desktop\mrgadav6\mrgada\UserGenerated\Imports\MRP6\test.db"
)

DATA_BLOCK_to_json._(dot_db_path)

# region find text from STRUCT to END_STRUCT

input_path = r"C:\Users\lazar\Desktop\mrgadav6\mrgada\UserGenerated\Imports\MRP6\mrgada\intermediary\DATA_BLOCK_to_json.json"
output_path = r"C:\Users\lazar\Desktop\mrgadav6\mrgada\UserGenerated\Imports\MRP6\mrgada\intermediary\STRUCT.json"

with open(input_path, "r") as file:
    json_data = json.load(file)

STRUCTS = {}
for DATA_BLOCK_name in json_data:
    STRUCT_start_index = len(json_data[DATA_BLOCK_name])
    STRUCT_end_index = len(json_data[DATA_BLOCK_name])
    i = 0
    STRUCTS[DATA_BLOCK_name] = []
    for line in json_data[DATA_BLOCK_name]:
        if "STRUCT" in line:
            STRUCT_start_index = i
        if "END_STRUCT" in line:
            STRUCT_end_index = i
        if i > STRUCT_start_index and i < STRUCT_end_index:
            STRUCTS[DATA_BLOCK_name].append(line)
        i += 1

blocks_json = json.dumps(STRUCTS, indent=4)
with open(output_path, "w") as out_f:
    out_f.write(blocks_json)

# endregion

input_path = r"C:\Users\lazar\Desktop\mrgadav6\mrgada\UserGenerated\Imports\MRP6\mrgada\intermediary\STRUCT.json"
output_path = r"C:\Users\lazar\Desktop\mrgadav6\mrgada\UserGenerated\Imports\MRP6\mrgada\intermediary\db.json"

pattern = re.compile(
    r"""
    ^\s*                               # Start of line, optional whitespace
    (?P<name>[A-Za-z_]\w*)            # 1) Capture the variable name (allow underscore)
    \s*:\s*                            #    Colon, optional spaces
    (?:                                #    BEGIN: Non-capturing group for either array-decl or single type
       Array\[
         (?P<arraystartindex>\d+)
         \.\.
         (?P<arrayendindex>\d+)
       \]                              #    e.g. Array[1..150]
       \s+of\s+
       (?P<type>[A-Za-z_]\w*)         # 2) The type when it's an array (e.g. "Int", "TUser", etc.)
       |
       (?P<type_noarray>[A-Za-z_]\w*) # 3) The type when it's NOT an array
    )
    \s*;?                              # Optional spaces, optional semicolon at the end
    \s*$                               # End of line
    """,
    re.VERBOSE | re.IGNORECASE,
)


def parse_declaration(declaration: str):
    """
    Parses a declaration string (e.g. "VarName : Array[1..10] of MyType;")
    and returns a dict with keys:
       - name
       - isarray (True or False)
       - arraystartindex (if isarray=True)
       - arrayendindex   (if isarray=True)
       - type
    """
    match = pattern.match(declaration)
    if not match:
        return None

    name = match.group("name")

    # If type_noarray is present => isarray = False; otherwise True
    type_noarray = match.group("type_noarray")
    if type_noarray:
        # Means we do NOT have "Array[...] of ..."
        return {
            "name": name,
            "isarray": False,
            "arraystartindex": None,
            "arrayendindex": None,
            "type": type_noarray,
        }
    else:
        # Means we do have an array
        arraystartindex = match.group("arraystartindex")
        arrayendindex = match.group("arrayendindex")
        the_type = match.group("type")
        return {
            "name": name,
            "isarray": True,
            "arraystartindex": arraystartindex,
            "arrayendindex": arrayendindex,
            "type": the_type,
        }


with open(input_path, "r") as file:
    json_data = json.load(file)

db_json = {}
for DATA_BLOCK_name in json_data:
    db_json[DATA_BLOCK_name] = []
    for line in json_data[DATA_BLOCK_name]:
        db_json[DATA_BLOCK_name].append(parse_declaration(line.replace('"', "")))

blocks_json = json.dumps(db_json, indent=4)
with open(output_path, "w") as out_f:
    out_f.write(blocks_json)

# create  c# files


input_path = r"C:\Users\lazar\Desktop\mrgadav6\mrgada\UserGenerated\Imports\MRP6\mrgada\intermediary\db.json"
output_dir = r"C:\Users\lazar\Desktop\mrgadav6\mrgada\UserGenerated\Imports\MRP6\dbs"

with open(input_path, "r") as file:
    json_data = json.load(file)

project_name = "MRP6"

out = ""
for db_name in json_data:
    out = f"""
    
using static mrgada.S7Collector;
using System;
using System.Collections.Generic;

public static partial class mrgada
{"{"}
    public partial class _{project_name}
    {"{"}
        public class c_{db_name}: mrgada.S7Db
        {"{"}
            #region public vars
            
"""
    for var in json_data[db_name]:
        out += f"""                public List<S7Var<{tia_to_mrgada(var["type"])}>> {var["name"]} = new({int(var["arraystartindex"])+int(var["arrayendindex"])});\n"""

    out += f"""
        #endregion

                private mrgada.S7ClientCollector _s7CollectorClient;
                private S7.Net.Plc _s7Plc;
                public c_{db_name}(int num, int len, mrgada.S7ClientCollector s7CollectorClient, S7.Net.Plc s7Plc) : base(num, len)
                {"{"}
                    _s7CollectorClient = s7CollectorClient;
                    _s7Plc = s7Plc;

                    #region init vars
                    int i = 0;
    """

    for var in json_data[db_name]:
        out += f"""
                    for (i = 0; i <= {var["arrayendindex"]}; i++) {"{"}
                        {var["name"]}.Insert(i, new(this, s7CollectorClient, s7Plc));
                    {"}"}
        """

    out += """
            #endregion
                    AlignAndIncrement();
                }
                
                public void AlignAndIncrement()
                {
                    int bitOffset = 0;
                    int i = 0;
            """
    for var in json_data[db_name]:
        out += f"""
                    bitOffset = NearestDivisible((int)Math.Round(((float)bitOffset / 8.0f)), Math.Max(sizeof({tia_to_mrgada(var["type"])}), 2)) * 8; // align bit offset because it is start of array
                    for (i = {var["arraystartindex"]}; i <= {var["arrayendindex"]}; i++) {"{"}
                        bitOffset = {var["name"]}[i].AlignAndIncrement(bitOffset);
                    {"}"}
        """

    out += """
            }

            public override void ParseCVs()
            {
                int i = 0;
                """

    for var in json_data[db_name]:
        out += f"""
                    for (i = {var["arraystartindex"]}; i <= {var["arrayendindex"]}; i++) {"{"}
                        {var["name"]}[i].ParseCVs();
                    {"}"}
        """
    out += """
                }
        }
    }
}
    """

    with open(os.path.join(output_dir, f"c_{db_name}.cs"), "w") as out_f:
        out_f.write(out)
