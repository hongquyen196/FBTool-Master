from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from multiprocessing import Process
import time
import json
import sys
import os
import platform

__location__ = os.path.realpath(os.path.join(os.getcwd(), os.path.dirname(__file__)))

_CHROME_DRIVER = os.path.join(
    __location__,
    "_CHROME_DRIVER",
    "chromedriver.exe" if platform.system() == "Windows" else "chromedriver",
)

_PROFILE_PATH = os.path.join(
        __location__,
        "_CHROME_PROFILE",
        "WINDOWS" if platform.system() == "Windows" else "OSX",
    )
_PROFILE_NAME = "100023764063810"

# The main process calls this function to create the driver instance.
def createDriverInstance():
    options = Options()
    options.add_argument("--user-data-dir=%s" % _PROFILE_PATH)
    options.add_argument("--profile-directory=%s" % _PROFILE_NAME)
    options.add_argument('disable-infobars')
    driver = webdriver.Chrome(_CHROME_DRIVER, chrome_options=options)
    return driver

# # Called by the second process only.
# def secondProcess(executor_url, session_id):
#     options = Options()
#     options.add_argument("--disable-infobars")
#     options.add_argument("--enable-file-cookies")
#     capabilities = options.to_capabilities()
#     same_driver = webdriver.Remote(command_executor=executor_url, desired_capabilities=capabilities)
#     same_driver.close()
#     same_driver.session_id = session_id
#     same_driver.get("https://www.wikipedia.org")
#     time.sleep(40)
#     same_driver.quit()

if __name__ == '__main__':
    driver = createDriverInstance()
    driver.get("https://google.com")
    time.sleep(40)

    # # Pass the driver session and command_executor to the second process.
    # p = Process(target=secondProcess, args=(driver.command_executor._url,driver.session_id))
    # p.start()