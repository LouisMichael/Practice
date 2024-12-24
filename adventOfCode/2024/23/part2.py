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

nodeList = list(graphConnections.keys())

maxCliques = set()
def findMaxClique(current, possible:set, used:set):

    if len(possible) == 0 and len(used) == 0:
        maxCliques.add(",".join(sorted(current)))
        # print(",".join(sorted(current)))
        return
    posList = list(possible)
    for pos in posList:
        nextCurrent = current.copy()
        nextCurrent.append(pos)
        findMaxClique(nextCurrent,possible.intersection(graphConnections[pos]),used.intersection(graphConnections[pos]))
        used.add(pos)
        possible.remove(pos)
findMaxClique([],set(nodeList),set())
maxSize = 0
ret = ""
for maxClique in maxCliques:
    if len(maxClique) > maxSize:
        maxSize = len(maxClique)
        ret = maxClique
print(ret)

