import json
import re
import sys
import os

from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
from selenium.webdriver.remote.webdriver import WebDriver

from selenium_utils import common

print('Argument List:', str(sys.argv))
parameters = {}
if len(sys.argv) > 1:
    with open(sys.argv[1], errors='ignore', encoding="utf-8") as f:
        parameters = json.load(f)
else:
    print('Need to add parameters file.')
    exit()
    # with open(os.path.join(sys.path[0], 'parameters.json'), errors='ignore') as f:
    #     parameters = json.load(f)

_CHROME_DRIVER = parameters['_CHROME_DRIVER']
_PROFILE_PATH = parameters['_PROFILE_PATH']
_PROFILE_NAME = parameters['_PROFILE_NAME']
_HEADLESS = parameters['_HEADLESS']
_PROXY = parameters['_PROXY']
_USERNAME = parameters['_USERNAME']
_PAGE = parameters['_PAGE']
_CONTENTS = parameters['_CONTENTS']
_ATTACHMENTS = parameters['_ATTACHMENTS']
_INJECTED_CREATE_YOUR_POST_REVIEW = parameters['_INJECTED_CREATE_YOUR_POST_REVIEW']
_INJECTED_GET_YOUR_POST_REVIEW = parameters['_INJECTED_GET_YOUR_POST_REVIEW']

print(_CHROME_DRIVER)
print(_PROFILE_PATH)
print(_PROFILE_NAME)
print(_HEADLESS)
print(_PROXY)
print(_USERNAME)
print(_PAGE)
print(_CONTENTS)
print(_ATTACHMENTS)
print(_INJECTED_CREATE_YOUR_POST_REVIEW)
print(_INJECTED_GET_YOUR_POST_REVIEW)


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
    
service = Service(_CHROME_DRIVER)
options = Options()
options.add_argument('--user-data-dir=%s' % _PROFILE_PATH)
options.add_argument('--profile-directory=%s' % _PROFILE_NAME)
# if _HEADLESS:
#     options.add_argument('--headless')
#     options.add_argument('--disable-gpu')
#     options.add_argument('--remote-debugging-port=45447')
if _PROXY:
    options.add_argument('--proxy-server=%s' % _PROXY)


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

        print('title', self.driver.title)

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
        print('upload_private_attachment done.')

        return photo_ids

    def review_page(self, page, content, attachments=[]):
        """
        Reviews fanpage
        """
        print('reviews_page: %s' % page)
        try:
            # Upload attachment to get photo_ids
            photo_ids = self.upload_private_attachment(
                attachments) if attachments else []
            # photo_ids = ['1780305108835541', '1780305102168875', '1780305215502197', '1780305252168860']

            reviews_url = page + '/reviews/?ref=page_internal'

            print('title', self.driver.title)
            print('reviews_url', reviews_url)

            # Redirect to Reviews
            self.driver.get(reviews_url)

            # Click button "Yes" from Recommend
            common.click(self.driver, BUTTON_YES_LOCATOR)

            # Enter text into editor
            common.send(self.driver, EDITOR_RECOMMEND_LOCATOR,
                        '___REPLACEMENT_REVIEW_CONTENT___')

            with open(_INJECTED_CREATE_YOUR_POST_REVIEW, errors='ignore') as f:
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
            with open(_INJECTED_GET_YOUR_POST_REVIEW, errors='ignore') as f:
                script = f.read()
                script = script.replace(
                    '___USERNAME___', re.escape(_USERNAME))
                post_id = self.driver.execute_script(script)

            print('post_id', post_id)
            print('review_page done.')

            return post_id

        except Exception as e:
            print('Cannot reviews page due: %s', str(e))
            pass

    def comments_post(self, post, text, photo=''):
        """
        Comments post
        """
        print('comments_post')

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
            service=service,
            options=options)

        if _HEADLESS:
            driver.minimize_window()

        facebook = Facebook(driver)
        facebook.review_page(
            page=_PAGE,
            content=_CONTENTS[0],
            attachments=_ATTACHMENTS
        )
        facebook.quit()
    except Exception as e:
        print(e)
        pass
