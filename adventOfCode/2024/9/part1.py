import re
import sys
from collections import defaultdict
from functools import cache

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

fileMapString = ""
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        fileMapString = line
fileStack = []
freeSpaceQ = []
charArray = []
for i in range(len(fileMapString)):
    if i % 2 ==0:
        for x in range(int(fileMapString[i])):
            charArray.append(str(i//2))
    else:
        for x in range(int(fileMapString[i])):
            charArray.append(".")
freeSpaceWrite = 0
fileMove = len(charArray)-1
while charArray[fileMove] == '.':
    fileMove -= 1
while charArray[freeSpaceWrite] != ".":
    freeSpaceWrite+=1
while fileMove > freeSpaceWrite:
    charArray[freeSpaceWrite] = charArray[fileMove]
    charArray[fileMove] = '.'
    # print(f'charArray {charArray} fileMove{fileMove} freeSpaceWrite{freeSpaceWrite}')
    while charArray[fileMove] == '.':
        fileMove -= 1
    while charArray[freeSpaceWrite] != ".":
        freeSpaceWrite+=1
countUpPos = 0
while charArray[countUpPos] != '.':
    ret += countUpPos*int(charArray[countUpPos])
    countUpPos+=1
with open("output/part1.txt","w", encoding="utf-8") as f:
    f.write(str(charArray))
print(ret)
