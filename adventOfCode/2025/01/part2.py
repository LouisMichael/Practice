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
        start = cur
        if amount > 100:
            ret += amount // 100
            amount = amount % 100
        print(f'starting amount {cur} direction {direction} amount {amount}')
        if direction == 'L':
            cur -= amount
        else:
            cur += amount
        if cur == 0 or ((cur >= 100 or cur < 0) and start != 0):
            ret += 1
        cur = cur % 100
        print(f'ending amount {cur} ret {ret}')
        
            
print(ret)
