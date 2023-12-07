from collections import defaultdict
with open("part1Input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    seedLine = lines[0].split(":")
    seedsAsStrings = list(filter(None,seedLine[1].split(" ")))
    
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
    ret = 9223372036854775807
    for seedString in seedsAsStrings:
        print(f'trying with inital seed {seedString}')
        seedNumber = int(seedString)
        for transitionSet in transitionSets:
            print(f'cur value {seedNumber}')
            for transitionRange in transitionSet:
                if seedNumber >=  transitionRange[1] and seedNumber < transitionRange[1]+transitionRange[2]:
                    seedNumber = transitionRange[0] + (seedNumber-transitionRange[1])
                    break
        ret = min(ret,seedNumber)
    print(ret)
        

