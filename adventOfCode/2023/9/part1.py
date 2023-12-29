# take in a list of numbers and return the next value in the list following the outlined process
def nextValue(listOfVal):
    nextRoundList = []
    allZero = True
    for i, val in enumerate(listOfVal):
        if i == 0:
            continue
        valToAdd = listOfVal[i]-listOfVal[i-1]
        allZero = allZero and (val == 0)
        nextRoundList.append(valToAdd)
    if allZero:
        return 0
    return listOfVal[-1] + nextValue(nextRoundList)
    

with open("part1Input.txt","r", encoding="utf-8") as f:
    runningSum = 0
    lines = f.readlines()
    for line in lines:
        lineOfStingValues = line.split(' ')
        listOfIntValues = [int(stringVal) for stringVal in lineOfStingValues]
        nextValueOutcome = nextValue(listOfIntValues)
        print(nextValueOutcome)
        runningSum += nextValueOutcome
    print(runningSum)
