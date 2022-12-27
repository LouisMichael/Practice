# --- Day 23: Unstable Diffusion ---
# You enter a large crater of gray dirt where the grove is supposed to be. All around you, plants you imagine were expected to be full of fruit are instead withered and broken. A large group of Elves has formed in the middle of the grove.

# "...but this volcano has been dormant for months. Without ash, the fruit can't grow!"

# You look up to see a massive, snow-capped mountain towering above you.

# "It's not like there are other active volcanoes here; we've looked everywhere."

# "But our scanners show active magma flows; clearly it's going somewhere."

# They finally notice you at the edge of the grove, your pack almost overflowing from the random star fruit you've been collecting. Behind you, elephants and monkeys explore the grove, looking concerned. Then, the Elves recognize the ash cloud slowly spreading above your recent detour.

# "Why do you--" "How is--" "Did you just--"

# Before any of them can form a complete question, another Elf speaks up: "Okay, new plan. We have almost enough fruit already, and ash from the plume should spread here eventually. If we quickly plant new seedlings now, we can still make it to the extraction point. Spread out!"

# The Elves each reach into their pack and pull out a tiny plant. The plants rely on important nutrients from the ash, so they can't be planted too close together.

# There isn't enough time to let the Elves figure out where to plant the seedlings themselves; you quickly scan the grove (your puzzle input) and note their positions.

# For example:

# ....#..
# ..###.#
# #...#.#
# .#...##
# #.###..
# ##.#.##
# .#..#..
# The scan shows Elves # and empty ground .; outside your scan, more empty ground extends a long way in every direction. The scan is oriented so that north is up; orthogonal directions are written N (north), S (south), W (west), and E (east), while diagonal directions are written NE, NW, SE, SW.

# The Elves follow a time-consuming process to figure out where they should each go; you can speed up this process considerably. The process consists of some number of rounds during which Elves alternate between considering where to move and actually moving.

# During the first half of each round, each Elf considers the eight positions adjacent to themself. If no other Elves are in one of those eight positions, the Elf does not do anything during this round. Otherwise, the Elf looks in each of four directions in the following order and proposes moving one step in the first valid direction:

# If there is no Elf in the N, NE, or NW adjacent positions, the Elf proposes moving north one step.
# If there is no Elf in the S, SE, or SW adjacent positions, the Elf proposes moving south one step.
# If there is no Elf in the W, NW, or SW adjacent positions, the Elf proposes moving west one step.
# If there is no Elf in the E, NE, or SE adjacent positions, the Elf proposes moving east one step.
# After each Elf has had a chance to propose a move, the second half of the round can begin. Simultaneously, each Elf moves to their proposed destination tile if they were the only Elf to propose moving to that position. If two or more Elves propose moving to the same position, none of those Elves move.

# Finally, at the end of the round, the first direction the Elves considered is moved to the end of the list of directions. For example, during the second round, the Elves would try proposing a move to the south first, then west, then east, then north. On the third round, the Elves would first consider west, then east, then north, then south.


# Simulate the Elves' process and find the smallest rectangle that contains the Elves after 10 rounds. How many empty ground tiles does that rectangle contain?
def printElfPos(elfPos):
    for j in range(13):
        line = []
        for i in range(13):
            if (i, j) in elfPos:
                line.append('#')
            else:
                line.append('.')
        print(line)
    print()
elfPos = {}
lookDirectionStack = [[(-1,-1),(0,-1),(1,-1)],[(-1,1),(0,1),(1,1)],[(-1,1),(-1,0),(-1,-1)],[(1,1),(1,0),(1,-1)]]
rounds = 10
elfCount = 0
elfByNumber = {}
elfByNumberNextRound = {}
elfNextRound = {}

minX = 0
minY = 0
maxX = 0
maxY = 0
first = True
with open("input.txt", 'r', encoding='utf-8') as f:
    lines = f.readlines()
    for i, line in enumerate(lines):
        for j, char in enumerate(line):
            if char == '#':
                elfPos[(j,i)] = True
                elfByNumber[elfCount] = (j,i)
                elfCount += 1
                if first:
                    minX = j
                    maxX = j
                    minY = i
                    maxY = i
                    first = False
    printElfPos(elfPos)

for round in range(rounds):
    for elfNumber in range(elfCount):
        needToMove = False
        for lookDirection in lookDirectionStack:
            emptyDirection = True
            for direction in lookDirection:
                checkCor = (elfByNumber[elfNumber][0] + direction[0],elfByNumber[elfNumber][1] + direction[1])
                if checkCor in elfPos:
                    needToMove = True
        if not needToMove:
            elfByNumberNextRound[elfNumber] = elfByNumber[elfNumber]
            continue
        for lookDirection in lookDirectionStack:
            emptyDirection = True
            for direction in lookDirection:
                checkCor = (elfByNumber[elfNumber][0] + direction[0],elfByNumber[elfNumber][1] + direction[1])
                if checkCor in elfPos:
                    emptyDirection = False
                    # print("elf in " + str(checkCor))
            if emptyDirection:
                print("elf: " + str(elfNumber)+ ", trying to move " + str(lookDirection[1]))
                nextPos = (elfByNumber[elfNumber][0] + lookDirection[1][0], elfByNumber[elfNumber][1] + lookDirection[1][1])
                if nextPos in elfNextRound:
                    elfByNumberNextRound[elfNumber] = elfByNumber[elfNumber]
                    elfByNumberNextRound[elfNextRound[nextPos]] = elfByNumber[elfNextRound[nextPos]]
                else:
                    elfByNumberNextRound[elfNumber] = nextPos
                    elfNextRound[nextPos] = elfNumber
                break
        if elfNumber not in elfByNumberNextRound:
            elfByNumberNextRound[elfNumber] = elfByNumber[elfNumber]
    elfByNumber = elfByNumberNextRound
    nextRoundPos = {}
    for elf in elfByNumber.items():
        nextRoundPos[elf[1]] = True
    elfPos = nextRoundPos
    elfByNumberNextRound = {}
    elfNextRound = {}
    lookDirectionStack.append(lookDirectionStack.pop(0))
    printElfPos(elfPos)
for elf in elfByNumber.items():
    if elf[1][0] < minX:
        minX = elf[1][0]
    if elf[1][0] > maxX:
        maxX = elf[1][0]
    if elf[1][1] < minY:
        minY = elf[1][1]
    if elf[1][1] > maxY:
        maxY = elf[1][1]
print(minX)
print(maxX)
print(minY)
print(maxY)

print(((maxX-minX+1) * (maxY - minY+1)) - elfCount)

# round 2
elfPos = {}
lookDirectionStack = [[(-1,-1),(0,-1),(1,-1)],[(-1,1),(0,1),(1,1)],[(-1,1),(-1,0),(-1,-1)],[(1,1),(1,0),(1,-1)]]
rounds = 10
elfCount = 0
elfByNumber = {}
elfByNumberNextRound = {}
elfNextRound = {}

minX = 0
minY = 0
maxX = 0
maxY = 0
first = True
with open("input.txt", 'r', encoding='utf-8') as f:
    lines = f.readlines()
    for i, line in enumerate(lines):
        for j, char in enumerate(line):
            if char == '#':
                elfPos[(j,i)] = True
                elfByNumber[elfCount] = (j,i)
                elfCount += 1
                if first:
                    minX = j
                    maxX = j
                    minY = i
                    maxY = i
                    first = False
    printElfPos(elfPos)
elfNeededToMove = True
roundCount = 0
while elfNeededToMove:
    elfNeededToMove = False
    roundCount += 1
    for elfNumber in range(elfCount):
        needToMove = False
        for lookDirection in lookDirectionStack:
            emptyDirection = True
            for direction in lookDirection:
                checkCor = (elfByNumber[elfNumber][0] + direction[0],elfByNumber[elfNumber][1] + direction[1])
                if checkCor in elfPos:
                    needToMove = True
        if not needToMove:
            elfByNumberNextRound[elfNumber] = elfByNumber[elfNumber]
            continue
        elfNeededToMove = True
        for lookDirection in lookDirectionStack:
            emptyDirection = True
            for direction in lookDirection:
                checkCor = (elfByNumber[elfNumber][0] + direction[0],elfByNumber[elfNumber][1] + direction[1])
                if checkCor in elfPos:
                    emptyDirection = False
                    # print("elf in " + str(checkCor))
            if emptyDirection:
                # print("elf: " + str(elfNumber)+ ", trying to move " + str(lookDirection[1]))
                nextPos = (elfByNumber[elfNumber][0] + lookDirection[1][0], elfByNumber[elfNumber][1] + lookDirection[1][1])
                if nextPos in elfNextRound:
                    elfByNumberNextRound[elfNumber] = elfByNumber[elfNumber]
                    elfByNumberNextRound[elfNextRound[nextPos]] = elfByNumber[elfNextRound[nextPos]]
                else:
                    elfByNumberNextRound[elfNumber] = nextPos
                    elfNextRound[nextPos] = elfNumber
                break
        if elfNumber not in elfByNumberNextRound:
            elfByNumberNextRound[elfNumber] = elfByNumber[elfNumber]
    elfByNumber = elfByNumberNextRound
    nextRoundPos = {}
    for elf in elfByNumber.items():
        nextRoundPos[elf[1]] = True
    elfPos = nextRoundPos
    elfByNumberNextRound = {}
    elfNextRound = {}
    lookDirectionStack.append(lookDirectionStack.pop(0))
    # printElfPos(elfPos)
print(roundCount)