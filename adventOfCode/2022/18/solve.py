# --- Day 18: Boiling Boulders ---
# You and the elephants finally reach fresh air. You've emerged near the base of a large volcano that seems to be actively erupting! Fortunately, the lava seems to be flowing away from you and toward the ocean.

# Bits of lava are still being ejected toward you, so you're sheltering in the cavern exit a little longer. Outside the cave, you can see the lava landing in a pond and hear it loudly hissing as it solidifies.

# Depending on the specific compounds in the lava and speed at which it cools, it might be forming obsidian! The cooling rate should be based on the surface area of the lava droplets, so you take a quick scan of a droplet as it flies past you (your puzzle input).

# Because of how quickly the lava is moving, the scan isn't very good; its resolution is quite low and, as a result, it approximates the shape of the lava droplet with 1x1x1 cubes on a 3D grid, each given as its x,y,z position.

# To approximate the surface area, count the number of sides of each cube that are not immediately connected to another cube. So, if your scan were only two adjacent cubes like 1,1,1 and 2,1,1, each cube would have a single side covered and five sides exposed, a total surface area of 10 sides.

# Here's a larger example:

# 2,2,2
# 1,2,2
# 3,2,2
# 2,1,2
# 2,3,2
# 2,2,1
# 2,2,3
# 2,2,4
# 2,2,6
# 1,2,5
# 3,2,5
# 2,1,5
# 2,3,5
# In the above example, after counting up all the sides that aren't connected to another cube, the total surface area is 64.

# What is the surface area of your scanned lava droplet?
offSets = [[0,0,1],[0,0,-1],[1,0,0],[-1,0,0],[0,1,0],[0,-1,0]]
with open("test.txt", 'r', encoding='utf-8') as f:
    lines = f.readlines()
    points = {}
    for line in lines:
        line = line.strip()
        splitLine = line.split(',')
        points[(int(splitLine[0]),int(splitLine[1]),int(splitLine[2]))] = True
    surface = 0
    # check top 
    # check bottom
    # check left
    # check right
    # check front
    # check back
    
    for point in points:
        for offSet in offSets:
            checkPoint = [0,0,0]
            for i, val in enumerate(offSet):
                checkPoint[i] = point[i] + val
            if tuple(checkPoint) not in points:
                surface += 1
    print(surface)

# --- Part Two ---
# Something seems off about your calculation. The cooling rate depends on exterior surface area, but your calculation also included the surface area of air pockets trapped in the lava droplet.

# Instead, consider only cube sides that could be reached by the water and steam as the lava droplet tumbles into the pond. The steam will expand to reach as much as possible, completely displacing any air on the outside of the lava droplet but never expanding diagonally.

# In the larger example above, exactly one cube of air is trapped within the lava droplet (at 2,2,5), so the exterior surface area of the lava droplet is 58.

# What is the exterior surface area of your scanned lava droplet?

# so instead of just pair wise comparing points we can instead put the points in a matrix, and flood fill the outside of the matrix, then the surface area is all of the outside blocks that are also ajacent
with open("input.txt", 'r', encoding='utf-8') as f:
    lines = f.readlines()
    points = {}
    minMaxPairs = [[-1,0],[-1,0],[-1,0]]
    surfaceArea = 0
    for line in lines:
        line = line.strip()
        splitLine = line.split(',')
        x = int(splitLine[0])
        y = int(splitLine[1])
        z = int(splitLine[2])
        points[(x,y,z)] = True
        for i, pair in enumerate(minMaxPairs):
            if int(splitLine[i]) > pair[1]:
                pair[1] = int(splitLine[i])
            if int(splitLine[i]) < pair[0]:
                pair[0] = int(splitLine[i])
    lavaMatrix = []
    for i in range(minMaxPairs[0][1]+3):
        lavaMatrix.append([])
        for j in range(minMaxPairs[1][1]+3):
            lavaMatrix[i].append([False]*(minMaxPairs[2][1]+3))
    # print(lavaMatrix)
    for point in points:
        # print(point)
        lavaMatrix[point[0]+1][point[1]+1][point[2]+1] = True
    floodFillStack = [(0,0,0)]
    floodFillVisted = set()
    # print(lavaMatrix)
    while len(floodFillStack) > 0:
        cur = floodFillStack.pop()
        if cur in floodFillVisted:
            continue
        floodFillVisted.add(cur)
        for offSet in offSets:
            inRange = True
            for direction in range(3):
                if cur[direction] + offSet[direction] > minMaxPairs[direction][1] + 2 or cur[direction] + offSet[direction] < 0:
                    inRange = False
            if not inRange:
                continue
            if lavaMatrix[cur[0]+offSet[0]][cur[1]+offSet[1]][cur[2]+offSet[2]]:
                # print("trying from " + str(cur))
                surfaceArea += 1
            else:
                floodFillStack.append((cur[0]+offSet[0],cur[1]+offSet[1],cur[2]+offSet[2]))
    print(surfaceArea)

    #[[-1, 19], [-1, 18], [-1, 19]]