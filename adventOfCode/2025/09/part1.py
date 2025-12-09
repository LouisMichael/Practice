import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

points = []
directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
# directions = [(1,0),(0,1),(-1,0),(0,-1)]

def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True

with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        points.append(list(map(int,line.split(','))))
# print(points)
# test asnwer 50
for i in range(len(points)):
    # print(points[i])
    for j in range(i):
        # print(points[j])
        ret = max((abs(points[i][0]-points[j][0])+1)*(abs(points[i][1]-points[j][1])+1), ret)
print(ret)
