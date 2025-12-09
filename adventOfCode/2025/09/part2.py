import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

redPoints = []
greenPoints = set()
redPointSet = set()
directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
# directions = [(1,0),(0,1),(-1,0),(0,-1)]

def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True
minX = sys.maxsize
maxX = -1
minY = sys.maxsize
maxY = -1
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        point = list(map(int,line.split(',')))
        redPoints.append(point)
        redPointSet.add((point[0], point[1]))
        minX = min(minX, point[0])
        minY = min(minY, point[1])
        maxX = max(maxX, point[0])
        maxY = max(maxY, point[1])

# print(points)
# test asnwer 50
for i in range(len(redPoints)):
    nextPoint = redPoints[(i+1) % len(redPoints)]
    curPoint = redPoints[i]
    if curPoint[0] == nextPoint[0]:
        for j in range(min(curPoint[1], nextPoint[1]), max(curPoint[1], nextPoint[1])+1):
            greenPoints.add((curPoint[0], j))
    else:
        for j in range(min(curPoint[0], nextPoint[0]), max(curPoint[0], nextPoint[0])+1):
            greenPoints.add((j, curPoint[1]))
print(f'maxX {maxX} maxY {maxY}')
rowMinMax = defaultdict(lambda:(0,0))
for i in range(minX, maxX + 1):
    minSeen = sys.maxsize
    maxSeen = -1
    for j in range(minY, maxY + 1):
        if (i,j) in greenPoints or (i,j) in redPoints:
            minSeen=min(minSeen, j)
            maxSeen=max(maxSeen,j)
    rowMinMax[i] = (minSeen, maxSeen)
# for i in range(maxX):
#     printLine = ""
#     for j in range(maxY+1):
#         if (i,j) in redPointSet:
#             printLine += "R"
#         elif (i,j) in greenPoints:
#             printLine += "G"
#         else:
#             printLine+="."
#     print(printLine)
for i in range(len(redPoints)):
    # go down and right from the point
    minGreenSeen = sys.maxsize
    curCol = redPoints[i][0]
    while(minGreenSeen > 0):
        curRow = redPoints[i][1]
        while curRow - redPoints[i][1] <= minGreenSeen and curCol >= rowMinMax[curRow][0] and curCol <= rowMinMax[curRow][1]:
            if (curCol, curRow) in redPointSet:
                ret = max(ret, (curRow- redPoints[i][1]+1) * (curCol- redPoints[i][0]+1))
            curRow += 1
        minGreenSeen = curRow - redPoints[i][1]
        # print(minGreenSeen)
        curCol += 1


print(ret)
