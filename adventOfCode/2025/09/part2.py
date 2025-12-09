import re
import sys
from collections import defaultdict
from functools import cache
import heapq
from multiprocessing import Pool
import datetime
import bisect

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
        redPointSet.add((point[0],point[1]))
segments = []
for i,p in enumerate(redPoints):
    nextPoint = redPoints[(i+1)%len(redPoints)]
    segments.append((p,nextPoint))
for i in range(len(redPoints)):
    p = redPoints[i]
    for j in range(i):
        a = redPoints[i]
        b = redPoints[j]
        dx = abs(a[0]-b[0]) + 1
        dy = abs(a[1]-b[1]) + 1
        area = dx * dy
        if area > ret:
            valid = True
            for l in segments:
                lXStart = min(l[0][0],l[1][0])
                lXEnd = max(l[0][0],l[1][0])
                lYStart = min(l[0][1],l[1][1])
                lYEnd = max(l[0][1],l[1][1])
                left = lXEnd <= min(a[0],b[0])
                right = lXStart >= max(a[0],b[0])
                below = lYEnd <= min(a[1],b[1])
                above = lYStart >= max(a[1],b[1])
                if not (left or right or below or above):
                     valid = False
                    #  print(f'a {a} b {b} l {l} left {left} right {right} below {below} above {above}')
                     break
            if valid:
                ret = area
print(ret)