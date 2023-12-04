with open("part1Input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    ret = 0
    for line in lines:
        seenFirst = False
        first = 10
        second = 1
        for char in line:
            if char.isdigit():
                if not seenFirst:
                    seenFirst = True
                    first = 10 * ( ord(char)-ord('0'))
                second = ord(char)-ord('0')
        print(first + second)
        ret += first + second
    print(ret)

