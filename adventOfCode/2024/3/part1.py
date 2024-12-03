with open("input/part1.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    ret = 0
    curState = 0
    for line in lines:
        curParsePhase = 0
        x = 0
        y = 0
        for i in range(len(line)):
            print(line[i:i+4])
            if line[i:i+4] == "do()":
                curState = 0
            if line[i:i+7] == "don't()":
                curState = 1
            if curParsePhase == 0:
                if line[i] == 'm':
                    curParsePhase +=1
                else:
                    curParsePhase = 0
                    x = 0
                    y = 0
            elif curParsePhase == 1:
                if line[i] == 'u':
                    curParsePhase +=1
                else:
                    curParsePhase = 0
                    x = 0
                    y = 0
            elif curParsePhase == 2:
                if line[i] == 'l':
                    curParsePhase +=1
                else:
                    curParsePhase = 0
                    x = 0
                    y = 0
            elif curParsePhase == 3:
                if line[i] == '(':
                    curParsePhase +=1
                else:
                    curParsePhase = 0
                    x = 0
                    y = 0
            elif curParsePhase == 4:
                if line[i].isdigit():
                    curParsePhase +=1
                    x = int(line[i])
                else:
                    curParsePhase = 0
                    x = 0
                    y = 0
            elif curParsePhase == 5:
                if line[i].isdigit():
                    x = (x*10)+int(line[i])
                elif line[i] == ',':
                    curParsePhase +=1
                else:
                    curParsePhase = 0
                    x = 0
                    y = 0
            elif curParsePhase == 6:
                if line[i].isdigit():
                    curParsePhase +=1
                    y = int(line[i])
                else:
                    curParsePhase = 0
                    x = 0
                    y = 0
            elif curParsePhase == 7:
                if line[i].isdigit():
                    y = (y*10)+int(line[i])
                elif line[i] == ')':
                    curParsePhase = 0
                    if curState == 0:
                        ret += x * y
                else:
                    curParsePhase = 0

    print(ret)

