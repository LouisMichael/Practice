import re
import sys
from collections import defaultdict
from functools import cache

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
curList = []
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        curList=line.split(' ')

rounds = 25
print(curList)

@cache
def countAddedStones(stone, rounds):
    print(f'stone {stone}, rounds {rounds}')
    if rounds <= 0:
        return 1
    if int(stone) == 0:
        return countAddedStones('1',rounds-1)
    elif len(stone) %2 == 0:
        curRoundAdd = 0
        curRoundAdd+= countAddedStones(str(int(stone[0:len(stone)//2:1])),rounds-1)
        curRoundAdd+= countAddedStones(str(int(stone[len(stone)//2::])), rounds-1)
        return curRoundAdd
    else:
        return countAddedStones(str(int(stone)*2024),rounds-1)
    
for stone in curList:
    ret += countAddedStones(stone, rounds)

print(ret)
