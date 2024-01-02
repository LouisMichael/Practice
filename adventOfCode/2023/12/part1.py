def posCombo(puzzelPos, solvePos, puzzelInput, solveInput):
    # I will want to 

with open("part1Input.txt","r", encoding="utf-8") as f:
    # I think I can try it as a backtracking task
    lines = f.readlines()
    for line in lines:
        unknownAndKnown = line.split(' ')
