import time
import json
import sys
import os
import platform

from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
from selenium.webdriver.remote.webdriver import WebDriver

from selenium_utils import common
from selenium_utils import element
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

# START SELENIUM LOCATOR ============================================================================================================

BUTTON_CREATE_POST_LOCATOR = (
    By.XPATH,
    '//div[@id="MComposer"]//div[@role="button"][1]',
)
INPUT_PHOTO_LOCATOR = (By.ID, "photo_input")
INPUT_PHOTO_IDS_LOCATOR = (By.XPATH, '//input[contains(@name, "photo_ids")]')
BUTTON_YES_LOCATOR = (
    By.XPATH,
    '//div[contains(@aria-label, "Yes") or contains(@aria-label, "Có") and @role="button"]',
)
EDITOR_RECOMMEND_LOCATOR = (
    By.XPATH,
    '//div[contains(@aria-describedby, "placeholder") and @contenteditable="true" and @role="textbox"]',
)
BUTTON_POST_LOCATOR = (
    By.XPATH,
    '//div[contains(@aria-label, "Post") or contains(@aria-label, "Đăng") and @role="button"]',
)

# END SELENIUM LOCATOR ============================================================================================================

# Setup driver
options = Options()
options.add_argument("--user-data-dir=%s" % os.path.join(_PROFILE_PATH, _PROFILE_NAME))
options.add_argument("--disable-notifications")
class Facebook:
    """
    Facebook automation tools
    """

    def __init__(self, driver: WebDriver):
        driver.get("https://m.facebook.com/home.php")
        print("title", driver.title)
        element.wait_until_condition(driver, lambda d: "https://m.facebook.com/home.php" in d.current_url, 10 * 60)
        self.driver = driver

    def upload_private_attachment(self, attachments):
        """
        Upload private attachment
        """
        photo_ids = []
        try:
            self.driver.get("https://m.facebook.com/home.php")

            common.click(self.driver, BUTTON_CREATE_POST_LOCATOR)

            for path in attachments:
                common.send(self.driver, INPUT_PHOTO_LOCATOR, path, sleep=1)

            all_photo_elements = common.find(
                self.driver, INPUT_PHOTO_IDS_LOCATOR, number=len(attachments)
            )

            for el in all_photo_elements:
                fbid = el.get_attribute("value")
                photo_ids.append(fbid)

            print("photo_ids", photo_ids)
            print("upload_private_attachment done.")
        except Exception as e:
            print("Cannot upload attachment due: %s" % str(e))
            pass
        return photo_ids

    def review_page(self, page, content, attachments=[]):
        """
        Reviews fanpage
        """
        print("reviews_page: %s" % page)
        try:
            # Upload attachment to get photo_ids
            photo_ids = (
                self.upload_private_attachment(attachments) if attachments else []
            )
            # photo_ids = ['1780305108835541', '1780305102168875', '1780305215502197', '1780305252168860']

            reviews_url = page + "/reviews/?ref=page_internal"

            print("reviews_url", reviews_url)

            # Redirect to Reviews
            self.driver.get(reviews_url)

            # Click button "Yes" from Recommend
            common.click(self.driver, BUTTON_YES_LOCATOR)

            # Enter text into editor
            common.send(
                self.driver,
                EDITOR_RECOMMEND_LOCATOR,
                "___REPLACEMENT_REVIEW_CONTENT___",
            )

            with open(_INJECTED_CREATE_YOUR_POST_REVIEW, errors="ignore") as f:
                script = f.read()
                script = script.replace("___CONTENT___", '"%s"' % content)
                script = script.replace("___PHOTO_IDS___", str(photo_ids))
                self.driver.execute_script(script)

            # Click button "Post"
            common.click(self.driver, BUTTON_POST_LOCATOR, sleep=5)

            # Refresh page to get reviews
            self.driver.get(reviews_url.replace("www.facebook.com", "m.facebook.com"))

            post_id = 0
            with open(_INJECTED_GET_YOUR_POST_REVIEW, errors="ignore") as f:
                script = f.read()
                post_id = self.driver.execute_script(script)

            print("post_id", post_id)
            print("review_page done.")

            return post_id

        except Exception as e:
            print("Cannot reviews page due: %s" % str(e))
            pass

    def comments_post(self, post, text, photo=""):
        """
        Comments post
        """
        print("comments_post")

    def quit(self):
        """
        Close browser
        """
        try:
            self.driver.quit()
        except Exception:
            pass


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
        
        if _HEADLESS:
            driver.minimize_window()

        facebook = Facebook(driver)

        content = common.add_backslashes(_CONTENTS[0])
        page = _PAGE
        attachments = _ATTACHMENTS

        facebook.review_page(page, content, attachments)

    except Exception as e:
        print(e)
        pass
    # Wait 5 minutes to close
    print("Wait 5 minutes to close")
    time.sleep(5 * 60)
    driver.quit()

