import sys, logging

# include the logging module

from rainbow_logging_handler import RainbowLoggingHandler

def main_func():
    # setup `logging` module
    logger = logging.getLogger('test_logging')
    logger.setLevel(logging.DEBUG)
    formatter = logging.Formatter("[%(asctime)s] %(name)s %(funcName)s():%(lineno)d\t%(message)s")  # same as default

    # setup `RainbowLoggingHandler`
    handler = RainbowLoggingHandler(sys.stderr, color_funcName=('black', 'yellow', True))
    handler.setFormatter(formatter)
    logger.addHandler(handler)

    logger.debug("debug msg")
    logger.info("info msg")
    logger.warn("warn msg")
    logger.error("error msg")
    logger.critical("critical msg")

    try:
        raise RuntimeError("Opa!")
    except Exception as e:
        logger.exception(e)

if __name__ == '__main__':
    main_func()