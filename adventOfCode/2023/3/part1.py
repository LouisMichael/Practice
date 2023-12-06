from collections import defaultdict
with open("part1Input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    ret = 0
    contentKey = defaultdict(lambda: defaultdict(lambda: '.'))
    # fill our map
    for i,line in enumerate(lines):
        line = line.strip()
        for j,char in enumerate(line):
            contentKey[i][j] = char
    # use the map
    capturingDigit = False
    captureDigitString = ""
    ret = 0
    for i,line in enumerate(lines):
        if capturingDigit:
            print(captureDigitString)
            ret += int(captureDigitString)
        capturingDigit = False
        captureDigitString = ""
        for j,char in enumerate(line):
            if capturingDigit and contentKey[i][j].isdigit():
                captureDigitString += contentKey[i][j]
            elif capturingDigit and not contentKey[i][j].isdigit():
                print(captureDigitString)
                ret += int(captureDigitString)
                capturingDigit = False
                captureDigitString = ""
            elif not capturingDigit and contentKey[i][j].isdigit():
                # check for a char
                for offset in [(0,1),(1,1),(1,0),(1,-1),(0,-1),(-1,-1),(-1,0),(-1,1)]:
                    isSymbolChar = contentKey[i+offset[1]][j+offset[0]]
                    if isSymbolChar != '.' and not isSymbolChar.isdigit(): 
                        captureOffset = 0
                        capturingDigit = True
                        while contentKey[i][j-captureOffset].isdigit():
                            captureOffset+=1
                        for k in range(captureOffset):
                            captureDigitString += contentKey[i][j-captureOffset+k+1]
    print(ret)