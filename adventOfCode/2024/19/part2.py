import re
import sys
from collections import defaultdict
from functools import cache
import numpy as np
import heapq
class TriNode:
    def __init__(self):
        self.next = {}
        self.end = False
triRoot = TriNode()
def addWord (word):
    cur = triRoot
    for curPos in range(len(word)):
        if not word[curPos] in cur.next:
            cur.next[word[curPos]] = TriNode()
        cur = cur.next[word[curPos]]
    cur.end = True
checked = {}
def checkWord(word):
    cur = triRoot
    count = 0
    print(word)
    if word in checked:
        return checked[word]
    for i in range(len(word)):
        #print(i)
        if not word[i] in cur.next:
            break
        cur = cur.next[word[i]]
        if cur.end:
            if i == len(word) -1:
                count+=1
                checked[word] = count
                return count
            count += checkWord(word[i+1::])
    checked[word] = count
    return count
        

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0


with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        if ',' in line:
            available = line.split(', ')
            for word in available:
                #print(word)
                addWord(word)
        elif len(line) > 0:
            add = checkWord(line)
            print(f'adding {add} for {line}')
            ret+=  add
            print(add)
#print(triRoot.next['w'].next['r'].end)
print(ret)
