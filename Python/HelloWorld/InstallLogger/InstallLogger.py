import sys, logging, os
import os.path

from sys import argv

# include the logging module

from rainbow_logging_handler import RainbowLoggingHandler

def main_func():

    # Check the number of inputs
    numofinputs = len(sys.argv)

    # Conditional expressions
    if numofinputs > 5 :
        print ("Invalid arguments \nGood BYE")
    else :
        # Get the input arguments
        filename = argv.pop(1) # EXE name, File Name, Module Name
        operation = argv.pop(1) # DEBUG, INFO, WARN, ERROR, CRITICAL, EXCEPTION
        message = argv.pop(1) # Message to be printed
        logFile = argv.pop(1) # Log file

        # setup `logging` module
        logger = logging.getLogger(filename)
        fileHandler = logging.FileHandler('Logger.log')
        logger.setLevel(logging.INFO)
        formatter = logging.Formatter("[%(asctime)s] [%(name)s] : %(message)s")

        # setup `RainbowLoggingHandler`
        handler = RainbowLoggingHandler(sys.stderr, color_name=('grey', None , True),color_asctime=('green', None  , True))
        handler.setFormatter(formatter)
        fileHandler.setFormatter(formatter)
        logger.addHandler(fileHandler)
        logger.addHandler(handler)

        if operation == 'DEBUG' :
            logger.debug(message)
        if operation == 'INFO' :
            logger.info(message)
        if operation == 'WARN' :
            logger.warn(message)
        if operation == 'ERROR' :
            logger.error(message)
        if operation == 'CRITICAL' :
            logger.critical(message)
        if operation == 'EXCEPTION' :
            raise RuntimeError("InstallException!")
            logger.exception(message)
            logger.exception(e)

if __name__ == '__main__':
    main_func()