import re
# mul\((\d+),(\d+)\)
with open("input/part1.txt","r", encoding="utf-8") as f:
    ret = 0
    lines = f.readlines()

    for line in lines:
        multiMatches = re.finditer(r'mul\((\d+),(\d+)\)', line)
        for match in matches:
            print(match)
            ret += int(match.group(1)) * int(match.group(2))
    print(ret)