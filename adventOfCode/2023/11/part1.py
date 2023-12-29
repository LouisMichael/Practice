
with open("part1Input.txt","r", encoding="utf-8") as f:
    # lets start buy finding all of the expansions
    lines = f.readlines()
    emptyColumList = []
    emptyRowList = []
    galexyOrignalCoordinatesList = []
    for val in lines[0]:
        emptyColumList.append(True)
    for j, line in enumerate(lines):
        emptyRowList.append(True)
        for i, val in enumerate(line):
            if val == '#':
                emptyRowList[j] = False
                emptyColumList[i] = False
                galexyOrignalCoordinatesList.append((i,j))
    print("unajusted galexy list:")
    print(galexyOrignalCoordinatesList)

    offsetGalexy = []
    for galexy in galexyOrignalCoordinatesList:
        xOffset = 0
        yOffset = 0
        for i in range(galexy[0]):
            if emptyColumList[i]:
                xOffset += 1
        for j in range(galexy[1]):
            if emptyRowList[j]:
                yOffset += 1
        offsetGalexy.append((galexy[0]+xOffset,galexy[1]+yOffset))
    print("ajusted galexy list:")
    print(offsetGalexy)

    distanceSum = 0
    for i, galexy in enumerate(offsetGalexy):
        for j in range(i+1,len(offsetGalexy)):
            distance = abs(offsetGalexy[j][0] - galexy[0]) + abs(offsetGalexy[j][1] - galexy[1])
            # print(f'disntance between {i} and {j} is {distance}')
            distanceSum += distance
    print(distanceSum)
            