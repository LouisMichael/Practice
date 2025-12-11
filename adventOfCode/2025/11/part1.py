import re
import sys
from collections import defaultdict
from functools import cache
import heapq

ret = 0
connections = defaultdict(list)

with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        startNode, endNodesString = line.split(':')
        endNodesString = endNodesString.strip()
        endNodes = endNodesString.split(' ')
        connections[startNode] = endNodes
print(connections)
def dfs(cur, visited):
    # print(cur)
    if cur == "out":
        return 1
    if cur in visited:
        # we are in a cycle
        return 0
    visited.add(cur)
    returnVal = 0
    for connection in connections[cur]:
        returnVal += dfs(connection, set(visited))
    return returnVal

print(dfs("srv", set()))