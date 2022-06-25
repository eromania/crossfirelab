#!/usr/local/bin/python3

from random import randint

class Parachute:
    def __init__(self, id, dropLocation):
        self.id = f'parachute-{id}' 
        self.location = dropLocation

class Robot:
    def __init__(self, id):
        self.id = id
        self.location = randint(-500,500) 
        self.parachute = Parachute(self.id, self.location)
        self.foundOtherParachute = False

    def get_location(self):
        print(f'robot-{self.id} location : {self.location}')
        return self.location

    def move_left(self):
        step = 1
        if(self.foundOtherParachute):
            step = 2
        self.location -= step
        print(f'robot-{self.id} moves to the left {step} step, new location : {self.location}')
        print(f'robot-{self.id} parachute location : {self.parachute.location}')
    
    def check_robots_locations(self, otherRobotLocation):
        isMeet = self.location == otherRobotLocation
        print(f'robot-{self.id} and other robot at the same location? : {isMeet}')
        return isMeet


    def check_parachute_found(self, otherParachuteLocation):
        self.foundOtherParachute = self.location == otherParachuteLocation
        if(self.foundOtherParachute):
            print(f'{self.id} found other parachute : YES')
        return self.foundOtherParachute


def move_left_to_find(r1, r2):
    while(r1.check_robots_locations(r2.get_location()) == False):
        r1.move_left()
        r2.move_left()

robot1 = Robot('01')
robot2 = Robot('02')

robot1.move_left()
robot2.move_left()

while(robot1.check_parachute_found(robot2.parachute.location) == False and robot2.check_parachute_found(robot1.parachute.location) == False):
    robot1.move_left()
    robot2.move_left()

if(robot1.check_parachute_found(robot2.parachute.location)):
    move_left_to_find(robot1,robot2)
elif(robot2.check_parachute_found(robot1.parachute.location)):
    move_left_to_find(robot2,robot1)

if(robot1.check_robots_locations(robot2.location) or robot2.check_robots_locations(robot1.location)):
    print('robots met')