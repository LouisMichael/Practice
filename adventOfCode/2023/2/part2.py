from collections import defaultdict

with open("part1TestInput.txt","r", encoding="utf-8") as f:
    lines = f.readlines()    
    ret = 0
    for lineCount, line in enumerate(lines):
        gameSplit = line.split(":")
        gameSplit[1] = gameSplit[1].strip()
        roundSplit = gameSplit[1].split(";")
        valid = True
        mins = defaultdict(lambda: 0)

        for round in roundSplit:
            colors = round.split(",")
            for color in colors:
                countAndColor = list(filter(None,color.split(" ")))
                mins[countAndColor[1]] = max(mins[countAndColor[1]], int(countAndColor[0]))
        roundPower = 1
        for minKey in mins:
            roundPower *= mins[minKey]
        ret += roundPower
    print(ret)  