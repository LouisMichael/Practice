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
def floodFillRetSet(row, col, visited, curLetter, curSet):
    if (row,col) in visited:
        return curSet
    visited.add((row,col))
    curSet.add((row,col))
    for direction in directions:
        newRow = row + direction[0]
        newCol = col + direction[1]
        if inBounds(newRow,newCol) and grid[newRow][newCol] == curLetter:
            floodFillRetSet(newRow,newCol,visited,curLetter, curSet)
    return curSet
def findSidesOfSet(curSet):
    # scan for top horizontal sides, top to bottom, from left to right
    # scan for bottom horizontal sides, bottom to top, from left to right
    # scan for left vertical sides, left to right, from top to bottom
    # scan for right vertical sides, right to left, from top to bottom

    sideCount = 0
    for row in range(len(grid)):
        runningSide = False
        for col in range(len(grid[i])):
            if (row,col) in curSet and (not inBounds(row-1, col) or not (row-1,col) in curSet):
                if not runningSide:
                    sideCount += 1
                runningSide = True
            else:
                runningSide = False
    print(f'after top to bottom sideCount {sideCount}')

    for row in range(len(grid)-1,-1,-1):
        runningSide = False
        for col in range(len(grid[i])):
            if (row,col) in curSet and (not inBounds(row+1, col) or not (row+1,col) in curSet):
                if not runningSide:
                    sideCount += 1
                runningSide = True
            else:
                runningSide = False
    print(f'after bottom to top sideCount {sideCount}')

    for col in range(len(grid[0])):
        runningSide = False
        for row in range(len(grid)):
            if (row,col) in curSet and (not inBounds(row, col-1) or not (row,col-1) in curSet):
                if not runningSide:
                    sideCount += 1
                runningSide = True
            else:
                runningSide = False
    print(f'after left to right sideCount {sideCount}')

    for col in range(len(grid[0])-1,-1,-1):
        runningSide = False
        for row in range(len(grid)):
            if (row,col) in curSet and (not inBounds(row, col+1) or not (row,col+1) in curSet):
                if not runningSide:
                    sideCount += 1
                runningSide = True
            else:
                runningSide = False
    print(f'after right to left sideCount {sideCount}')
    return sideCount
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        grid.append(list(line))
visited = set()       
for i in range(len(grid)):
    for j in range(len(grid[i])):
        shapeSet = floodFillRetSet(i,j,visited,grid[i][j], set())
        if len(shapeSet) > 0:
            print(f'shapeSet {shapeSet} full of {grid[i][j]}')
            sides = findSidesOfSet(shapeSet)
            print(f'sides {sides}')
            ret += len(shapeSet) * sides
print(ret)
