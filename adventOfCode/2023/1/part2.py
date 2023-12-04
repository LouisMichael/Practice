with open("part1Input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    ret = 0
    pairs = [
        ("one", 1),
        ("two", 2),
        ("three", 3),
        ("four", 4),
        ("five", 5),
        ("six", 6),
        ("seven", 7),
        ("eight", 8),
        ("nine", 9),
        ("1", 1),
        ("2", 2),
        ("3", 3),
        ("4", 4),
        ("5", 5),
        ("6", 6),
        ("7", 7),
        ("8", 8),
        ("9", 9),
        ("0", 0),
    ]
    for line in lines:
        first = -1
        firstVal = 1
        for pair in pairs:
            loc = line.find(pair[0])
            if loc != -1 and (first == -1 or loc < first):
                first = loc
                firstVal = pair[1] * 10
        second = -1
        secondVal = 1
        for pair in pairs:
            loc = line.rfind(pair[0])
            if loc != -1 and( second == -1 or loc > second):
                second = loc
                secondVal = pair[1]
        print(firstVal)
        print(secondVal)
        print(firstVal + secondVal)
        ret += firstVal + secondVal
    print(ret)

