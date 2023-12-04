with open("part1Input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    ret = 0
    max = {
        "red": 12,
        "green": 13,
        "blue" : 14
    }
    ret = 0
    for lineCount, line in enumerate(lines):
        gameSplit = line.split(":")
        gameSplit[1] = gameSplit[1].strip()
        roundSplit = gameSplit[1].split(";")
        valid = True
        for round in roundSplit:
            colors = round.split(",")
            for color in colors:
                countAndColor = list(filter(None,color.split(" ")))
                if countAndColor[1] in max:
                    if int(countAndColor[0]) > max[countAndColor[1]]:
                        valid = False
                else:
                    valid = False
        if valid:
            # print(lineCount)
            ret += lineCount + 1
    print(ret)  