import re
import sys
from collections import defaultdict
from functools import cache

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

grid = []
# directions = [(1,0),(1,1),(0,1),(-1,1),(-1,0),(-1,-1),(1,-1),(0,-1)]
directions = [(1,0),(0,1),(-1,0),(0,-1)]

def inBounds(row,col):
    if row<0 or  row>= len(grid) or col < 0 or col >= len(grid[row]):
        return False
    return True
def floodFillRetAreaParim(row, col, visited, curLetter):
    if (row,col) in visited:
        return (0,0)
    totalAddedArea = 1
    totalAddedParim = 0
    visited.add((row,col))
    for direction in directions:
        newRow = row + direction[0]
        newCol = col + direction[1]
        if inBounds(newRow,newCol) and grid[newRow][newCol] == curLetter:
            (addedArea, addedParim) = floodFillRetAreaParim(newRow,newCol,visited,curLetter)
            totalAddedArea+=addedArea
            totalAddedParim+= addedParim
        else:
            totalAddedParim+=1
    return (totalAddedArea, totalAddedParim)

with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        grid.append(list(line))
visited = set()       
for i in range(len(grid)):
    for j in range(len(grid[i])):
        (area,parim) = floodFillRetAreaParim(i,j,visited,grid[i][j])
        ret += area * parim
print(ret)
