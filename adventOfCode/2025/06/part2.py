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
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for i, line in enumerate(lines):
        if i < len(lines) - 1:
            problemParts.append(list(line))
        else:
            line = line.strip()
            problemParts.append(re.split(r'\s+', line))
        
# print(problemParts)
problemI = 0
runningProblemVal = 0 if problemParts[-1][problemI] == '+' else 1
for pos in range(len(problemParts[0])):
    valString = ""
    for j in range(len(problemParts)-1):
        valString += problemParts[j][pos]
    # print(valString)
    if re.search(r'\d', valString) == None:
        ret += runningProblemVal
        problemI += 1
        if problemI < len(problemParts[-1]):
            runningProblemVal = 0 if problemParts[-1][problemI] == '+' else 1
    else:
        if problemParts[-1][problemI] == '+':
            runningProblemVal += int(valString)
        else:
            runningProblemVal *= int(valString)
    

print(ret)


# test answer is 3263827