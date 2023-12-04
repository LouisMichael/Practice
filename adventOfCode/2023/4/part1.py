with open("part1Input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    ret = 0
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
                if winningVal == 0:
                    winningVal = 1
                else:
                    winningVal *= 2
        ret += winningVal
    print(ret)

