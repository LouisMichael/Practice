f = open("input.txt","r", encoding="utf-8")
lines = f.readlines()
TOTAL_SCORE = 0

for line in lines:
    # scan first half
    firstHalfSet = set()
    # print(firstHalfSet)
    for val in range(int(len(line)/2)):
        # print(val)
        firstHalfSet.add(line[val])
    for val in range(int(len(line)/2), len(line)):
        # print(val)
        if line[val] in firstHalfSet:
            # print("mathched " + line[val])
            
            isLowerCase = ord(line[val])-ord('a') +1
            if isLowerCase < 1:
                # print("adding " + str(ord(line[val])-ord('A') +27))
                TOTAL_SCORE += ord(line[val])-ord('A') +27
            else:
                # print("adding " + str(ord(line[val])-ord('a') +1))
                TOTAL_SCORE += isLowerCase
            break
    # scan second half
    # add match
print("The total score for all of your games was: ")
print(TOTAL_SCORE)

# part 2
f = open("input.txt","r", encoding="utf-8")
lines = f.readlines()
TOTAL_SCORE = 0

for lineSetOfThree in range(int(len(lines)/3)):
    setOne = set()
    setTwo = set()
    print(lineSetOfThree*3)
    for char in lines[lineSetOfThree*3]:
        setOne.add(char)
    for char in lines[lineSetOfThree*3+1]:
        if(char in setOne):
            setTwo.add(char)
    for char in lines[lineSetOfThree*3+2]:
        if(char in setTwo):
            print(char)
            isLowerCase = ord(char)-ord('a') +1
            if isLowerCase < 1:
                print("adding " + str(ord(char)-ord('A') +27))
                TOTAL_SCORE += ord(char)-ord('A') +27
            else:
                print("adding " + str(ord(char)-ord('a') +1))
                TOTAL_SCORE += isLowerCase
            break
print(TOTAL_SCORE)

# total time 35 min