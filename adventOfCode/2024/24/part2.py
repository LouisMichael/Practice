# in theory most of the work is just checking that each step goes into the correct part of the 2 bit adder circut it needs
# we know all of the x and y gates have to go into the correct places we then just need name their outputs
# there are just two layers to our circut, except there is no 44th bit output carry and no 0th bit input carry
carryWireName = ""
for addBit in range(1,45):
    xBitString = f'{addBit:02}x'
    yBitString = f'{addBit:02}y'
    halfAdder1XOrOutput = ""
    halfAdder1AndOutput = ""
    for gate in gates:
        if (gate[0] == xBitString or gate[0] == yBitString):
            if gate[1] == 'XOR':
                halfAdder1XOrOutput = gate[2]
            if gate[1] == 'AND':
                halfAdder1AndOutput = gate[2]