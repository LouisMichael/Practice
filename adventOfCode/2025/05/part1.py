import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq
import bisect

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0

ranges = []
tests = []
collectingRanges = True
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        if collectingRanges:
            if line == "":
                collectingRanges = False
                continue
            splitLine = line.split('-')
            start = int(splitLine[0])
            stop = int(splitLine[1])
            ranges.append((start, stop))
        else:
            tests.append(int(line))
ranges.sort()
for test in tests:
    for r in ranges:
        if r[0] <= test and r[1] >= test:
            ret += 1
            break

print(ret)
