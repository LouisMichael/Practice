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
            newX = x + direction[0]
            newY = y + direction[1]
            newX2 = x + direction[0]+direction[0]
            newY2 = y + direction[1]+ direction[1]
            newX3 = x + direction[0]+direction[0]+direction[0]
            newY3 = y + direction[1]+ direction[1]+direction[1]
            if inBounds(x,y) and inBounds(newX,newY) and inBounds(newX2,newY2) and inBounds(newX3,newY3):
                if grid[x][y]+grid[newX][newY]+grid[newX2][newY2]+grid[newX3][newY3] == "XMAS":
                    ret+=1
print(ret)
