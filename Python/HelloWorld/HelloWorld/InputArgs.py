import sys

from sys import argv

# input InputArgs.py Baiju John Mathew
numofinputs = len(sys.argv)

print ('%d is the number of inputs' %numofinputs)

# Conditional expressions
if numofinputs < 5 : 
    print ("Not enough arguments\nGood BYE")
    exit
else :
    print ("WELCOME")
    print ("HELLO BAIJU")

temp = 0
while numofinputs > 0 :
    print ('%d argument is ' % temp + sys.argv[temp])
    temp = temp + 1
    numofinputs = numofinputs - 1


#print('Number of arguments is %d' % numofinputs)

#print('Argument list : ' + str(argv))

#print ('Name of the script is ' + argv.pop(1))

#print ('Coder Name is ' + argv.pop(1) + ' ' + argv.pop(2))

