# --- Day 15: Beacon Exclusion Zone ---
# You feel the ground rumble again as the distress signal leads you to a large network of subterranean tunnels. You don't have time to search them all, but you don't need to: your pack contains a set of deployable sensors that you imagine were originally built to locate lost Elves.

# The sensors aren't very powerful, but that's okay; your handheld device indicates that you're close enough to the source of the distress signal to use them. You pull the emergency sensor system out of your pack, hit the big button on top, and the sensors zoom off down the tunnels.

# Once a sensor finds a spot it thinks will give it a good reading, it attaches itself to a hard surface and begins monitoring for the nearest signal source beacon. Sensors and beacons always exist at integer coordinates. Each sensor knows its own position and can determine the position of a beacon precisely; however, sensors can only lock on to the one beacon closest to the sensor as measured by the Manhattan distance. (There is never a tie where two beacons are the same distance to a sensor.)

# It doesn't take long for the sensors to report back their positions and closest beacons (your puzzle input). For example:

# Sensor at x=2, y=18: closest beacon is at x=-2, y=15
# Sensor at x=9, y=16: closest beacon is at x=10, y=16
# Sensor at x=13, y=2: closest beacon is at x=15, y=3
# Sensor at x=12, y=14: closest beacon is at x=10, y=16
# Sensor at x=10, y=20: closest beacon is at x=10, y=16
# Sensor at x=14, y=17: closest beacon is at x=10, y=16
# Sensor at x=8, y=7: closest beacon is at x=2, y=10
# Sensor at x=2, y=0: closest beacon is at x=2, y=10
# Sensor at x=0, y=11: closest beacon is at x=2, y=10
# Sensor at x=20, y=14: closest beacon is at x=25, y=17
# Sensor at x=17, y=20: closest beacon is at x=21, y=22
# Sensor at x=16, y=7: closest beacon is at x=15, y=3
# Sensor at x=14, y=3: closest beacon is at x=15, y=3
# Sensor at x=20, y=1: closest beacon is at x=15, y=3
# So, consider the sensor at 2,18; the closest beacon to it is at -2,15. For the sensor at 9,16, the closest beacon to it is at 10,16.

# Drawing sensors as S and beacons as B, the above arrangement of sensors and beacons looks like this:

#                1    1    2    2
#      0    5    0    5    0    5
#  0 ....S.......................
#  1 ......................S.....
#  2 ...............S............
#  3 ................SB..........
#  4 ............................
#  5 ............................
#  6 ............................
#  7 ..........S.......S.........
#  8 ............................
#  9 ............................
# 10 ....B.......................
# 11 ..S.........................
# 12 ............................
# 13 ............................
# 14 ..............S.......S.....
# 15 B...........................
# 16 ...........SB...............
# 17 ................S..........B
# 18 ....S.......................
# 19 ............................
# 20 ............S......S........
# 21 ............................
# 22 .......................B....
# This isn't necessarily a comprehensive map of all beacons in the area, though. Because each sensor only identifies its closest beacon, if a sensor detects a beacon, you know there are no other beacons that close or closer to that sensor. There could still be beacons that just happen to not be the closest beacon to any sensor. Consider the sensor at 8,7:

#                1    1    2    2
#      0    5    0    5    0    5
# -2 ..........#.................
# -1 .........###................
#  0 ....S...#####...............
#  1 .......#######........S.....
#  2 ......#########S............
#  3 .....###########SB..........
#  4 ....#############...........
#  5 ...###############..........
#  6 ..#################.........
#  7 .#########S#######S#........
#  8 ..#################.........
#  9 ...###############..........
# 10 ....B############...........
# 11 ..S..###########............
# 12 ......#########.............
# 13 .......#######..............
# 14 ........#####.S.......S.....
# 15 B........###................
# 16 ..........#SB...............
# 17 ................S..........B
# 18 ....S.......................
# 19 ............................
# 20 ............S......S........
# 21 ............................
# 22 .......................B....
# This sensor's closest beacon is at 2,10, and so you know there are no beacons that close or closer (in any positions marked #).

# None of the detected beacons seem to be producing the distress signal, so you'll need to work out where the distress beacon is by working out where it isn't. For now, keep things simple by counting the positions where a beacon cannot possibly be along just a single row.

# So, suppose you have an arrangement of beacons and sensors like in the example above and, just in the row where y=10, you'd like to count the number of positions a beacon cannot possibly exist. The coverage from all sensors near that row looks like this:

#                  1    1    2    2
#        0    5    0    5    0    5
#  9 ...#########################...
# 10 ..####B######################..
# 11 .###S#############.###########.
# In this example, in the row where y=10, there are 26 positions where a beacon cannot be present.

# Consult the report from the sensors you just deployed. In the row where y=2000000, how many positions cannot contain a beacon?
SENSOR_DISTANCE_LIST = []
with open("input.txt", "r", encoding="utf-8") as f:
    LOOK_LINE = 2000000
    lines = f.readlines()
    
    for line in lines:
        line = line.strip()
        # Sensor at x=2, y=18: closest beacon is at x=-2, y=15
        SENSOR_BECON_STRING = line.split(':')
        # print(SENSOR_BECON)
        SENSOR_SPLIT = SENSOR_BECON_STRING[0].split(',')
        # print(SENSOR_SPLIT)
        SENSOR_X = int(SENSOR_SPLIT[0].split('Sensor at x=')[1])
        # print(SENSOR_X)
        SENSOR_Y = int(SENSOR_SPLIT[1].split(' y=')[1])
        # print(SENSOR_Y)
        BECON_SPLIT = SENSOR_BECON_STRING[1].split(',')
        BECON_X = int(BECON_SPLIT[0].split(' closest beacon is at x=')[1])
        # print(BECON_X)
        BECON_Y = int(BECON_SPLIT[1].split(' y=')[1])
        # print(BECON_Y)
        SENSOR = (SENSOR_X, SENSOR_Y)
        BECON = (BECON_X, BECON_Y)
        DISTANCE = abs(SENSOR_X-BECON_X) + abs(SENSOR_Y-BECON_Y)
        
        SENSOR_DISTANCE_LIST.append((SENSOR,DISTANCE))
# with a max distance and a list of sensors + distnaces we can index over each sensor and
# add the locations that can not have decoys and are on
# the target row
    NO_SENSOR_SET = set()
    for SENSOR_DISTANCE in SENSOR_DISTANCE_LIST:
        ((SENSOR_X, SENSOR_Y), DISTANCE) = SENSOR_DISTANCE
        OFFSET = abs(LOOK_LINE-SENSOR_Y)
        if OFFSET > DISTANCE:
            continue
        for val in range(SENSOR_X-(DISTANCE-OFFSET), SENSOR_X+(DISTANCE-OFFSET)):
            NO_SENSOR_SET.add(val)
    print(len(NO_SENSOR_SET))

# --- Part Two ---
# Your handheld device indicates that the distress signal is coming from a beacon nearby. The distress beacon is not detected by any sensor, but the distress beacon must have x and y coordinates each no lower than 0 and no larger than 4000000.

# To isolate the distress beacon's signal, you need to determine its tuning frequency, which can be found by multiplying its x coordinate by 4000000 and then adding its y coordinate.

# In the example above, the search space is smaller: instead, the x and y coordinates can each be at most 20. With this reduced search area, there is only a single position that could have a beacon: x=14, y=11. The tuning frequency for this distress beacon is 56000011.

# Find the only possible position for the distress beacon. What is its tuning frequency?

# So I tink I need to get this to run over ranges instead of specific values, what is the best way to do that? I think maybe we can use an interval tree for each line, we add each sensors ranges to each line and then add the search space to the tree, if it 
# needs to merge that means there is a coordinate that is not accounted for in the search space.
# class Node:
#     def __init__(self, val, left, right):
#         self.left = left
#         self.right = right
#         self.val = val
# class IntervalTree:
#     def __init__(self):
#         self.root = None
#     def addRange(self, lower, upper):
#         if self.root == None:
#             self.root = Node((lower, upper), None, None)
#         else:
#             if 
ranges = []
x_solve = 0
y_solve = 0
for val in range(4000000):
    if len(ranges) > 0:
        ranges.sort(key=lambda x:x[0])
        # print(ranges)
        min = ranges[0][0]
        max = ranges[0][1]
        # this will miss holes on the right side
        for i, range in enumerate(ranges):
            if range[0] > max + 1:
                x_solve = max + 1
                y_solve = val-1
                print("hole around " + str(range[0]) + " with max: " + str(max))
                print("y: " + str(val-1))
            if range[1] > max:
                max = range[1] 
    ranges = []
    for SENSOR_DISTANCE in SENSOR_DISTANCE_LIST:
       
        ((SENSOR_X, SENSOR_Y), DISTANCE) = SENSOR_DISTANCE
        OFFSET = abs(val-SENSOR_Y)
        if OFFSET > DISTANCE:
            continue
        ranges.append((SENSOR_X-(DISTANCE-OFFSET), SENSOR_X+(DISTANCE-OFFSET)))
print("tuning frequancy: " + str(x_solve*4000000+y_solve))
    
        