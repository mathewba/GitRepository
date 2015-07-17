# Area of a rectangle
length = 50
breadth = 2

area = length * breadth

print ("Area of the reactangle is %d" % area) # Throws error as area is a number. + is only for strings.

# %d,%f is used for numbers and float. More like C++.

print ("My fav number is %6d" %2) # Allignment


# Adding zeroes before the number
print ("My float number is %02f" %4)

# 3 arguments
# volume of a rectangle
# Find the l,b and h


# Any input is a string
# To perform artihmetic operations, it has to be converted to int
length = int(input('Enter the length - \n'))
breadth =int(input('Enter the breadth - \n'))
height = int(input('Enter the height - \n'))

volume=length * breadth * height

# split long lines by using '\'
print ("volume of a triangle with length {0:d} breadth {1:d} height {2:d} is {3:d}".\
    format(length,breadth,height,volume))
