import re
# mul\((\d+),(\d+)\)
with open("input/part1.txt","r", encoding="utf-8") as f:
    lines = f.readlines()

    ret = 0
    text = ""
    for line in lines:
        text += line
    matches = re.finditer(r'mul\((\d+),(\d+)\)', text)
    doIndexs = list(re.finditer(r'do\(\)', text))
    dontIndexs = list(re.finditer(r'don\'t\(\)', text))
    doCurIndex = 0
    dontCurIndex = 0
    print(dontIndexs)
    for i,match in enumerate(matches):
        while doCurIndex < len(doIndexs) and doIndexs[doCurIndex].span()[0] < match.span()[0]:
            doCurIndex+=1
        while dontCurIndex < len(dontIndexs) and dontIndexs[dontCurIndex].span()[0] < match.span()[0]:
            dontCurIndex+=1
        print(f'doCurIndex {doCurIndex} dontCurIndex {dontCurIndex} dontIndexs[dontCurIndex-1].span()[0] {dontIndexs[dontCurIndex-1].span()[0]}')
        if dontCurIndex == 0 or (doIndexs[doCurIndex-1].span()[0] > dontIndexs[dontCurIndex-1].span()[0] and doCurIndex != 0):
            ret += int(match.group(1)) * int(match.group(2))
    print(ret)