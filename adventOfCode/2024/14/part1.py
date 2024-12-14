import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

# grid = []
# directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
# directions = [(1,0),(0,1),(-1,0),(0,-1)]
inputFile = "input/input.txt"
def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True
# we should be able to process every robot one at a time after 100s
boardWidth = 101
boardHeight = 103
turns = 100

if inputFile == "input/test.txt":
    boardWidth = 11
    boardHeight = 7

quadCounts = [[0,0],[0,0]]
def addToQuadCounts(x,y):
    xAdd = 0
    yAdd = 0
    if x == boardWidth//2:
        return
    if y == boardHeight//2:
        return
    if x > boardWidth//2:
        xAdd = 1
    if y > boardHeight//2:
        yAdd = 1
    quadCounts[xAdd][yAdd] += 1
with open(inputFile,"r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        #  matched  = re.match(r'Button A: X\+(\d+), Y\+(\d+)',line)
            # x1 = int(matched.group(1))
            # y1 = int(matched.group(2))
        matched  = re.match(r'p=(-?\d+),(-?\d+) v=(-?\d+),(-?\d+)',line)
        curX = int(matched.group(1))
        curY = int(matched.group(2))
        xRateOfChange = int(matched.group(3))
        yRateOfChange = int(matched.group(4))
        xAtEnd = (curX + (xRateOfChange * turns)) % boardWidth
        yAtEnd = (curY + (yRateOfChange * turns)) % boardHeight
        addToQuadCounts(xAtEnd,yAtEnd)
print(quadCounts)
ret = quadCounts[0][0] * quadCounts[0][1] * quadCounts[1][0] * quadCounts[1][1]
print(ret)
