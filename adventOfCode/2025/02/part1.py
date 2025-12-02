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
ranges = []
def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True

with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        for section in line.split(','):
            print(section)
            start,end = section.split('-')
            ranges.append((int(start),int(end)))
print(ranges)
for r in ranges:
    start = int(len(str(r[0]))//2)
    stop = int((len(str(r[1]))//2)+1)
    print(f'start {start} stop {stop}')
    for digitCount in range(start,stop):
        if digitCount == 0:
            continue
        validGuess = []
        for i in range(digitCount):
            if i == 0:
                validGuess = [str(i) for i in range(1,10)]
            else:
                nextGuess = []
                for guess in validGuess:
                    for digit in range(0,10):
                        nextGuess.append(guess+str(digit))
                validGuess = nextGuess
        for guess in validGuess:
            # print(guess)
            num = int(guess + guess)
            
            if num >= r[0] and num <= r[1]:
                print(num)
                ret += num


print(ret)
