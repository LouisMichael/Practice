import re
import sys
from collections import defaultdict
from functools import cache

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

grid = []
# directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
directions = [(1,0),(0,1),(-1,0),(0,-1)]

def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True

with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        grid.append(list(line))

def scoreTrail(row,col):
    if grid[row][col] == '9':
        return 1
    total = 0
    for direction in directions:
        newRow = row+direction[0]
        newCol = col+direction[1]
        if inBounds(newRow,newCol) and grid[newRow][newCol] != '.' and int(grid[row][col]) == int(grid[newRow][newCol])-1:
            print(f'moving from {grid[row][col]} to {grid[newRow][newCol]}')
            total+=scoreTrail(newRow,newCol)
    # print(f'row {row} col{col} total {total}')
    return total

for i, row in enumerate(grid):
    for j, col in enumerate(grid):
        if grid[i][j] == '0':
            ret += scoreTrail(i,j)

print(ret)
