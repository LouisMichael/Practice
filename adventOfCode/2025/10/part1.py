import re
import sys
from collections import defaultdict
from functools import cache
import heapq

# Create a defaultdict with a default value of an empty list
my_dict = defaultdict(list)

ret = 0
problemList = []
with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        (goalString, toolsStrings, joltsString) = re.search(r'(.*\]) (.*) (\{.*)',line).groups()
        goalVal = 0
        for c in goalString[-1:0:-1]:
            goalVal = goalVal << 1
            if c == '#':
                goalVal +=  1
        toolList = []
        for toolString in toolsStrings.split(' '):
            tool = 0
            for valStr in toolString[1:-1].split(','):
                toolPart = int(valStr)
                tool += 1 << (toolPart)
            toolList.append(tool)
        problemList.append((goalVal,toolList))
# bfs tool application is simple 
answers = []
def solveProblem(problem):
    roundCount = 0
    seen = set()
    que = [0]
    while len(que) > 0:
        queLen = len(que)
        for i in range(queLen):
            cur = que.pop(0)
            if cur == problem[0]:
                return roundCount
            if cur in seen:
                continue
            seen.add(cur)
            for tool in problem[1]:
                que.append(cur ^ tool)
        # print(que)
        roundCount += 1
for problem in problemList:
    print(f'started {problem}')
    solve = solveProblem(problem)
    print(f'solved {problem} it is {solve}')
    answers.append(solve)
    
print(answers)
print(sum(answers))
