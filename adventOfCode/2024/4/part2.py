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
directions = []
for x in range(len(grid)):
    for y in range(len(grid[x])):
        if grid[x][y] == 'A':
            if inBounds(x+1,y+1) and inBounds(x-1,y-1) and inBounds(x-1,y+1)and inBounds(x+1,y-1):
                if(( grid[x+1][y+1] == 'M' and grid[x-1][y-1] =='S' ) or ( grid[x+1][y+1] == 'S' and grid[x-1][y-1] =='M' )) and (( grid[x+1][y-1] == 'M' and grid[x-1][y+1] =='S' ) or ( grid[x+1][y-1] == 'S' and grid[x-1][y+1] =='M' )):
                    ret +=1
print(ret)
