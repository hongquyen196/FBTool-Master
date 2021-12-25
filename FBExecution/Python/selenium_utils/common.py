import time
import logging
import emoji

from selenium_utils import element
from selenium.common import exceptions

from selenium_utils.exception import ElementNotFound

logger = logging.getLogger(__name__)

_WAIT = 30


def click(driver, locator, wait_seconds=_WAIT, sleep=0):
    """
    Args:
      driver - Instance of WebDriver (Ie, Firefox, Chrome or Remote)
      locator - Used to find the element
      wait_seconds - Timeout 30 seconds
      sleep - Sleep 0 second after click
    """
    try:
        element_clickable = element.get_when_clickable(driver, locator, wait_seconds)
        element_clickable.click()
        time.sleep(sleep)
    except exceptions.TimeoutException as e:
        logger.error("No element found with %s", locator)
        raise ElementNotFound(e)


def send(driver, locator, value, wait_seconds=_WAIT, sleep=0):
    """
    Args:
      driver - Instance of WebDriver (Ie, Firefox, Chrome or Remote)
      locator - Used to find the element
      value - Data to send
      wait_seconds - Timeout 30 seconds
      sleep - Sleep 0 second after send keys
    """
    try:
        element_visible = element.get_when_visible(driver, locator, wait_seconds)
        element_visible.send_keys(value)
        time.sleep(sleep)
    except exceptions.TimeoutException as e:
        logger.error("No element found with %s", locator)
        raise ElementNotFound(e)


def find(driver, locator, number=1, wait_seconds=_WAIT):
    """
    Args:
      driver  - Instance of WebDriver (Ie, Firefox, Chrome or Remote)
      locator - Used to find all elements
      number  - Expected length of elements
      wait_seconds - Timeout 30 seconds
    """
    try:
        all_element_visible = element.get_when_number_of_elements_to_be(
            driver, locator, number, wait_seconds
        )
        return all_element_visible
    except exceptions.TimeoutException as e:
        logger.error("No element found with %s", locator)
        raise ElementNotFound(e)

def is_browser_closed(driver):
    """
    Args:
      driver  - Instance of WebDriver (Ie, Firefox, Chrome or Remote)
    """
    is_closed = False
    try:
        driver.title
    except Exception:
        is_closed = True
    return is_closed

# search your emoji
def is_emoji(s):
    return s in emoji.UNICODE_EMOJI_ENGLISH


# add backslashes before emoji
# add backslashes before newline characters
def add_backslashes(text):
    return (
        "".join("\\" + char if is_emoji(char) else char for char in text)
        .strip()
        .replace("\n", "\\n")
    )
