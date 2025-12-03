import re
import sys
from collections import defaultdict
from functools import cache
import heapq

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
    for line in lines:
        digits = [0,0]
        line = line.strip()
        for i,char in enumerate(line):
            intVal = int(char)
            for j in range(len(digits)):
                if intVal > digits[j] and len(digits)-j <= len(line)-i:
                    digits[j] = intVal
                    digits[j+1:] = [0] * (len(digits) - j - 1)
                    break
        print(digits)
        toAdd = 0
        for i,d in enumerate(digits):
            toAdd += d * (10 ** (len(digits)-i-1))
        ret += toAdd

print(ret)
