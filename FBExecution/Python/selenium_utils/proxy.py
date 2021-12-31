import logging
import zipfile

from selenium.webdriver.chrome.options import Options

logger = logging.getLogger(__name__)


def add_proxy(options: Options, proxy=None):
    """
    Args:
      options - Chrome Options
      proxy - E.g: user49013:Hq2vjyPJYb@144.202.28.68:49013
    """
    if proxy:
        logger.info("Add proxy %s", proxy)
        # Add proxy without authentication
        options.add_argument("--proxy-server=%s" % proxy)
        # Add proxy with authentication
        if "@" in proxy:  
            try:
                split = proxy.split("@")
                split0 = split[0].split(":")
                split1 = split[1].split(":")

                proxy_host = split1[0]
                proxy_port = split1[1]
                proxy_user = split0[0]
                proxy_pass = split0[1]

                extension = proxy_extension(
                    options=options,
                    PROXY_HOST=proxy_host,
                    PROXY_PORT=proxy_port,
                    PROXY_USER=proxy_user,
                    PROXY_PASS=proxy_pass,
                )
                options.add_extension(extension)
                
            except Exception:
                logger.error("Cannot add this proxy %s", proxy)
                options.add_argument("--disable-extensions")
                options.add_argument("--hide-scrollbars")
                options.add_argument("--disable-gpu")
                options.add_argument("--no-proxy-server")

    return options


def proxy_extension(options: Options, PROXY_HOST, PROXY_PORT, PROXY_USER, PROXY_PASS):

    manifest_json = """
    {
        "version": "1.0.0",
        "manifest_version": 2,
        "name": "Chrome Proxy",
        "permissions": [
            "proxy",
            "tabs",
            "unlimitedStorage",
            "storage",
            "<all_urls>",
            "webRequest",
            "webRequestBlocking"
        ],
        "background": {
            "scripts": ["background.js"]
        },
        "minimum_chrome_version":"22.0.0"
    }
    """

    background_js = """
    var config = {
            mode: "fixed_servers",
            rules: {
            singleProxy: {
                scheme: "http",
                host: "%s",
                port: parseInt(%s)
            },
            bypassList: ["localhost"]
            }
        };

    chrome.proxy.settings.set({value: config, scope: "regular"}, function() {});

    function callbackFn(details) {
        return {
            authCredentials: {
                username: "%s",
                password: "%s"
            }
        };
    }

    chrome.webRequest.onAuthRequired.addListener(
                callbackFn,
                {urls: ["<all_urls>"]},
                ['blocking']
    );
    """ % (
        PROXY_HOST,
        PROXY_PORT,
        PROXY_USER,
        PROXY_PASS,
    )

    pluginfile = "proxy_auth_plugin.zip"
    with zipfile.ZipFile(pluginfile, "w") as zp:
        zp.writestr("manifest.json", manifest_json)
        zp.writestr("background.js", background_js)

    return pluginfile
