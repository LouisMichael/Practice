import math
def quadraticSolver(a, b, c):
    print(f'a: {a} b: {b} c: {c}')
    discriminant = (b*b) - (4*a*c)
    root1 = ((-1 * b) + math.sqrt(discriminant))/(2*a)
    root2 = ((-1 * b) - math.sqrt(discriminant))/(2*a)
    return (root1, root2)

with open("part1Input.txt","r", encoding="utf-8") as f:
    # get all of the race times and distances
    lines = f.readlines()
    
    timeLine = lines[0]
    timeSplit = timeLine.split(":")
    timeStringList = list(filter(None,timeSplit[1].split(" ")))

    distanceLine = lines[1]
    distancesSplit = distanceLine.split(":")
    distancesStringList = list(filter(None,distancesSplit[1].split(" ")))

    # we are going to multiply so our base value is 1
    ret = 1 
    for i in range(len(timeStringList)):
        # for each race solve the quadratic equeation to get the min and max value you would get a win at
        # c is 1+distance since we must win
        roots = quadraticSolver(1,(-1*int(timeStringList[i])),int(distancesStringList[i])+1)
        print(roots[0])
        print(roots[1])
        print((math.floor(roots[0])-math.ceil(roots[1])+1))
        ret *= (math.floor(roots[0])-math.ceil(roots[1])+1)
    print(ret)


