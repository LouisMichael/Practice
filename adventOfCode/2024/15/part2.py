import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

grid = []
# directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
directions = [(1,0),(0,1),(-1,0),(0,-1)]
def printGrid():
    for row in grid:
        print(''.join(row))
def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True
directionQ = []
fishPos = (0,0)

def parseDirctionLineAddingToDirectionQ(line: str):
    for char in line:
        match char:
            case 'v':
                directionQ.append((0,1))
            case '<':
                directionQ.append((-1,0))
            case '>':
                directionQ.append((1,0))
            case '^':
                directionQ.append((0,-1))
            case _:
                print("case encountred unknown")
def canPush(startTuple, directionTuple):
    tryMovePos = (startTuple[0] + directionTuple[0],startTuple[1] + directionTuple[1])
    if inBounds(tryMovePos[1],tryMovePos[0]):
        match grid[tryMovePos[1]][tryMovePos[0]]:
            case '.':
                return True
            case '[':
                if directionTuple[1] != 0:
                    return canPush(tryMovePos,directionTuple) and canPush((tryMovePos[0]+1,tryMovePos[1]),directionTuple)
                return canPush(tryMovePos,directionTuple)
            case ']':
                if directionTuple[1] != 0:
                    return canPush(tryMovePos,directionTuple) and canPush((tryMovePos[0]-1,tryMovePos[1]),directionTuple)
                return canPush(tryMovePos,directionTuple)
            case _:
                return False
def tryPush(startTuple, directionTuple):
    tryMovePos = (startTuple[0] + directionTuple[0],startTuple[1] + directionTuple[1])
    if inBounds(tryMovePos[1],tryMovePos[0]):
        match grid[tryMovePos[1]][tryMovePos[0]]:
            case '.':
                if not (grid[startTuple[1]][startTuple[0]] == '[' and grid[tryMovePos[1]][tryMovePos[0]+1] == '#') and not (grid[startTuple[1]][startTuple[0]] == ']' and grid[tryMovePos[1]][tryMovePos[0]-1] == '#'):
                    grid[tryMovePos[1]][tryMovePos[0]]=grid[startTuple[1]][startTuple[0]]
                    grid[startTuple[1]][startTuple[0]]='.'
                
            case '[':
                tryPush(tryMovePos,directionTuple)
                if directionTuple[1] != 0:
                    tryPush((tryMovePos[0]+1,tryMovePos[1]),directionTuple)
                if grid[tryMovePos[1]][tryMovePos[0]] == '.':
                    grid[tryMovePos[1]][tryMovePos[0]]=grid[startTuple[1]][startTuple[0]]
                    grid[startTuple[1]][startTuple[0]]='.'
            case ']':
                tryPush(tryMovePos,directionTuple)
                if directionTuple[1] != 0:
                    tryPush((tryMovePos[0]-1,tryMovePos[1]),directionTuple)
                if grid[tryMovePos[1]][tryMovePos[0]] == '.':
                    grid[tryMovePos[1]][tryMovePos[0]]=grid[startTuple[1]][startTuple[0]]
                    grid[startTuple[1]][startTuple[0]]='.'
        print(grid[tryMovePos[1]][tryMovePos[0]])
        if grid[tryMovePos[1]][tryMovePos[0]] == '@':
            return tryMovePos
    return startTuple


with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    part = 1
    for i,line in enumerate(lines):
        line = line.strip()
        if len(line)<2:
            part = 2
        elif part == 1:
            newLine = ""
            for char in line:
                match char:
                    case '#':
                        newLine+='##'
                    case 'O':
                        newLine+='[]'
                    case '.':
                        newLine+='..'
                    case '@':
                        newLine+='@.'
            grid.append(list(newLine))
            if '@' in newLine:
                fishPos = (newLine.index('@'),i)
        else:
            parseDirctionLineAddingToDirectionQ(line)
printGrid()

for direction in directionQ:
    print(f'fishPos: {fishPos} direction: {direction}')
    if canPush(fishPos, direction):
        fishPos = tryPush(fishPos, direction)
printGrid()


# score the grid
for i, row in enumerate(grid):
    for j, char in enumerate(row):
        if char == '[':
            ret += (i*100) + j

print(ret)
