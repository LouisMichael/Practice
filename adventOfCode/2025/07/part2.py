import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq
import copy


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
    beamOnCur = [0] * len(lines[0])
    beamOnCur[lines[0].find('S')] = 1
    
    for line in lines:
        beamOnNext = copy.deepcopy(beamOnCur)
        line = line.strip()
        for i,c in enumerate(line):
            if c == '^' and beamOnCur[i]:
                beamOnNext[i-1] += beamOnCur[i]
                beamOnNext[i+1] += beamOnCur[i]
                beamOnNext[i] = 0
            elif not beamOnNext[i]:
                beamOnNext[i] = beamOnCur[i]
        beamOnCur = beamOnNext
        printLine = ""
        for b in beamOnCur:
            if b:
                printLine+=str(beamOnCur[i])
            else:
                printLine+='.'
        print(printLine)
print(sum(beamOnNext))
