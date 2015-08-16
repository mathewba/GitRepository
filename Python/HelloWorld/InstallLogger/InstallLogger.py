import sys, logging

from sys import argv

# include the logging module

from rainbow_logging_handler import RainbowLoggingHandler

def main_func():

    # Check the number of inputs
    numofinputs = len(sys.argv)

    # Conditional expressions
    if numofinputs > 2 : 
        print ("Invalid arguments \nGood BYE")
    else :
        # setup `logging` module
        logger = logging.getLogger('test_logging')
        logger.setLevel(logging.DEBUG)
        formatter = logging.Formatter("[%(asctime)s] %(name)s %(funcName)s():%(lineno)d\t%(message)s")  # same as default

        # setup `RainbowLoggingHandler`
        handler = RainbowLoggingHandler(sys.stderr, color_funcName=('black', 'black', True))
        handler.setFormatter(formatter)
        logger.addHandler(handler)

        logger.debug("debug msg")
        logger.info("info msg")
        logger.warn("warn msg")
        logger.error("error msg")
        logger.critical("critical msg")

        try:
            raise RuntimeError("Aiyo!")
        except Exception as e:
            logger.exception(e)

if __name__ == '__main__':
    main_func()