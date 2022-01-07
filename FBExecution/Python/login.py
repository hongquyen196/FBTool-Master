import json
import sys
import os
import platform

from selenium import webdriver
from selenium.webdriver.chrome.options import Options

from selenium_utils import common
from selenium_utils import proxy

# START LOAD PARAMETERS ============================================================================================================

# Get current location
__location__ = os.path.realpath(os.path.join(os.getcwd(), os.path.dirname(__file__)))

# Default parameters
_PARAMETER_FILE_PATH = os.path.join(
    __location__,
    "_REVIEW_PARAMETER",
    "parameters_windows.json" if platform.system() == "Windows" else "parameters.json",
)

# Get from arguments
if len(sys.argv) > 1:
    _PARAMETER_FILE_PATH = sys.argv[1]

print(_PARAMETER_FILE_PATH)

parameters = {}
with open(_PARAMETER_FILE_PATH, errors="ignore", encoding="utf-8") as f:
    parameters = json.load(f)

_CHROME_DRIVER = parameters["_CHROME_DRIVER"]
_PROFILE_PATH = parameters["_PROFILE_PATH"]
_PROFILE_NAME = parameters["_PROFILE_NAME"]
_HEADLESS = parameters["_HEADLESS"]
_PROXY = parameters["_PROXY"]
_USERNAME = parameters["_USERNAME"]
_PAGE = parameters["_PAGE"]
_CONTENTS = parameters["_CONTENTS"]
_ATTACHMENTS = parameters["_ATTACHMENTS"]
_INJECTED_CREATE_YOUR_POST_REVIEW = parameters["_INJECTED_CREATE_YOUR_POST_REVIEW"]
_INJECTED_GET_YOUR_POST_REVIEW = parameters["_INJECTED_GET_YOUR_POST_REVIEW"]

# Get default
if not _CHROME_DRIVER:
    _CHROME_DRIVER = os.path.join(
        __location__,
        "_CHROME_DRIVER",
        "chromedriver.exe" if platform.system() == "Windows" else "chromedriver",
    )
if not _PROFILE_PATH:
    _PROFILE_PATH = os.path.join(
        __location__,
        "_CHROME_PROFILE",
        "WINDOWS" if platform.system() == "Windows" else "OSX",
    )
if not _INJECTED_CREATE_YOUR_POST_REVIEW:
    _INJECTED_CREATE_YOUR_POST_REVIEW = os.path.join(
        __location__, "_REVIEW_JAVASCRIPT", "createYourPostReview.js"
    )
if not _INJECTED_GET_YOUR_POST_REVIEW:
    _INJECTED_GET_YOUR_POST_REVIEW = os.path.join(
        __location__, "_REVIEW_JAVASCRIPT", "getYourPostReview.js"
    )

print("_CHROME_DRIVER", _CHROME_DRIVER)
print("_PROFILE_PATH", _PROFILE_PATH)
print("_PROFILE_NAME", _PROFILE_NAME)
print("_HEADLESS", _HEADLESS)
print("_PROXY", _PROXY)
print("_USERNAME", _USERNAME)
print("_PAGE", _PAGE)
print("_CONTENTS", _CONTENTS)
print("_ATTACHMENTS", _ATTACHMENTS)
print("_INJECTED_CREATE_YOUR_POST_REVIEW", _INJECTED_CREATE_YOUR_POST_REVIEW)
print("_INJECTED_GET_YOUR_POST_REVIEW", _INJECTED_GET_YOUR_POST_REVIEW)

# END LOAD PARAMETERS ============================================================================================================

# Setup driver
options = Options()
options.add_argument("--no-sandbox")
options.add_argument("--user-data-dir=%s" % os.path.join(_PROFILE_PATH, _PROFILE_NAME))

# options.add_argument("--profile-directory=%s" % _PROFILE_NAME)
options.add_experimental_option("detach", True)

if __name__ == "__main__":
    try:
        if _PROXY:
            options = proxy.add_proxy(options=options, proxy=_PROXY)
        else:
            options.add_argument("--disable-extensions")
            options.add_argument("--hide-scrollbars")
            options.add_argument("--disable-gpu")
            options.add_argument("--no-proxy-server")

        driver = webdriver.Chrome(executable_path=_CHROME_DRIVER, options=options)
        driver.set_window_position(0, 0)
        driver.set_window_size(1024, 768)
        driver.get("https://m.facebook.com")
        if _HEADLESS:
            driver.minimize_window()
        
        while not common.is_browser_closed(driver):
            post_id = 0
            # with open(_INJECTED_GET_YOUR_POST_REVIEW, errors="ignore") as f:
            #     script = f.read()
            #     post_id = driver.execute_script(script)

            # print("post_id", post_id)
            
            # print(driver.title)

    except Exception as e:
        print(e)
        pass
