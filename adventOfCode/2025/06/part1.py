import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq
from functools import reduce

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0


def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True
problemParts = []
with open("input/test.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for i, line in enumerate(lines):
        line = line.strip()
        splitLine = re.split(r'\s+', line)
        print(splitLine)
        if i != len(lines)-1:
            problemParts.append(list(map(int, splitLine)))
        else:
            problemParts.append(splitLine)
print(problemParts)
for problemI in range(len(problemParts[0])):
    problemVals = []
    for j in range(len(problemParts)-1):
        problemVals.append(problemParts[j][problemI])
    if problemParts[-1][problemI] == '*':
        ret += reduce(lambda a,b: a*b, problemVals)
    else:
        ret += sum(problemVals)
print(ret)


# test answer is 4277556