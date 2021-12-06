import sys
import json
import os

print('Argument List:', str(sys.argv))
parameters = {}
if len(sys.argv) > 1:
    with open(sys.argv[1], errors='ignore') as f:
        parameters = json.load(f)
else:
    with open(os.path.join(sys.path[0], 'parameters.json'), errors='ignore') as f:
        parameters = json.load(f)       

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
_INJECTED_GET_YOUR_POST_REVIEW =  parameters['_INJECTED_GET_YOUR_POST_REVIEW']

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
