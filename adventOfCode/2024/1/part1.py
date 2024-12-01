with open("input/part1.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    list1 = []
    list2 = []
    ret = 0
    for line in lines:
        vals = line.split('   ')
        print(vals)
        list1.append(int(vals[0]))
        list2.append(int(vals[1]))
    list1.sort()
    list2.sort()
    for i in range(len(list1)):
        ret += abs(list1[i]-list2[i])
    print(ret)

