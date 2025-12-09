import re
import sys
from collections import defaultdict
from functools import cache
import heapq
import math

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
points = []
test = False
file = "input/test.txt" if test else "input/input.txt"
with open(file,"r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        points.append(list(map(int, line.split(","))))
unionFind = [i for i in range(len(points))]
connected = defaultdict(set)
connections = defaultdict(lambda: {})
minDistConnections = []
print(points)
def find(i):
    if unionFind[i] == i:
        return i
    else:
        return find(unionFind[i])

for i in range(len(points)):
    for j in range(i):
        if i == j:
            continue
        dx = abs(points[i][0]-points[j][0])
        dy = abs(points[i][1]-points[j][1])
        dz = abs(points[i][2]-points[j][2])
        distXY = math.sqrt((dx*dx)+(dy*dy))
        dist = math.sqrt((distXY*distXY) + (dz*dz))
        heapq.heappush(minDistConnections, (dist,i,j))
        connections[i][j] = dist
        connections[j][i] = dist
r = 10
if not test:
    r = 1000
for i in range(r):
    dist, i, j = heapq.heappop(minDistConnections)
    if j not in connected[i]:
        connected[i].add(j)
        connected[j].add(i)
        unionFind[find(i)] = find(j)
unionFindSizes = defaultdict(int)
for i in range(len(points)):
    unionFindSizes[find(i)] += 1
print(unionFindSizes.values())
sortedSizes = sorted(unionFindSizes.values(), reverse=True)
print(sortedSizes[0]*sortedSizes[1]*sortedSizes[2])
