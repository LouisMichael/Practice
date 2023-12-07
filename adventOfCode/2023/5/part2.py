from collections import defaultdict
with open("part1Input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    seedLine = lines[0].split(":")
    seedsRangesAsStrings = list(filter(None,seedLine[1].split(" ")))
    seedRanges = list()
    for i in range(len(seedsRangesAsStrings)//2):
        seedRanges.append((int(seedsRangesAsStrings[i*2]),int(seedsRangesAsStrings[(i*2)+1])))
    curList = 0
    transitionSets = list()
    transitionSets.append(list())
    for i, line in enumerate(lines):
        if i<2:
            continue
        line = line.strip()
        splitLine = list(filter(None,line.split(" ")))
        if len(line) == 0:
            curList+=1
            transitionSets.append(list())
        if len(splitLine) < 3:
            print(f'skipping {line}')
            continue
        transitionSets[curList].append(list(map(lambda x: int(x),splitLine)))
    
    print(f'trying with inital seedRanges {seedRanges}')
    for transitionSet in transitionSets:
        print(f'cur seedRanges {seedRanges}')
        nextSeedRanges = list()
        for seedRange in seedRanges:
            nextRounRangesFromCurrentRangeUsed = list()
            
            for transitionRange in transitionSet:
                # we will only have good information if there is a overlap, if there is no overlap we may get overlap with another range or we may not
                overlapRangeStart = max(transitionRange[1], seedRange[0])
                overlapRangeEnd = min(transitionRange[1]+transitionRange[2]-1, seedRange[0]+seedRange[1]-1)
                print(f'transitionRange: {transitionRange} overlapRangeStart: {overlapRangeStart} overlapRangeEnd:{overlapRangeEnd}')
                if(overlapRangeEnd >= overlapRangeStart):
                    nextRounRangesFromCurrentRangeUsed.append((overlapRangeStart,overlapRangeEnd-overlapRangeStart+1))
                    nextSeedRanges.append((transitionRange[0]+(overlapRangeStart-transitionRange[1]),overlapRangeEnd-overlapRangeStart+1))
            nextRounRangesFromCurrentRangeUsed.sort(key=lambda x: x[0])


            nextRounRangesFromCurrentRangeUsed.sort(key=lambda x: x[0])

            curPos = seedRange[0]
            usedPos = 0
            while curPos < seedRange[0]+seedRange[1]:
                if len(nextRounRangesFromCurrentRangeUsed) > usedPos:
                    usedRange = nextRounRangesFromCurrentRangeUsed[usedPos]
                    nextSeedRanges.append((curPos,usedRange[0]-curPos))
                    curPos = usedRange[0]+usedRange[1]
                    usedPos += 1
                else:
                    nextSeedRanges.append((curPos,(seedRange[0]+seedRange[1])-curPos))
                    curPos = seedRange[0]+seedRange[1]
            # if len(nextRounRangesFromCurrentRangeUsed) == 0:
            #     nextSeedRanges.append(seedRange)
            # curPos = seedRange[0]
            # for usedRange in nextRounRangesFromCurrentRangeUsed:
            #     if(curPos < usedRange[0]):
            #         nextSeedRanges.append((curPos,usedRange[0]-curPos))
            #     curPos = usedRange[0]+usedRange[1]


        seedRanges = nextSeedRanges
    seedRanges.sort(key=lambda x: x[0])
    print(seedRanges)
        

