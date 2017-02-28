import sys
import imaplib
import getpass
import email
import email.header
import datetime

EMAIL_ACCOUNT = "baiju.mathew@autodesk.com"
EMAIL_FOLDER = "inbox"
OWNER = "baiju.mathew@autodesk.com"
COMMAND_FILE = open("output.txt","w")

def process_mailbox(M):
    rv, data = M.login(EMAIL_ACCOUNT, getpass.getpass())

    rv, data = M.search(None, "From", (OWNER))
    if rv != 'OK':
        print("No messages found!")
        return
    for num in data[0].split():
        rv, data = M.fetch(num, '(RFC822)')
        if rv != 'OK':
            print ("ERROR getting message")
            return
        msg = email.message_from_string(data[0][1])
        decode = email.header.decode_header(msg['Subject'])[0]
        subject = unicode(decode[0])
        print ("Message %s: %s" % (num, subject))
        print ("My float number is %02f" %4)
        COMMAND_FILE.write('%s' % (subject))
        COMMAND_FILE.close()
#print 'Raw Date:', msg['Date']
#M = imaplib.IMAP4_SSL('imap.gmail.com')
#try:
#    rv, data = M.login(EMAIL_ACCOUNT, getpass.getpass())
#except imaplib.IMAP4.error:
#    print "LOGIN FAILED!!! "
#    sys.exit(1)
#print rv, data
#rv, mailboxes = M.list()
#if rv == 'OK':
#    print "Mailboxes:"
#    print mailboxes
#rv, data = M.select(EMAIL_FOLDER)
#if rv == 'OK':
#    print "Processing mailbox...\n"
#    process_mailbox(M)
#    M.select('INBOX')  # select all trash
#    M.store("1:*", '+FLAGS', '\\Deleted')  #Flag all Trash as Deleted
#    M.expunge()
#    M.close()
#else:
#    print "ERROR: Unable to open mailbox ", rv

#M.logout()
#start_command = eval(open("output.txt").read())

