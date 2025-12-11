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
# we can track how many times a value is represented in a round instead of what its actual history is
def bfs(curCounts, goal, banned):
    r = 0
    nextRound = defaultdict(int)
    for key in curCounts.keys():
        for connection in connections[key]:
            if connection == goal:
                r += curCounts[key]
            if connection in banned:
                continue
            nextRound[connection] += curCounts[key]
    if len(nextRound) > 0:
        r += bfs(nextRound, goal, banned)
    return r
start = defaultdict(int)
start["svr"] = 1
fftFirst = bfs(start,"fft", set(["out", "dac"]))
print(f'fftFirst: {fftFirst}')

start = defaultdict(int)
start["svr"] = 1
dacFirst = bfs(start,"dac", set(["out", "fft"]))
print(f'dacFirst: {dacFirst}')

start = defaultdict(int)
start["dac"] = 1
fftSecond = bfs(start,"fft", set("out"))
print(f'fftSecond: {fftSecond}')

start = defaultdict(int)
start["fft"] = 1
dacSecond = bfs(start,"dac", set("out"))
print(f'dacSecond: {dacSecond}')

start = defaultdict(int)
start["fft"] = 1
fftToEnd = bfs(start,"out", set())
print(f'fftToEnd: {fftToEnd}')

start = defaultdict(int)
start["dac"] = 1
dacToEnd = bfs(start,"out", set())
print(f'dacToEnd: {dacToEnd}')

print(f'fftFirst * dacSecond * dacToEnd {fftFirst * dacSecond * dacToEnd}')
print(f'dacFirst * fftSecond * fftToEnd {dacFirst * fftSecond * fftToEnd }')