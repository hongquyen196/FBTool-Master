import logging
import re

from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
from selenium.webdriver.remote.webdriver import WebDriver
from selenium.webdriver.common.action_chains import ActionChains

from selenium_utils import common

logger = logging.getLogger(__name__)
logger.setLevel(logging.INFO)

_CHROME_DRIVER = '/Users/qhle/Documents/Freelancer/FBTool-master/FBExecution/Python/lib/chromedriver'
_PROFILE_PATH = '/Users/qhle/Documents/Freelancer/FBTool-master/FBExecution/Python/profile'
_PROFILE_NAME = 'Profile 1'
_PROXY = "11.456.448.110:8080"
_USERNAME = 'be.chuotchui'

_PAGE = "https://www.facebook.com/aothunvnchatdep"
_CONTENTS = [
    "Chất lượng tốt. giá cả rất hợp lí.\\nLần tới sẽ ủng hộ ạ. \😁",
    "Nhận dc hàng rất ưng ý ạ, chất vải đẹp, mềm mịn giá cả hợp lý sẽ ủng hộ nữa \😌",
    "Mới nhận dc hàng rất ưng ý ạ, chất vải đẹp, mềm mịn giá cả hợp lý sẽ ủng hộ. \😂"
]
_ATTACHMENTS = [
    "/Users/qhle/Documents/Freelancer/FBTool-master/FBExecution/Python/test/photo1.jpeg",
    # "/Users/qhle/Documents/Freelancer/FBTool-master/FBExecution/Python/test/photo2.png",
    # "/Users/qhle/Documents/Freelancer/FBTool-master/FBExecution/Python/test/photo3.png",
    # "/Users/qhle/Documents/Freelancer/FBTool-master/FBExecution/Python/test/photo4.png"
]

INJECT_CREATEYOURPOSTREVIEW = '/Users/qhle/Documents/Freelancer/FBTool-master/FBScript/createYourPostReview.js'
INJECT_GETYOURPOSTREVIEW = '/Users/qhle/Documents/Freelancer/FBTool-master/FBScript/getYourPostReview.js'


BUTTON_CREATE_POST = (
    By.XPATH, '//div[@id="MComposer"]//div[@role="button"][1]')
INPUT_PHOTO = (
    By.ID, 'photo_input')
INPUT_PHOTO_IDS = (
    By.XPATH, '//input[contains(@name, "photo_ids")]')
BUTTON_YES_LOCATOR = (
    By.XPATH, '//div[contains(@aria-label, "Yes") or contains(@aria-label, "Có") and @role="button"]')
EDITOR_RECOMMEND_LOCATOR = (
    By.XPATH, '//div[contains(@aria-describedby, "placeholder") and @contenteditable="true" and @role="textbox"]')
BUTTON_POST_LOCATOR = (
    By.XPATH, '//div[contains(@aria-label, "Post") or contains(@aria-label, "Đăng") and @role="button"]')
YOUR_POSTS = (
    By.XPATH, '//a[contains(@href,"https://www.facebook.com/{0}/posts/")]'.format(_USERNAME))

options = Options()
options.add_argument('--start-maximized')
options.add_argument('--user-data-dir=%s' % _PROFILE_PATH)
options.add_argument('--profile-directory=%s' % _PROFILE_NAME)
# options.add_argument('--proxy-server=%s' % _PROXY)

class Facebook:
    """
    Facebook automation tools
    """

    def __init__(self, driver: WebDriver):
        self.driver = driver

    def upload_private_attachment(self, attachments):
        """
        Upload private attachment
        """
        self.driver.get("https://m.facebook.com")

        common.click(self.driver, BUTTON_CREATE_POST)

        for path in attachments:
            common.send(self.driver, INPUT_PHOTO, path, sleep=1)

        all_photo_elements = common.find(
            self.driver, INPUT_PHOTO_IDS, number=len(attachments))

        photo_ids = []
        for el in all_photo_elements:
            fbid = el.get_attribute('value')
            photo_ids.append(fbid)

        print('photo_ids', photo_ids)
        logger.info('upload_private_attachment done.')

        return photo_ids

    def review_page(self, page, content, attachments=[]):
        """
        Reviews fanpage
        """
        logger.info('reviews_page: %s', page)
        try:
            # Upload attachment to get photo_ids
            photo_ids = self.upload_private_attachment(attachments) if attachments else []
            # photo_ids = ['1780305108835541', '1780305102168875', '1780305215502197', '1780305252168860']

            reviews_url = page + '/reviews/?ref=page_internal'
            print('reviews_url', reviews_url)

            # Redirect to Reviews
            self.driver.get(reviews_url)

            # Click button "Yes" from Recommend
            common.click(self.driver, BUTTON_YES_LOCATOR)

            # Enter text into editor
            common.send(self.driver, EDITOR_RECOMMEND_LOCATOR,
                        '___REPLACEMENT_REVIEW_CONTENT___')

            with open(INJECT_CREATEYOURPOSTREVIEW, errors='ignore') as f:
                script = f.read()
                script = script.replace(
                    '___CONTENT___', '"%s"' % content)
                script = script.replace(
                    '___PHOTO_IDS___', str(photo_ids))
                self.driver.execute_script(script)

            # Click button "Post"
            common.click(self.driver, BUTTON_POST_LOCATOR, sleep=5)

            # Refresh page to get reviews
            self.driver.get(reviews_url)

            post_id = 0
            with open(INJECT_GETYOURPOSTREVIEW, errors='ignore') as f:
                script = f.read()
                script = script.replace(
                    '___USERNAME___', re.escape(_USERNAME))
                post_id = self.driver.execute_script(script)

            print('post_id', post_id)
            logger.info('review_page done.')

            return post_id

        except Exception as e:
            logger.error('Cannot reviews page due: %s', str(e))
            pass

    def comments_post(self, post, text, photo=''):
        """
        Comments post
        """
        logger.info('comments_post')

    def quit(self):
        """
        Close browser
        """
        try:
            self.driver.quit()
        except Exception:
            pass


if __name__ == '__main__':
    try:
        driver = webdriver.Chrome(
            executable_path=_CHROME_DRIVER,
            options=options)

        facebook = Facebook(driver)

        facebook.review_page(
            page=_PAGE,
            content=_CONTENTS[0],
            attachments=_ATTACHMENTS
            )
    except Exception as e:
        print(e)
        pass
