import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import math

ret = 0
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    x1 = 0
    x2 = 0
    y1 = 0
    y2 = 0
    for line in lines:
        line = line.strip()
        # a = np.array([[94, 22], [34, 67]])
        # b = np.array([8400, 5400])
        # x = np.linalg.solve(a, b)
        if 'A' in line:
            matched  = re.match(r'Button A: X\+(\d+), Y\+(\d+)',line)
            x1 = int(matched.group(1))
            y1 = int(matched.group(2))
        elif 'B' in line:
            matched  = re.match(r'Button B: X\+(\d+), Y\+(\d+)',line)
            x2 = int(matched.group(1))
            y2 = int(matched.group(2))
        elif 'Prize' in line:
            # print(f'trying to solve')
            a = np.array([[x1, x2], [y1, y2]])
            matched = re.match(r'Prize: X=(\d+), Y=(\d+)',line)
            x = int(matched.group(1))+10000000000000
            y = int(matched.group(2))+10000000000000
            b = np.array([x, y])
            solved = np.linalg.solve(a, b)
            print(solved)
            print(f'solved[0]-math.floor(solved[0]) { solved[0]-math.floor(solved[0])}  solved[1]-math.floor(solved[1]) {solved[1]-math.floor(solved[1])}')
            if abs(solved[0]-round(solved[0])) < 0.0001 and abs(solved[1]-round(solved[1])) < 0.0001:
                ret += (solved[0]*3) + (solved[1])
                print(f'ret after add {ret}')
print(ret)