from collections import defaultdict
with open("part1Input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    ret = 0
    maxCard = 208
    lineCount = 1
    counts = defaultdict(lambda: 1)

    for line in lines:
        cardSplit = line.split(":")
        cardSplit[1] = cardSplit[1].strip()
        winningAndRest = cardSplit[1].split("|")
        winningAndRest[0] = winningAndRest[0].strip()
        winningAndRest[1] = winningAndRest[1].strip()
        winning = list(filter(None,winningAndRest[0].split(" ")))
        rest = list(filter(None,winningAndRest[1].split(" ")))
        winningVal = 0
        print(winning)
        print(rest)
        for num in winning:
            if num in rest:
                winningVal+= 1
        for val in range(1,winningVal+1):
            counts[lineCount+val] += counts[lineCount]
        ret += counts[lineCount]
        lineCount+=1
    print(ret)

