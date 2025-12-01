import re
import sys
from collections import defaultdict
from functools import cache
import heapq

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0


def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True

with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    cur = 50
    for line in lines:
        line = line.strip()
        direction = line[0]
        amount = int(line[1:])
        print(f'starting amount {cur} direction {direction} amount {amount}')
        if direction == 'L':
            cur -= amount
        else:
            cur += amount
        if cur < 0:
            ret += 1
            cur += 100
        cur = cur % 100
        if cur == 0:
            ret += 1
            
print(ret)
