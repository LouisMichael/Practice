with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    ret = 0
    for line in lines:
        vals = line.split(' ')
        print(vals)

        vals = list(map(int,vals))
        print(vals)
        safe = True
        for i in range(1,len(line)):
            if vals[0] > vals[1]:
                if vals[i] >= vals[i-1] or vals[i-1]-vals[i] > 3:
                    safe = False
                    break
            elif vals[0] < vals[1]:
                if vals[i] <= vals[i-1] or vals[i]-vals[i-1] > 3:
                    safe = False
                    break
            else:
                safe = False
                break
        if safe:
            ret +=1
    print(ret)

