from collections import Counter

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
    counts = Counter(list2)
    
    for i in range(len(list1)):
        if list1[i] in counts:
            ret += list1[i] * counts[list1[i]]
    print(ret)

