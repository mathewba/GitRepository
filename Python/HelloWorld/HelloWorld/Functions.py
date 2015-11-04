import sys

from sys import argv

# Functions for fun

# accept 2 numbers and add them and print the sum
# accept 2 strings and concatenat them

def sum(*args):
    number1, number2 = args
    sumoftwonumbers = number1 + number2
    return sumoftwonumbers

def concat(*args):
    string1, string2 = args
    concatenatedstrings = string1 + string2
    return concatenatedstrings

print (sum (1,2))
print (concat("Learn", " Python the Hard Way"))

# Accept user input
print ("Enter the first string"),
strings1 = input() # raw_input has been modified to input in Python 3
print ("Enter the second string"),
strings2 = input() # raw_input has been modified to input in Python 3
print (concat(strings1, strings2))