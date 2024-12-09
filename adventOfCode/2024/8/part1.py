import re
import sys
from collections import defaultdict
from functools import cache

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

grid = []
directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
# directions = [(1,0),(0,1),(-1,0),(0,-1)]

rowLength = 0
colLength = 0
def inBounds(x,y):
    if x<0 or x >= colLength or y < 0 or y >= rowLength:
        return False
    return True

antenaLists = defaultdict(lambda:[])


setOfIntersection = set()
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    rowLength = len(lines)
    colLength = len(lines[0].strip())
    for line in lines:
        line = line.strip()
        grid.append(list(line))
for row in grid:
    print(''.join(row))
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for row, line in enumerate(lines):
        line = line.strip()
        for col, char in enumerate(line):
            if char != '.':
                for other in antenaLists[char]:
                    dx = col - other[0]
                    dy = row - other[1]
                    lowerPoint = (col + dx, row + dy)
                    print(lowerPoint)
                    if inBounds(lowerPoint[0],lowerPoint[1]):
                        setOfIntersection.add(lowerPoint)
                        grid[lowerPoint[1]][lowerPoint[0]] = '#'
                    upperPoint = (other[0]-dx,other[1]-dy)
                    print(upperPoint)
                    if inBounds(upperPoint[0],upperPoint[1]):
                        setOfIntersection.add(upperPoint)
                        grid[upperPoint[1]][upperPoint[0]] = '#'
                antenaLists[char].append((col,row))
print(len(setOfIntersection))
for row in grid:
    print(''.join(row))
