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
turns = 10000

if inputFile == "input/test.txt":
    boardWidth = 11
    boardHeight = 7

dictOfRobotPosTupleKey = defaultdict(lambda:0)
# the list will hold (x, y, dx, dy)
listOfRobots = []
with open('output.txt','w',encoding="utf-8") as o:
    def doesBoardHavePattern():
        for y in range(boardHeight):
            for x in range(boardWidth):
                if dictOfRobotPosTupleKey[(x,y)] > 0 and dictOfRobotPosTupleKey[(x-1,y+1)] > 0 and dictOfRobotPosTupleKey[(x+1,y+1)] > 0 and dictOfRobotPosTupleKey[(x+2,y+2)] > 0 and dictOfRobotPosTupleKey[(x-2,y+2)] > 0:
                    return True
        return False
    def printBoard():
        for y in range(boardHeight):
            line = ""
            for x in range(boardWidth):
                if dictOfRobotPosTupleKey[(x,y)] == 0:
                    line+=' '
                else:
                    line+=str(dictOfRobotPosTupleKey[(x,y)]%10)
            line+='\n'
            o.write(line)
    
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
            listOfRobots.append((curX,curY,xRateOfChange,yRateOfChange))
    for x in range(turns):
        dictOfRobotPosTupleKey = defaultdict(lambda:0)
        # quadCounts = [[0,0],[0,0]]
        for i, robot in enumerate(listOfRobots):
            listOfRobots[i] = ((robot[0]+robot[2])% boardWidth, (robot[1]+robot[3])% boardHeight, robot[2], robot[3])
            dictOfRobotPosTupleKey[(listOfRobots[i][0], listOfRobots[i][1])] += 1
            # addToQuadCounts(listOfRobots[i][0],listOfRobots[i][1])
        # o.write(str(quadCounts)+'\n')
        if x % (turns//10) == 0:
            print(f'another 10% done')
        if doesBoardHavePattern():
            printBoard()
        o.write(f'{'_'*(boardWidth//2)}{x}{'_'*(boardWidth//2)}\n')

        
