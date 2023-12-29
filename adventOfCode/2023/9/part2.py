# take in a list of numbers and return the next value in the list following the outlined process
def prevValue(listOfVal):
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
    return listOfVal[0] - prevValue(nextRoundList)
    

with open("part1TestInput.txt","r", encoding="utf-8") as f:
    # get all of the race times and distances
    runningSum = 0
    lines = f.readlines()
    for line in lines:
        lineOfStingValues = line.split(' ')
        listOfIntValues = [int(stringVal) for stringVal in lineOfStingValues]
        prevValueOutcome = prevValue(listOfIntValues)
        print(prevValueOutcome)
        runningSum += prevValueOutcome
    print(runningSum)
