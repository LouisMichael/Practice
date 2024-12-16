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
def printBoard(usedPosList):
    
    for i,row in enumerate(grid):
        printLine = ""
        for j,char in enumerate(row):
            if (i,j) in usedPosList:
                printLine += '0'
            else:
                printLine += grid[i][j]
        print(printLine) 
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
            priorityQ.append((0,i,line.index('S'),0,[(i,line.index('S'))]))
        grid.append(list(line))
minTimeToVisit = defaultdict(lambda:0)
bestCost = 0
altPathDict = defaultdict(list)
while len(priorityQ)>0:
    cur = heapq.heappop(priorityQ)
    # print(cur)
    curRow = cur[1]
    curCol = cur[2]
    curDirection = cur[3]
    curList = cur[4]
    if grid[curRow][curCol] == 'E':
        heapq.heappush(priorityQ, cur)
        bestCost = cur[0]
        break
    visitedKey = (curRow,curCol,curDirection)
    if visitedKey in minTimeToVisit:
        if minTimeToVisit[visitedKey] == cur[0]:
            altPathDict[visitedKey].append(curList.copy())
        continue
    minTimeToVisit[visitedKey] = cur[0]
    for directionOffset in range(4):
        directionIndex = (directionOffset + curDirection)%4
        direction = directions[directionIndex]
        newCol = direction[0]+curCol
        newRow = direction[1]+curRow
        if inBounds(newRow,newCol) and grid[newRow][newCol] != '#':
            numberOfTurns = 1 if directionOffset == 3 else directionOffset
            newCost = cur[0] + 1 + (1000 * numberOfTurns)
            newList = curList.copy()
            newList.append(visitedKey)
            heapq.heappush(priorityQ, (newCost,newRow,newCol,directionIndex,newList))
# at this point all of the best paths will be a the front of the heap, we pop them off 
# until we get a worse cost and we add the content of their lists to a set
inBestPath = set()
# print(priorityQ)
allAltPathsToCheck = []
while priorityQ[0][0] == bestCost:
    cur = heapq.heappop(priorityQ)
    # printBoard(cur[4])
    # print(cur)
    for pair in cur[4]:
        allAltPathsToCheck.append(pair)
while len(allAltPathsToCheck) > 0:
    cur = allAltPathsToCheck.pop()
    inBestPath.add((cur[0],cur[1]))
    for altPath in altPathDict[cur]:
        for pos in altPath:
            allAltPathsToCheck.append(pos)
printBoard(inBestPath)
print(len(inBestPath)+1)
