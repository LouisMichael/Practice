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
boardH = 71
boardW = 71
numberOfObstical = 1024
for i in range(boardH):
    grid.append(['.']*boardW)
print(grid)
def printGrid():
    for row in grid:
        print(''.join(row))
def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True

def findShortestPath():
    start = (0,0,0)
    pQ = [start]
    visited = set()
    while len(pQ) > 0:
        cur = heapq.heappop(pQ)
        vistedKey = (cur[1],cur[2])
        if vistedKey in visited:
            continue
        if vistedKey == (len(grid)-1,len(grid[len(grid)-1])-1):
            return cur[0]
        visited.add(vistedKey)
        for direction in directions:
            newX = direction[0]+cur[1]
            newY = direction[1]+cur[2]
            if inBounds(newX,newY):
                if grid[newX][newY] != '#':
                    heapq.heappush(pQ,(cur[0]+1,newX,newY))

        
byteList = []
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        match = re.match(r'(\d+),(\d+)',line)
        print(match.group(1))
        byteList.append((int(match.group(1)),int(match.group(2))))
print(byteList)


printGrid()
print(findShortestPath())

# we can binary search for the number? 
# we can start at a closed state with the graph in two parts and then add from the end until
# we connect, when we connect is the last valid time to make the trip

# start with a full board
for i in range(len(byteList)):
    grid[byteList[i][1]][byteList[i][0]] = '#'

# set up our list of regions as a union find
colorSet = defaultdict()