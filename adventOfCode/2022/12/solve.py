# --- Day 12: Hill Climbing Algorithm ---
# You try contacting the Elves using your handheld device, but the river you're following must be too low to get a decent signal.

# You ask the device for a heightmap of the surrounding area (your puzzle input). The heightmap shows the local area from above broken into a grid; the elevation of each square of the grid is given by a single lowercase letter, where a is the lowest elevation, b is the next-lowest, and so on up to the highest elevation, z.

# Also included on the heightmap are marks for your current position (S) and the location that should get the best signal (E). Your current position (S) has elevation a, and the location that should get the best signal (E) has elevation z.

# You'd like to reach E, but to save energy, you should do it in as few steps as possible. During each step, you can move exactly one square up, down, left, or right. To avoid needing to get out your climbing gear, the elevation of the destination square can be at most one higher than the elevation of your current square; that is, if your current elevation is m, you could step to elevation n, but not to elevation o. (This also means that the elevation of the destination square can be much lower than the elevation of your current square.)

# For example:

# Sabqponm
# abcryxxl
# accszExk
# acctuvwj
# abdefghi
# Here, you start in the top-left corner; your goal is near the middle. You could start by moving down or right, but eventually you'll need to head toward the e at the bottom. From there, you can spiral around to the goal:

# v..v<<<<
# >v.vv<<^
# .>vv>E^^
# ..v>>>^^
# ..>>>>>^
# In the above diagram, the symbols indicate whether the path exits each square moving up (^), down (v), left (<), or right (>). The location that should get the best signal is still E, and . marks unvisited squares.

# This path reaches the goal in 31 steps, the fewest possible.

# What is the fewest steps required to move from your current position to the location that should get the best signal?
lookDirections = [[1,0],[-1,0],[0,1],[0,-1]]
with open("input.txt","r", encoding="utf-8") as f:
    start = ()
    end = ()
    heightMap = []
    lines = f.readlines()
    for i, line in enumerate(lines):
        line = line.strip()
        heightMap.append(['a']*len(line))
        for j, char in enumerate(line):
            if char == 'S':
                start = (i,j)
                heightMap[i][j] = 'a'
            elif char == 'E':
                end =(i,j)
                heightMap[i][j] = 'z'
            else:
                heightMap[i][j] = char

    print(heightMap)
    bfsQueue = [start]
    bfsQueueSteps = [0]
    steps = 0
    visited = {}
    while len(bfsQueue) > 0:
        cur = bfsQueue.pop(0)
        # print("at: " +str(cur))
        curSteps = bfsQueueSteps.pop(0)
        if cur in visited:
            continue
        visited[cur] = True
        if cur == end:
            steps = curSteps
            break
        for direction in lookDirections:
            newX = cur[0] + direction[0]
            newY = cur[1] + direction[1]
            # print("newX: " + str(newX))
            # print("newY: " + str(newY))
            # print("cur height: " + str(ord(heightMap[cur[0]][cur[1]])))
            # print("new hight: " + str(ord(heightMap[newX][newY])))
            # print(int(ord(heightMap[cur[0]][cur[1]]) +1) <= int(ord(heightMap[newX][newY])))
            if newX >= 0 and newX < len(heightMap) and newY >= 0 and newY < len(heightMap[newX]) and ord(heightMap[cur[0]][cur[1]])+1 >= ord(heightMap[newX][newY]):
                # print("adding")
                bfsQueue.append((newX,newY))
                bfsQueueSteps.append(curSteps+1)
    print(steps)

# --- Part Two ---
# As you walk up the hill, you suspect that the Elves will want to turn this into a hiking trail. The beginning isn't very scenic, though; perhaps you can find a better starting point.

# To maximize exercise while hiking, the trail should start as low as possible: elevation a. The goal is still the square marked E. However, the trail should still be direct, taking the fewest steps to reach its goal. So, you'll need to find the shortest path from any square at elevation a to the square marked E.

# Again consider the example from above:

# Sabqponm
# abcryxxl
# accszExk
# acctuvwj
# abdefghi
# Now, there are six choices for starting position (five marked a, plus the square marked S that counts as being at elevation a). If you start at the bottom-left square, you can reach the goal most quickly:

# ...v<<<<
# ...vv<<^
# ...v>E^^
# .>v>>>^^
# >^>>>>>^
# This path reaches the goal in only 29 steps, the fewest possible.

# What is the fewest steps required to move starting from any square with elevation a to the location that should get the best signal?

with open("input.txt","r", encoding="utf-8") as f:
    start = ()
    end = ()
    heightMap = []
    posStarts = []
    lines = f.readlines()
    for i, line in enumerate(lines):
        line = line.strip()
        heightMap.append(['a']*len(line))
        for j, char in enumerate(line):
            if char == 'S':
                start = (i,j)
                heightMap[i][j] = 'a'
            if char == 'a':
                aPos = (i,j)
                posStarts.append(aPos)
                heightMap[i][j] = 'a'
            elif char == 'E':
                end =(i,j)
                heightMap[i][j] = 'z'
            else:
                heightMap[i][j] = char

    # print(heightMap)
    posSolve = []
    for posStart in posStarts:
        bfsQueue = [posStart]
        bfsQueueSteps = [0]
        steps = None
        visited = {}
        while len(bfsQueue) > 0:
            cur = bfsQueue.pop(0)
            # print("at: " +str(cur))
            curSteps = bfsQueueSteps.pop(0)
            if cur in visited:
                continue
            visited[cur] = True
            if cur == end:
                steps = curSteps
                break
            for direction in lookDirections:
                newX = cur[0] + direction[0]
                newY = cur[1] + direction[1]
                # print("newX: " + str(newX))
                # print("newY: " + str(newY))
                # print("cur height: " + str(ord(heightMap[cur[0]][cur[1]])))
                # print("new hight: " + str(ord(heightMap[newX][newY])))
                # print(int(ord(heightMap[cur[0]][cur[1]]) +1) <= int(ord(heightMap[newX][newY])))
                if newX >= 0 and newX < len(heightMap) and newY >= 0 and newY < len(heightMap[newX]) and ord(heightMap[cur[0]][cur[1]])+1 >= ord(heightMap[newX][newY]):
                    # print("adding")
                    bfsQueue.append((newX,newY))
                    bfsQueueSteps.append(curSteps+1)
        if steps != None:
            posSolve.append(steps)
    print(posSolve)
    print(min(posSolve))