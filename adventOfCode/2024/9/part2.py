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
fileStartLocationLength = {}
charArray = []
for i in range(len(fileMapString)):
    if i % 2 ==0:
        fileStartLocationLength[i//2] = (len(charArray),int(fileMapString[i]))
        fileStack.append((len(charArray),int(fileMapString[i]),i//2))
        for x in range(int(fileMapString[i])):
            charArray.append(str(i//2))
    else:
        freeSpaceQ.append((len(charArray),int(fileMapString[i])))
        for x in range(int(fileMapString[i])):
            charArray.append(".")
fileStackIndex = len(fileStack)-1
while fileStackIndex >= 0:
    freeSpaceQIndex = 0
    print(fileStackIndex)
    if fileStack[fileStackIndex][0] > freeSpaceQ[freeSpaceQIndex][0]:
        while freeSpaceQIndex < len(freeSpaceQ) and freeSpaceQ[freeSpaceQIndex][1]<fileStack[fileStackIndex][1]:
            freeSpaceQIndex+=1
        if freeSpaceQIndex < len(freeSpaceQ) and fileStack[fileStackIndex][0] > freeSpaceQ[freeSpaceQIndex][0]:
            fileStartLocationLength[fileStack[fileStackIndex][2]] = (freeSpaceQ[freeSpaceQIndex][0],fileStack[fileStackIndex][1])
            freeSpaceQ[freeSpaceQIndex] = (freeSpaceQ[freeSpaceQIndex][0]+fileStack[fileStackIndex][1], freeSpaceQ[freeSpaceQIndex][1] - fileStack[fileStackIndex][1])
            print(f'upating {freeSpaceQIndex} to {freeSpaceQ[freeSpaceQIndex]}')
            if freeSpaceQ[freeSpaceQIndex][1] == 0:
                print(f'popping')
                freeSpaceQ.pop(freeSpaceQIndex)
    else:
        print(f'skipped {fileStackIndex} file is at {fileStack[fileStackIndex][0]} first freespace is at {freeSpaceQ[freeSpaceQIndex][0]}')
    fileStackIndex-=1
for key in fileStartLocationLength:
    start = fileStartLocationLength[key][0]
    length = fileStartLocationLength[key][1]
    for i in range(start,start+length):
        ret += key * i
print(fileStartLocationLength)
print(ret)
