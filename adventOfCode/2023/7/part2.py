from collections import defaultdict, Counter
import functools

def handsSort(x,y):
    x = x[0]
    y = y[0]
    xJokerCount = Counter(x)['J']
    yJokerCount = Counter(y)['J']
    xNoJoker = x
    if xJokerCount != 0:
        xList = list(x)
        for i in range(xJokerCount):
            xList.remove('J')
        xNoJoker = ''.join(xList)
        # print(xNoJoker)
    yNoJoker = y
    if yJokerCount != 0:
        yList = list(y)
        for i in range(yJokerCount):
            yList.remove('J')
        yNoJoker = ''.join(yList)
        # print(yNoJoker)
    xMostCommon = Counter(xNoJoker).most_common(3)
    yMostCommon = Counter(yNoJoker).most_common(3)
    print(f'xMostCommon: {xMostCommon} yMostCommon:{yMostCommon}')
    if len(xMostCommon) == 0:
        xMostCommon.append(('J',5))
        xJokerCount = 0
    if len(yMostCommon) == 0:
        yMostCommon.append(('J',5))
        yJokerCount = 0
    mostCommmonDiff = (xMostCommon[0][1]+xJokerCount) - (yMostCommon[0][1]+yJokerCount)
    if mostCommmonDiff != 0:
        return mostCommmonDiff
    elif xMostCommon[0][1]+xJokerCount != 5  and xMostCommon[1][1] - yMostCommon[1][1] != 0:
        return xMostCommon[1][1] - yMostCommon[1][1]
    else:
        handOrder = ['A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J']
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


