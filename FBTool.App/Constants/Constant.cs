using System.IO;
using System.Windows.Forms;

namespace FBTool.App.Constants
{
    public class Constant
    {
        public static readonly string EXECUTABLE_PATH = Path.GetDirectoryName(Application.ExecutablePath);

        public static readonly string CHROME_DRIVER = $"{EXECUTABLE_PATH}\\_CHROME_DRIVER\\chromedriver.exe";

        public static readonly string REVIEW_EXECUTABLE = $"{EXECUTABLE_PATH}\\_REVIEW_EXECUTABLE\\review.exe";

        public static readonly string REVIEW_PARAMETER_PATH = $"{EXECUTABLE_PATH}\\_REVIEW_PARAMETER";

        public static readonly string INJECTED_CREATE_YOUR_POST_REVIEW_JS = $"{EXECUTABLE_PATH}\\_REVIEW_JAVASCRIPT\\createYourPostReview.js";

        public static readonly string INJECTED_GET_YOUR_POST_REVIEW_JS = $"{EXECUTABLE_PATH}\\_REVIEW_JAVASCRIPT\\getYourPostReview.js";
    }
}
