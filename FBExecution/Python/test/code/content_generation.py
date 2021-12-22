import os
import sys

import emoji

print("Argument List:", str(sys.argv))

__location__ = os.path.realpath(os.path.join(os.getcwd(), os.path.dirname(__file__)))


fileName = os.path.join(__location__, "test/data/1.txt")
contents = None

if len(sys.argv) > 1:
    fileName = sys.argv[1]

# search your emoji
def is_emoji(s):
    return s in emoji.UNICODE_EMOJI_ENGLISH

# add space near your emoji
def add_backslash(text):
    return "".join("\\" + char if is_emoji(char) else char for char in text).strip()

if __name__ == "__main__":
    # print(bool(emoji.get_emoji_regexp().search("😂😂😂")))
    # print(emoji.emoji_lis("😂😂😂"))
    # sentences = ["HiRob😂", "swiggy", "😡😡"]
    with open(fileName, mode="rt+", errors="ignore", encoding="utf-8") as f:
        contents = f.readlines()
        results = [add_backslash(text) for text in contents]
        print(results)
        f.writelines(results)
