import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq

class Computer:
    def __init__(self, rA, rB, rC, program):
        self.ret = ""
        self.rA = rA
        self.rB = rB
        self.rC = rC
        self.curInstruction = 0
        self.program = program
        self.ret = ""
        self.printIndex = 0

    def getCombo(self,operand):
        match operand:
            case 0:
                return 0
            case 1:
                return 1
            case 2:
                return 2
            case 3:
                return 3
            case 4:
                return self.rA
            case 5:
                return self.rB
            case 6:
                return self.rC
            case 7:
                print("7 is reserved and will not appear in valid programs")
                return None
            case _:
                print("unexpected combo operand")
                return None
    def processInstruction(self,opcode, operand):
        match opcode:
            case 0:
                # print("adv")
                self.rA = self.rA // (pow(2,self.getCombo(operand)))
                self.curInstruction+=2
            case 1:
                # print("bxl")
                self.rB = self.rB ^ operand
                self.curInstruction+=2
            case 2:
                # print("bst")
                self.rB = self.getCombo(operand) % 8
                self.curInstruction+=2
            case 3:
                # print("jnz")
                if self.rA != 0:
                    self.curInstruction = operand
                else:
                    self.curInstruction+=2
            case 4:
                # print("bxc")
                self.rB = self.rB ^ self.rC
                self.curInstruction+=2
            case 5:
                # print("out")
                if self.getCombo(operand) % 8 != self.program[self.printIndex]:
                    self.curInstruction = len(self.program)
                self.ret += str(self.getCombo(operand) % 8) + ','
                self.curInstruction+=2
                self.printIndex +=1
            case 6:
                # print("bdv")
                self.rB = self.rA // (pow(2,self.getCombo(operand)))
                self.curInstruction+=2
            case 7:
                # print("cdv")
                self.rC = self.rA // (pow(2,self.getCombo(operand)))
                self.curInstruction+=2
            case _:
                print("Unexpected opcode")
    def run(self):
        count = 0
        while self.curInstruction < len(self.program) and count < 1000:
            self.processInstruction(program[self.curInstruction],program[self.curInstruction+1])
            count+=1
        if count>=1000:
            print('force quit')
        
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    rA = 0
    rB = 0
    rC = 0
    program = []
    for line in lines:
        line = line.strip()
        if 'Register A:' in line:
           rA = int(re.match(r'Register A: (\d+)',line).group(1))
        if 'Register B:' in line:
           rB = int(re.match(r'Register B: (\d+)',line).group(1))
        if 'Register C:' in line:
           rC = int(re.match(r'Register C: (\d+)',line).group(1))
        if 'Program: ' in line:
           programString = re.match(r'Program: (.+)',line).group(1)
           program = programString.split(',')
           program = list(map(int, program))
    print(rA)
    print(rB)
    print(rC)
    print(program)
    for test in range(2147483647):
        computer = Computer(test,rB,rC,program)
        computer.run()
        a = (computer.ret).strip(',').split(',')
        a = list(map(int, a))
        # print(f'a: {a} program: {program}')
        if a == program:
            print(f'found at :{test}')
            break
