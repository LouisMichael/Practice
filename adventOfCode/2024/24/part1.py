import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq

# Create a defaultdict with a default value of an empty list
curState = {}
gates = []
with open("input/inputFixed.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        # print(line)
        if ':' in line:
            match = re.match(r'(.+): (\d+)',line)
            curState[match.group(1)] = False if match.group(2) == '0' else True
        elif "->" in line:
            match = re.match(r'(.+) (.+) (.+) -> (.+)',line)
            gates.append((match.group(1), match.group(2), match.group(3), match.group(4)))
checked = []
while len(checked) < len(gates):
    for gate in gates :
        if gate[0] in curState and gate[2] in curState and gate not in checked:
            match gate[1]:
                case 'AND':
                    curState[gate[3]] = curState[gate[0]] and curState[gate[2]]
                case 'XOR':
                    curState[gate[3]] = curState[gate[0]] ^ curState[gate[2]]
                case 'OR':
                    curState[gate[3]] = curState[gate[0]] or curState[gate[2]]
                case _:
                    print(f'bug {gate}')
            checked.append(gate)
zWires = []
for wire in curState:
    if wire[0] == 'z':
        zWires.append(wire)
zWires.sort(reverse=True)
ret = 0
for zWire in zWires:
    print(f'{zWire}: {curState[zWire]}')
    if curState[zWire]:
        ret += 1
    ret = ret << 1
ret = ret >> 1
print(curState)
print(gates)
print(ret)
