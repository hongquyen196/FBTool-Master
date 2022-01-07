import json
import sys
import os
import glob
import random

# START LOAD PARAMETERS ============================================================================================================

# Get current location
__location__ = os.path.realpath(os.path.join(os.getcwd(), os.path.dirname(__file__)))

# Default parameters
_PHOTO_FILE_PATH = os.path.join(
    __location__,
    "test",
    "photo/*"
)
_CONTENT_FILE_PATH = os.path.join(
    __location__,
    "test",
    "content.txt"
)

if __name__ == "__main__":
    photos = glob.glob(_PHOTO_FILE_PATH)
    contents = []
    with open(_CONTENT_FILE_PATH, mode="r", encoding="utf-8") as f:
        lines = f.readlines()
        for index, line in enumerate(lines):
            if "|" not in line:
                lines[index] = line.strip() + "|" + ",".join(random.sample(photos, random.randint(1, 5))) + "\n"
        print(lines)

    with open("test.txt", mode="w", encoding="utf-8") as f:
            for line in lines:
                f.write(line)