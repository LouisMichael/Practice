import re
import sys
from collections import defaultdict

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

grid = []
# directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
directions = [(-1,0),(0,1),(1,0),(0,-1)]

def inBounds(x,y):
    if x<0 or x >= len(grid) or y < 0 or y >= len(grid[x]):
        return False
    return True
curX = 0
curY = 0
curDirection = 0
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for i, line in enumerate(lines):
        line = line.strip()
        if '^' in line:
            startY = line.index('^')
            startX = i
        grid.append(list(line))
for x in range(len(grid)):
    for y in range(len(grid[x])):
        if grid[x][y] == '.':
            grid[x][y] = '#'
        else:
            continue
        valid = False
        visited = set()
        curX = startX
        curY = startY
        curDirection = 0
        while inBounds(curX,curY):
            # print(f'cur ({curX}, {curY})')
            if (curX,curY,curDirection) in visited:
                valid = True
                break
            visited.add((curX,curY,curDirection))
            newX = directions[curDirection][0] + curX
            newY = directions[curDirection][1] + curY
            if inBounds(newX,newY) and grid[newX][newY] == '#':
                curDirection = (curDirection + 1)%4
            else:
                curX = newX
                curY = newY
        if valid:
            ret+=1
        grid[x][y] = '.'
print(ret)
