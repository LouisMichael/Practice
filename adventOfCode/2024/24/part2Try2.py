import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq

# Create a defaultdict with a default value of an empty list
curState = {}
gates = []
dictWireToInputGate = defaultdict(lambda: [])
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
            gate = (match.group(1), match.group(2), match.group(3), match.group(4))
            gates.append(gate)
            dictWireToInputGate[match.group(1)].append((gate))
            dictWireToInputGate[match.group(3)].append((gate))


# lets just try to write like 2 or three tools and see if the answer get simpler to find
def printInputVals():
    xVal = 0
    yVal = 0
    for bit in range(45):
        if curState[f'x{(44-bit):02}']:
            xVal += 1
        xVal = xVal << 1
        if curState[f'y{(44-bit):02}']:
            yVal += 1
        yVal = yVal << 1
    print(f'xVal: {xVal}')
    print(f'yVal: {yVal}')
    return (xVal,yVal)
def listMissMatchEndBits(goal, cur):
    for bit in range(46):
        if goal & 1 != cur & 1:
            print(f'miss match at {bit}')
        goal = goal >> 1
        cur = cur >> 1

def simpleMissMatchInput():
    # the output of xOR gates should go to XOR gates or Z
    # the output of AND gates should go to OR gates
    # the output of OR gates goes to XOR or AND
    for gate in gates:
        match gate[1]:
            case 'AND':
                for inputGate in dictWireToInputGate[gate[3]]:
                    # if len(dictWireToInputGate[gate[3]]) != 1:
                    #     print(f'{gate} seems to go to too many places')
                    if inputGate[1] != 'OR':
                        print(f'{gate} is and AND gate going to a {inputGate[1]} gate')
            case 'XOR':
                for inputGate in dictWireToInputGate[gate[3]]:
                    if inputGate[1] == 'OR':
                        print(f'{gate} is and XOR gate going to a {inputGate[1]} gate')
            case 'OR':
                for inputGate in dictWireToInputGate[gate[3]]:
                    if inputGate[1] == 'OR':
                        print(f'{gate} is and OR gate going to a {inputGate[1]} gate')
            case _:
                print(f'bug {gate}')

def sortCommaString(strIn):
    listToSort = strIn.split(',')
    listToSort.sort()
    return ','.join(listToSort)
inputVals = printInputVals()
listMissMatchEndBits(41324968747726,inputVals[0]+inputVals[1])
simpleMissMatchInput()
print(bin(inputVals[0]+inputVals[1]))
print(bin(41324968747726))
print(sortCommaString("mvb,z08,z18,wss,rds,jss,bmn,z23"))


