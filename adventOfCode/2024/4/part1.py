ret = 0

import re
import sys
grid = []

with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        grid.append(list(line))
def inBounds(x,y):
    if x<0 or x >= len(grid) or y < 0 or y >= len(grid[x]):
        return False
    return True
directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
for x in range(len(grid)):
    for y in range(len(grid[x])):
        for direction in directions:
            testString = ""
            for i in range(len("XMAS")):
                curX = x + (direction[0]*i)
                curY = y + (direction[1]*i)
                if inBounds(curX,curY):
                    testString+=grid[curX][curY]
                else:
                    break
            if testString == "XMAS":
                ret+=1
print(ret)
