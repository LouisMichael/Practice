ret = 0

import re
import sys
grid = []
directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
# directions = [(1,0),(0,1),(-1,0),(0,-1)]

def inBounds(x,y):
    if x<0 or x >= len(grid) or y < 0 or y >= len(grid[x]):
        return False
    return True
rules = {}
checkLines = []
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        if ',' in line:
            checkLines.append(line.split(','))
        if '|' in line:
            rule = line.split('|')

            if rule[0] in rules:
                rules[rule[0]].append(rule[1])
            else:
                rules[rule[0]] = [rule[1]]
print(rules)
print(checkLines)
for checkLine in checkLines:
    valid = True
    listOfPos = {}
    seen = set()
    for i,val in enumerate(checkLine):
        if val in rules:
            for cantBefore in rules[val]:
                if cantBefore in seen:
                    print(checkLine)
                    valid = False
                    break
            if not valid:
                break
        seen.add(val)
    if valid:
        print(f'adding {checkLine}')
        add = int(checkLine[(len(checkLine)//2) ])
        print(add)
        ret += add

# for x in range(len(grid)):
#     for y in range(len(grid[x])):
#         for direction in directions:
print(ret)
