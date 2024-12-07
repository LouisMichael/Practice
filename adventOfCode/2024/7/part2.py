import re
import sys
from collections import defaultdict
from functools import lru_cache
# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

grid = []
directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
# directions = [(1,0),(0,1),(-1,0),(0,-1)]

def inBounds(x,y):
    if x<0 or x >= len(grid) or y < 0 or y >= len(grid[x]):
        return False
    return True


@lru_cache(maxsize=256)
def posList(lenth):
    if lenth == 0:
        return [""]
    if lenth == 1:
        return ["0","1","2"]
    retList = []
    for i in ["0","1","2"]:
        allBefore = posList(lenth-1).copy()
        for j in range(len(allBefore)):
            allBefore[j] = allBefore[j]+i 
        retList.extend(allBefore)
    return retList


with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        ansAndRest = line.split(':')
        ans = int(ansAndRest[0])
        operationList = ansAndRest[1].strip().split()
        # print(operationList)
        # print(posList(len(operationList)-1))
        for stringPoss in posList(len(operationList)-1):
            cur = int(operationList[0])
            mask = 0
            for j in range(1,len(operationList)):
                if stringPoss[mask] == '0':
                    cur *= int(operationList[j])
                elif stringPoss[mask] == '1':
                    cur = int(str(cur)+operationList[j])
                else:
                    cur += int(operationList[j])
                mask +=1
            if cur == ans:
                print(f'adding {cur}')
                ret += cur
                break
print(ret)
