import re
import sys
from collections import defaultdict
from functools import cache
import heapq

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

grid = []
directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
# directions = [(1,0),(0,1),(-1,0),(0,-1)]

def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True

with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        grid.append(list(line))
lastRound = -1
while lastRound != 0:
    round = 0
    for i in range(len(grid)):
        for j in range(len(grid[i])):
            count = 0
            if grid[i][j] == '@':
                count = 0
                for direction in directions:
                    x = i + direction[0]
                    y = j + direction[1]
                    if inBounds(x, y) and grid[x][y] == '@':
                        count += 1
                if count < 4:
                    grid[i][j] = '#'
                    round += 1
    ret += round
    lastRound = round
    # print(lastRound)
    # print(ret)
print(ret)
