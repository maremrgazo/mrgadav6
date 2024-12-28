import re, json, os


def _(filename):
    """
    Parse all DATA_BLOCK "BlockName" ... END_DATA_BLOCK sections
    from the given file, returning a dictionary mapping
    block_name -> block_contents (as a list of lines).
    """
    blocks = {}
    current_block_name = None
    current_lines = []

    block_start_pattern = re.compile(r'^DATA_BLOCK\s*"([^"]+)"')

    with open(filename, "r") as f:
        for line in f:
            line_stripped = line.rstrip("\n")

            # Check if the line starts a new data block
            start_match = block_start_pattern.match(line_stripped)
            if start_match:
                # If we were in a previous block, store it
                if current_block_name is not None and current_lines:
                    blocks[current_block_name] = current_lines

                current_block_name = start_match.group(1)
                current_lines = []
                continue

            # Check if the line ends the current data block
            if line_stripped.startswith("END_DATA_BLOCK"):
                if current_block_name is not None and current_lines:
                    blocks[current_block_name] = current_lines
                current_block_name = None
                current_lines = []
                continue

            # If we're inside a block, accumulate the lines
            if current_block_name is not None:
                current_lines.append(line_stripped)

    blocks_json = json.dumps(blocks, indent=4)

    output_json_file = os.path.join(
        os.path.join(__file__, ".."), "intermediary", "DATA_BLOCK_to_json.json"
    )
    with open(output_json_file, "w") as out_f:
        out_f.write(blocks_json)

    print(f"\nSaved to {output_json_file}")
