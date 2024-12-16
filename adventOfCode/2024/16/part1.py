import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq 

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
# we are going to run djkstra, our state is going to be (currentCost,row, col, direction)
# direciton will match with the directions list
priorityQ = []
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for i,line in enumerate(lines):
        line = line.strip()
        if 'S' in line:
            priorityQ.append((0,i,line.index('S'),0))
        grid.append(list(line))
visited = set()
while len(priorityQ)>0:
    cur = heapq.heappop(priorityQ)
    curRow = cur[1]
    curCol = cur[2]
    curDirection = cur[3]
    if grid[curRow][curCol] == 'E':
        ret = cur[0]
        break
    visitedKey = (curRow,curCol,curDirection)
    if visitedKey in visited:
        continue
    visited.add(visitedKey)
    for directionOffset in range(4):
        directionIndex = (directionOffset + curDirection)%4
        direction = directions[directionIndex]
        newCol = direction[0]+curCol
        newRow = direction[1]+curRow
        if inBounds(newRow,newCol) and grid[newRow][newCol] != '#':
            numberOfTurns = 1 if directionOffset == 3 else directionOffset
            newCost = cur[0] + 1 + (1000 * numberOfTurns)
            heapq.heappush(priorityQ, (newCost,newRow,newCol,directionIndex))
print(ret)
