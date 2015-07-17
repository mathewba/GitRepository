# Getting date and time

import datetime

currentDate = datetime.date.today()
print (currentDate)

print (currentDate.strftime('%d %b %Y')) # prints 18 July 2015
print (currentDate.strftime('%d %b %y')) # prints 18 July 15
print (currentDate.strftime('%d %b, %Y')) # prints 18 July, 2015

# prints Please attend the wedding ceremony on Saturday 18 Jul, 2015
print (currentDate.strftime('please attend the wedding ceremony on %a %d %b, %y')) 

#prints please attend the wedding ceremony on saturday 18 jul, 1999
print (currentDate.strftime('please attend the wedding ceremony on %a %d %b, 1999'))


print ('---------------------------------------------------------------')

birthday = input('Enter your birthday dd mm yyyy ')
birthday = datetime.datetime.strptime(birthday, '%d %b %Y').date()
print(birthday)

days = birthday - currentDate # calculates how many days to my next birthday
print (days.days)


# Playing with time
# prints 02:16:25 AM
currentTime = datetime.datetime.now()
print (currentTime.strftime('%H:%M:%S %p'))











