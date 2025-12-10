import re
import sys
from collections import defaultdict, deque
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
        
        goalList = list(map(int,joltsString[1:-1].split(',')))
        toolList = []
        for toolString in toolsStrings.split(' '):
            tool = [0]*len(goalList)
            for valStr in toolString[1:-1].split(','):
                toolPart = int(valStr)
                tool[toolPart] += 1
            toolList.append(tool)
        problemList.append((goalList,toolList))
# print(problemList)
# bfs tool application is simple 
answers = []
def solveProblem(problem):
    roundCount = 0
    problemL = len(problem[0]) 
    queue = deque([[0]*problemL])
    seen = set()
    while len(queue) > 0:
        queLen = len(queue)
        for i in range(queLen):
            cur = queue.popleft()
            if tuple(cur) in seen:
                continue
            seen.add(tuple(cur))
            if tuple(cur) == tuple(problem[0]):
                return roundCount
            for i in range(problemL):
                if cur[i] > problem[0][i]:
                    continue
            for tool in problem[1]:
                nextVal = [0] * problemL
                for i in range(problemL):
                    nextVal[i] = cur[i] + tool[i]
                queue.append(nextVal)
        roundCount += 1
for problem in problemList:
    print(f'started {problem}')
    solve = solveProblem(problem)
    print(f'solved {problem} it is {solve}')
    answers.append(solve)
    
# print(answers)
print(sum(answers))

# started ((36, 63, 29, 56, 28, 48, 43, 52, 23), [(1, 1, 0, 1, 1, 0, 1, 1, 1), (0, 1, 1, 1, 0, 1, 1, 0, 1), (1, 1, 0, 0, 0, 0, 0, 0, 0), (0, 0, 0, 1, 0, 1, 1, 1, 0), (0, 0, 1, 0, 0, 1, 0, 1, 0), (0, 1, 1, 1, 1, 1, 0, 1, 1), (0, 0, 0, 0, 0, 0, 0, 1, 0), (1, 1, 0, 1, 0, 0, 0, 0, 0), (1, 0, 0, 1, 0, 0, 0, 1, 0), (0, 1, 0, 0, 1, 0, 1, 0, 0)])