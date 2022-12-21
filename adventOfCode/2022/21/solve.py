# --- Day 21: Monkey Math ---
# The monkeys are back! You're worried they're going to try to steal your stuff again, but it seems like they're just holding their ground and making various monkey noises at you.

# Eventually, one of the elephants realizes you don't speak monkey and comes over to interpret. As it turns out, they overheard you talking about trying to find the grove; they can show you a shortcut if you answer their riddle.

# Each monkey is given a job: either to yell a specific number or to yell the result of a math operation. All of the number-yelling monkeys know their number from the start; however, the math operation monkeys need to wait for two other monkeys to yell a number, and those two other monkeys might also be waiting on other monkeys.

# Your job is to work out the number the monkey named root will yell before the monkeys figure it out themselves.

# For example:

# root: pppw + sjmn
# dbpl: 5
# cczh: sllz + lgvd
# zczc: 2
# ptdq: humn - dvpt
# dvpt: 3
# lfqf: 4
# humn: 5
# ljgn: 2
# sjmn: drzm * dbpl
# sllz: 4
# pppw: cczh / lfqf
# lgvd: ljgn * ptdq
# drzm: hmdt - zczc
# hmdt: 32
# Each line contains the name of a monkey, a colon, and then the job of that monkey:

# A lone number means the monkey's job is simply to yell that number.
# A job like aaaa + bbbb means the monkey waits for monkeys aaaa and bbbb to yell each of their numbers; the monkey then yells the sum of those two numbers.
# aaaa - bbbb means the monkey yells aaaa's number minus bbbb's number.
# Job aaaa * bbbb will yell aaaa's number multiplied by bbbb's number.
# Job aaaa / bbbb will yell aaaa's number divided by bbbb's number.
# So, in the above example, monkey drzm has to wait for monkeys hmdt and zczc to yell their numbers. Fortunately, both hmdt and zczc have jobs that involve simply yelling a single number, so they do this immediately: 32 and 2. Monkey drzm can then yell its number by finding 32 minus 2: 30.

# Then, monkey sjmn has one of its numbers (30, from monkey drzm), and already has its other number, 5, from dbpl. This allows it to yell its own number by finding 30 multiplied by 5: 150.

# This process continues until root yells a number: 152.

# However, your actual situation involves considerably more monkeys. What number will the monkey named root yell?

# I think I want to make a little graph

# 1     2       3      7
#  \  /  \     /       |
#   +      div        /   
#    \     /         /
#       *           /
#         \        /
#              -
# the graph will have all the leaves run then tell their output to their dependanceis, then all those run, so on until hopfuly we get a solve

class OpNode:
    def __init__(self,op, name) -> None:
        self.op = op
        self.name = name
        self.output = []
        self.input = [None, None]
        self.inputFrom = []
    def alertOfNewInput(self, input,fromNode):
        if fromNode == self.inputFrom[0]:
            self.input[0] = input
        else:
            self.input[1] = input
        if None not in self.input:
            result = eval(str(self.input[0]) + self.op + str(self.input[1]))
            for output in self.output:
                output.alertOfNewInput(result, self.name)
class RootNode(OpNode):
    def alertOfNewInput(self, input, fromNode):
        if fromNode == self.inputFrom[0]:
            self.input[0] = input
        else:
            self.input[1] = input
        if None not in self.input:
            result = eval(str(self.input[0]) + self.op + str(self.input[1]))
            print("root said: " + str(result))
class NumNode:
    def __init__(self,num, name) -> None:
        self.num = num
        self.name = name
        self.output = []
    def yell(self):
        for output in self.output:
                output.alertOfNewInput(self.num, self.name)
nameToNodeDict = {}
with open("input.txt", 'r', encoding='utf-8') as f:
    lines = f.readlines()
    opNodes = []
    numNodes = []
    for line in lines:
        line = line.strip()
        # root: pppw + sjmn
        splitOnColen = line.split(':')
        splitOperationOnSpace = splitOnColen[1].split(' ')
        if splitOnColen[0] == "root":
            node = RootNode(splitOperationOnSpace[2], splitOnColen[0])
            node.inputFrom.append(splitOperationOnSpace[1])
            node.inputFrom.append(splitOperationOnSpace[3])
            nameToNodeDict[splitOnColen[0]] = node
            opNodes.append(node)
        elif len(splitOperationOnSpace) > 2:
            node = OpNode(splitOperationOnSpace[2], splitOnColen[0])
            node.inputFrom.append(splitOperationOnSpace[1])
            node.inputFrom.append(splitOperationOnSpace[3])
            nameToNodeDict[splitOnColen[0]] = node
            opNodes.append(node)
        else:
            node = NumNode(splitOperationOnSpace[1], splitOnColen[0])
            numNodes.append(node)
            nameToNodeDict[splitOnColen[0]] = node
    for node in opNodes:
        nameToNodeDict[node.inputFrom[0]].output.append(node)
        nameToNodeDict[node.inputFrom[1]].output.append(node)
    for numNode in numNodes:
        numNode.yell()
# --- Part Two ---
# Due to some kind of monkey-elephant-human mistranslation, you seem to have misunderstood a few key details about the riddle.

# First, you got the wrong job for the monkey named root; specifically, you got the wrong math operation. The correct operation for monkey root should be =, which means that it still listens for two numbers (from the same two monkeys as before), but now checks that the two numbers match.

# Second, you got the wrong monkey for the job starting with humn:. It isn't a monkey - it's you. Actually, you got the job wrong, too: you need to figure out what number you need to yell so that root's equality check passes. (The number that appears after humn: in your input is now irrelevant.)

# In the above example, the number you need to yell to pass root's equality test is 301. (This causes root to get the same number, 150, from both of its monkeys.)

# What number do you yell to pass root's equality test?

# I don't think I can reuse too much stuff for this, I want to solve for a value of a leaf instead of moving from the leaves down, so we can instead make lists of operations
# Then do some algabra on our lists to get results
inverseOperations = {'-':'+', '+':'-', '*':'/','/':'*'}
def solveForX(val, equation):
    while equation != 'x':
        if isinstance(equation[0], float):
            if equation[1] == '+':
                val = val - equation[0]
                equation = equation[2]
            elif equation[1] == '-':
                val = equation[0] - val
                equation = equation[2]
            elif equation[1] == '*':
                val = val / equation[0]
                equation = equation[2]
            elif equation[1] == '/':
                val = equation[0] / val
                equation = equation[2]
        else:
            if equation[1] == '+':
                val = val - equation[2]
                equation = equation[0]
            elif equation[1] == '-':
                val = equation[2] + val
                equation = equation[0]
            elif equation[1] == '*':
                val = val / equation[2]
                equation = equation[0]
            elif equation[1] == '/':
                val = val * equation[2]
                equation = equation[0]
    print(val)
        
class OpNodeLister:
    def __init__(self,op, name) -> None:
        self.op = op
        self.name = name
        self.output = []
        self.input = [None, None]
        self.inputFrom = []
    def alertOfNewInput(self, input,fromNode):
        if fromNode == self.inputFrom[0]:
            self.input[0] = input
        else:
            self.input[1] = input
        if None not in self.input:
            if type(self.input[0]) != float or type(self.input[1]) != float:
                result = (self.input[0], self.op ,self.input[1])
            else:
                result = eval(str(self.input[0]) + self.op + str(self.input[1]))
            for output in self.output:
                output.alertOfNewInput(result, self.name)
class RootNodeLister(OpNode):
    def alertOfNewInput(self, input, fromNode):
        if fromNode == self.inputFrom[0]:
            self.input[0] = input
        else:
            self.input[1] = input
        if None not in self.input:
            print("root said: " + str(self.input[0]) + "=" + str(self.input[1]))
            if isinstance(self.input[0], float):
                solveForX(self.input[0], self.input[1])
            else:
                solveForX(self.input[1], self.input[0])
class NumNodeLister:
    def __init__(self,num, name) -> None:
        self.num = num
        self.name = name
        self.output = []
    def yell(self):
        for output in self.output:
                output.alertOfNewInput(self.num, self.name)

nameToNodeDict = {}
with open("test.txt", 'r', encoding='utf-8') as f:
    lines = f.readlines()
    opNodes = []
    numNodes = []
    for line in lines:
        line = line.strip()
        # root: pppw + sjmn
        splitOnColen = line.split(':')
        splitOperationOnSpace = splitOnColen[1].split(' ')
        if splitOnColen[0] == "root":
            node = RootNodeLister(splitOperationOnSpace[2], splitOnColen[0])
            node.inputFrom.append(splitOperationOnSpace[1])
            node.inputFrom.append(splitOperationOnSpace[3])
            nameToNodeDict[splitOnColen[0]] = node
            opNodes.append(node)
        elif len(splitOperationOnSpace) > 2:
            node = OpNodeLister(splitOperationOnSpace[2], splitOnColen[0])
            node.inputFrom.append(splitOperationOnSpace[1])
            node.inputFrom.append(splitOperationOnSpace[3])
            nameToNodeDict[splitOnColen[0]] = node
            opNodes.append(node)
        else:
            if splitOnColen[0] != "humn":
                nodeVal = float(splitOperationOnSpace[1])
            else:
                nodeVal = 'x'
            node = NumNodeLister(nodeVal, splitOnColen[0])
            numNodes.append(node)
            nameToNodeDict[splitOnColen[0]] = node
    for node in opNodes:
        nameToNodeDict[node.inputFrom[0]].output.append(node)
        nameToNodeDict[node.inputFrom[1]].output.append(node)
    for numNode in numNodes:
        numNode.yell()