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
    timeString = ""
    for char in timeSplit[1]:
        if char.isdigit():
            timeString+=char

    distanceLine = lines[1]
    distancesSplit = distanceLine.split(":")
    distanceString = ""
    for char in distancesSplit[1]:
        if char.isdigit():
            distanceString+=char

    # we are going to multiply so our base value is 1
    ret = 1 
    
    # for each race solve the quadratic equeation to get the min and max value you would get a win at
    # c is 1+distance since we must win
    roots = quadraticSolver(1,(-1*int(timeString)),int(distanceString)+1)
    print(roots[0])
    print(roots[1])
    print((math.floor(roots[0])-math.ceil(roots[1])+1))
    ret *= (math.floor(roots[0])-math.ceil(roots[1])+1)
    print(ret)


