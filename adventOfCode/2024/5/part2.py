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
        seen.add(val)
    if not valid:
        print(f'sorting {checkLine}')
        print(f'seen{seen}')
        # I think we try to write top sort by making a graph
        # first we have to get lists of only real dependcies
        dependcieRemaining = {}
        dependcieOf = {}
        for val in checkLine:
            if val in rules:
                for mustAfter in rules[val]:
                    if mustAfter in seen:
                        print(f'val{val} mustAfter{mustAfter} seen {seen}')
                        if mustAfter in dependcieOf:
                            dependcieOf[mustAfter]+=1
                        else:
                            dependcieOf[mustAfter] = 1
                        
        print(f'dependcieRemaining {dependcieRemaining}')
        print(f'dependcieOf {dependcieOf}')
        for val in dependcieOf:
            if dependcieOf[val] == len(checkLine)//2:
                print(f'adding {val}')
                ret += int(val)

# for x in range(len(grid)):
#     for y in range(len(grid[x])):
#         for direction in directions:
print(ret)
