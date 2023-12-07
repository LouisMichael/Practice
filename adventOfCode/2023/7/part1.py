from collections import defaultdict, Counter
import functools

def handsSort(x,y):
    x = x[0]
    y = y[0]
    xMostCommon = Counter(x).most_common(2)
    yMostCommon = Counter(y).most_common(2)

    mostCommmonDiff = xMostCommon[0][1] - yMostCommon[0][1]
    handOrder = ['A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2']
    if mostCommmonDiff != 0:
        return mostCommmonDiff
    elif xMostCommon != 5 and xMostCommon[1][1] - yMostCommon[1][1] != 0:
        return xMostCommon[1][1] - yMostCommon[1][1]
    else:
        pos = 0
        while pos < 5 and handOrder.index(x[pos]) == handOrder.index(y[pos]):
            pos+=1
        return  handOrder.index(y[pos])-handOrder.index(x[pos]) 

listOfHandsAndBets = list()
with open("part1Input.txt","r", encoding="utf-8") as f:
    lines = f.readlines()
    for line in lines:
        line = line.strip()
        splitLine = line.split(" ")
        listOfHandsAndBets.append((splitLine[0],int(splitLine[1])))
    listOfHandsAndBets.sort(key=functools.cmp_to_key(handsSort))
    print(listOfHandsAndBets)
    ret = 0
    for i, handAndBet in enumerate(listOfHandsAndBets):
        ret += handAndBet[1] * (i+1)
    print(ret)


