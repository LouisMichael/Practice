# Advent of Code[About][Events][Shop][Settings][Log Out]LouisMichael 22*
#    sub y{2022}[Calendar][AoC++][Sponsors][Leaderboard][Stats]
# Our sponsors help make Advent of Code possible:
# Mullvad VPN - Join us to free the internet from mass surveillance and censorship, apply here! (Location: Sweden)
# --- Day 16: Proboscidea Volcanium ---
# The sensors have led you to the origin of the distress signal: yet another handheld device, just like the one the Elves gave you. However, you don't see any Elves around; instead, the device is surrounded by elephants! They must have gotten lost in these tunnels, and one of the elephants apparently figured out how to turn on the distress signal.

# The ground rumbles again, much stronger this time. What kind of cave is this, exactly? You scan the cave with your handheld device; it reports mostly igneous rock, some ash, pockets of pressurized gas, magma... this isn't just a cave, it's a volcano!

# You need to get the elephants out of here, quickly. Your device estimates that you have 30 minutes before the volcano erupts, so you don't have time to go back out the way you came in.

# You scan the cave for other options and discover a network of pipes and pressure-release valves. You aren't sure how such a system got into a volcano, but you don't have time to complain; your device produces a report (your puzzle input) of each valve's flow rate if it were opened (in pressure per minute) and the tunnels you could use to move between the valves.

# There's even a valve in the room you and the elephants are currently standing in labeled AA. You estimate it will take you one minute to open a single valve and one minute to follow any tunnel from one valve to another. What is the most pressure you could release?

# For example, suppose you had the following scan output:

# Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
# Valve BB has flow rate=13; tunnels lead to valves CC, AA
# Valve CC has flow rate=2; tunnels lead to valves DD, BB
# Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
# Valve EE has flow rate=3; tunnels lead to valves FF, DD
# Valve FF has flow rate=0; tunnels lead to valves EE, GG
# Valve GG has flow rate=0; tunnels lead to valves FF, HH
# Valve HH has flow rate=22; tunnel leads to valve GG
# Valve II has flow rate=0; tunnels lead to valves AA, JJ
# Valve JJ has flow rate=21; tunnel leads to valve II
# All of the valves begin closed. You start at valve AA, but it must be damaged or jammed or something: its flow rate is 0, so there's no point in opening it. However, you could spend one minute moving to valve BB and another minute opening it; doing so would release pressure during the remaining 28 minutes at a flow rate of 13, a total eventual pressure release of 28 * 13 = 364. Then, you could spend your third minute moving to valve CC and your fourth minute opening it, providing an additional 26 minutes of eventual pressure release at a flow rate of 2, or 52 total pressure released by valve CC.

# Making your way through the tunnels like this, you could probably open many or all of the valves by the time 30 minutes have elapsed. However, you need to release as much pressure as possible, so you'll need to be methodical. Instead, consider this approach:

# == Minute 1 ==
# No valves are open.
# You move to valve DD.

# == Minute 2 ==
# No valves are open.
# You open valve DD.

# == Minute 3 ==
# Valve DD is open, releasing 20 pressure.
# You move to valve CC.

# == Minute 4 ==
# Valve DD is open, releasing 20 pressure.
# You move to valve BB.

# == Minute 5 ==
# Valve DD is open, releasing 20 pressure.
# You open valve BB.

# == Minute 6 ==
# Valves BB and DD are open, releasing 33 pressure.
# You move to valve AA.

# == Minute 7 ==
# Valves BB and DD are open, releasing 33 pressure.
# You move to valve II.

# == Minute 8 ==
# Valves BB and DD are open, releasing 33 pressure.
# You move to valve JJ.

# == Minute 9 ==
# Valves BB and DD are open, releasing 33 pressure.
# You open valve JJ.

# == Minute 10 ==
# Valves BB, DD, and JJ are open, releasing 54 pressure.
# You move to valve II.

# == Minute 11 ==
# Valves BB, DD, and JJ are open, releasing 54 pressure.
# You move to valve AA.

# == Minute 12 ==
# Valves BB, DD, and JJ are open, releasing 54 pressure.
# You move to valve DD.

# == Minute 13 ==
# Valves BB, DD, and JJ are open, releasing 54 pressure.
# You move to valve EE.

# == Minute 14 ==
# Valves BB, DD, and JJ are open, releasing 54 pressure.
# You move to valve FF.

# == Minute 15 ==
# Valves BB, DD, and JJ are open, releasing 54 pressure.
# You move to valve GG.

# == Minute 16 ==
# Valves BB, DD, and JJ are open, releasing 54 pressure.
# You move to valve HH.

# == Minute 17 ==
# Valves BB, DD, and JJ are open, releasing 54 pressure.
# You open valve HH.

# == Minute 18 ==
# Valves BB, DD, HH, and JJ are open, releasing 76 pressure.
# You move to valve GG.

# == Minute 19 ==
# Valves BB, DD, HH, and JJ are open, releasing 76 pressure.
# You move to valve FF.

# == Minute 20 ==
# Valves BB, DD, HH, and JJ are open, releasing 76 pressure.
# You move to valve EE.

# == Minute 21 ==
# Valves BB, DD, HH, and JJ are open, releasing 76 pressure.
# You open valve EE.

# == Minute 22 ==
# Valves BB, DD, EE, HH, and JJ are open, releasing 79 pressure.
# You move to valve DD.

# == Minute 23 ==
# Valves BB, DD, EE, HH, and JJ are open, releasing 79 pressure.
# You move to valve CC.

# == Minute 24 ==
# Valves BB, DD, EE, HH, and JJ are open, releasing 79 pressure.
# You open valve CC.

# == Minute 25 ==
# Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

# == Minute 26 ==
# Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

# == Minute 27 ==
# Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

# == Minute 28 ==
# Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

# == Minute 29 ==
# Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.

# == Minute 30 ==
# Valves BB, CC, DD, EE, HH, and JJ are open, releasing 81 pressure.
# This approach lets you release the most pressure possible in 30 minutes with this valve layout, 1651.

# Work out the steps to release the most pressure in 30 minutes. What is the most pressure you can release?

# To begin, get your puzzle input.

# Answer: 
 

# You can also [Share] this puzzle.

# first thought was dp, but the search space is large since it is not just take or not it is also how early you take
# my next thought is looking at the input much of the values are 0 so they are not really options they are just go betweens, there are actually just 9
# there are only 362,880 9P9 ways to order the opening of these, so we can just measure the distance between all of them, then try all the orders and see
# which is the biggest
import re

class Node:
    def __init__(self, name, connections, rate):
        self.name = name
        self.connections = connections
        self.rate = rate

def dfs(cur, goal, visited):
    # print(cur)
    if cur.name == goal:
        return 0
    if cur in visited:
        return None

    minVal = 40
    visited.add(cur)
    for next in cur.connections:
        nextSearchResult = dfs(nodesByNameDict[next], goal, visited)
        if nextSearchResult != None:
            nextSearchResult = nextSearchResult + cur.connections[next]
            if nextSearchResult < minVal:
                minVal = nextSearchResult
    visited.remove(cur)
    return minVal

def backTrack(curNode, timeLeft, usable):
    if timeLeft <= 0:
        return (0, "")
    maxVal = 0
    maxValFrom = ""
    usable.remove(curNode)
    for node in usable:
        maxResult = backTrack(node, timeLeft-curNode.connections[node.name]-1, usable)
        addedVal = maxResult[0]
        if addedVal > maxVal:
            maxVal = addedVal
            maxValFrom = maxResult[1]
    usable.append(curNode)
    # print(maxValFrom)
    return (maxVal + (curNode.rate * (timeLeft)-1), curNode.name + maxValFrom)

nodesByNameDict = {}
startNodeName = 'AA'
nonZeroNodes = []
with open("input.txt", "r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        # example line:
        # Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
        line = line.strip()
        lineByWord = line.split(' ')
        name = lineByWord[1]
        lineBreakOutConnections = line.split('; tunnels lead to valves ')
        if len(lineBreakOutConnections) != 2:
            lineBreakOutConnections = line.split('; tunnel leads to valve ')
        
        connectionStrings = lineBreakOutConnections[1].split(', ')
        connections = {}
        for connectionString in connectionStrings:
            connections[connectionString] = 1
        rate = int(re.search(r'rate=(\w+);',line)[1])
        # print(rate)
        # print("name: " + name)
        # print(connectionStrings)
        nodesByNameDict[name] = Node(name, connections, rate)
        if rate > 0:
            nonZeroNodes.append(nodesByNameDict[name])
# complete each nodes connection list:
for startNode in nodesByNameDict.items():
    for goalNode in nonZeroNodes:
        visted = set()
        cur = startNode[1]
        # print(goalNode)
        cur.connections[goalNode.name] = dfs(cur, goalNode.name, visted)
    print(str(startNode[1].connections) + ": " + startNode[1].name)

ret = 0
for nonZeroNode in nonZeroNodes:
    # print(nodesByNameDict[startNodeName])
    # print(nodesByNameDict[startNodeName].connections)
    # print(nodesByNameDict[startNodeName].connections[nonZeroNode.name])
    result = backTrack(nonZeroNode, 29-nodesByNameDict[startNodeName].connections[nonZeroNode.name], nonZeroNodes)
    if result[0] > ret:
        ret = result[0]
        retTuple = result
        print("max start at " + nonZeroNode.name)

print(retTuple)
curTime = 1
prevTime = 1
curTime += nodesByNameDict[startNodeName].connections['DD']
curFlow = 0
prevFlow = 0
solve = 0
for val in range(int(len(retTuple[1])/2)):
    prevFlow = curFlow
    curFlow += nodesByNameDict[retTuple[1][val*2:val*2+2]].rate
    curTime += 1
    # print("curTime: " + str(curTime) + " curFlow: " + str(curFlow))
    print("time passed: " + str(curTime - prevTime) + " at flow " + str(prevFlow))
    solve += (curTime - prevTime)*prevFlow
    if val*2+4 <= len(retTuple[1]):
        prevTime = curTime
        curTime += nodesByNameDict[retTuple[1][val*2:val*2+2]].connections[retTuple[1][val*2+2:val*2+4]]
print("time passed: " + str(30-curTime) + " at flow " + str(curFlow))
solve += (31-curTime)*curFlow
print(solve)