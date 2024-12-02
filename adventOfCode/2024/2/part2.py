with open("input/input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    ret = 0
    for line in lines:
        vals = line.split(' ')
        print(vals)

        vals = list(map(int,vals))
        print(vals)
        for skipIndex in range(0,len(vals)):
            safe = True
            temp = vals.copy()
            del(temp[skipIndex])
            print(temp)
            for i in range(1,len(temp)):
                if temp[0] > temp[1]:
                    if temp[i] >= temp[i-1] or temp[i-1]-temp[i] > 3:
                        safe = False
                        break
                elif temp[0] < temp[1]:
                    if temp[i] <= temp[i-1] or temp[i]-temp[i-1] > 3:
                        safe = False
                        break
                else:
                    safe = False
                    break
            if safe:
                ret +=1
                break
    print(ret)

