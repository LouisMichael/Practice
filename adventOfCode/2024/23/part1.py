import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq

# Create a defaultdict with a default value of an empty list
graphConnections = defaultdict(set)

ret = 0


with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        nodes = line.split('-')
        graphConnections[nodes[0]].add(nodes[1])
        graphConnections[nodes[1]].add(nodes[0])

setsOfThree = set()
for node in graphConnections:
    for connection in graphConnections[node]:
        for connection2 in graphConnections[connection]:
            if node in graphConnections[connection2]:
                setOfThreeKey = [node,connection,connection2]
                setOfThreeKey.sort()
                setsOfThree.add("".join(setOfThreeKey))
print(setsOfThree)
                
for setOfThree in setsOfThree:
    if setOfThree[0] == 't' or setOfThree[2] == 't' or setOfThree[4] == 't':
        ret+=1
print(ret)
