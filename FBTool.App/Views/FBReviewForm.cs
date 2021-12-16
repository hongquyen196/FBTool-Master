using FBTool.App.Constants;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FBTool.App.Views
{
    public partial class FBReviewForm : Form
    {
        public static Dictionary<string, object> shareObject = new Dictionary<string, object>();

        private Random random = new Random();

        private ReviewScheduler reviewScheduler = new ReviewScheduler();

        private List<Profile> _profiles = new List<Profile>();

        private List<string> _pages = new List<string>();

        private List<string> _contents = new List<string>();

        private List<string> _parameters = new List<string>();

        private List<IScheduler> schedulers = new List<IScheduler>();

        public FBReviewForm()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numInHours.Enabled = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numInHours.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            schedulers.ForEach(s => reviewScheduler.Stop(s));
        }

        private void btnOpenProfilesFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                cbProfilesPath.Text = folderPath;
                _profiles = Directory.GetDirectories(folderPath)
                 .Select(path => new DirectoryInfo(path))
                 .Where(path => Regex.IsMatch(path.FullName, @"Profile\s\d*$"))
                 .Select(directory => new Profile(directory.Name, directory.FullName))
                 .ToList();
            }
        }

        private void btnOpenFanpagesFile_Click(object sender, EventArgs e)
        {
            string pathToFile = openFile();
            if (File.Exists(pathToFile))
            {
                string[] lines = File.ReadAllLines(pathToFile);
                _pages = lines.ToList();
                cbFanpagesPath.Text = pathToFile;
            }

        }

        private void btnOpenContentsFile_Click(object sender, EventArgs e)
        {
            string pathToFile = openFile();
            if (File.Exists(pathToFile))
            {
                string[] lines = File.ReadAllLines(pathToFile, Encoding.UTF8);
                _contents = lines.ToList();
                cbContentsPath.Text = pathToFile;
            }
        }


        private void cbProfilesPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            _profiles = Directory.GetDirectories(cbProfilesPath.Text)
                 .Select(path => new DirectoryInfo(path))
                 .Where(path => Regex.IsMatch(path.FullName, @"Profile\s\d*$"))
                 .Select(directory => new Profile(directory.Name, directory.FullName))
                 .ToList();
        }

        private void cbFanpagesPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(cbFanpagesPath.Text);
            _pages = lines.ToList();
        }

        private void cbContentsPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(cbContentsPath.Text);
            _contents = lines.ToList();
        }

        int indexOfPages = 0;

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            int numberOfReviews = (int)numOfReviews.Value;
            for (int i = 1; i <= numberOfReviews; i++)
            {
                try
                {
                    Parameter parameter = new Parameter();
                    parameter._CHROME_DRIVER = Constant.CHROME_DRIVER;
                    parameter._INJECTED_CREATE_YOUR_POST_REVIEW = Constant.INJECTED_CREATE_YOUR_POST_REVIEW_JS;
                    parameter._INJECTED_GET_YOUR_POST_REVIEW = Constant.INJECTED_GET_YOUR_POST_REVIEW_JS;
                    parameter._HEADLESS = false;

                    int randomProfilesIndex = random.Next(0, _profiles.Count);
                    Profile profile = _profiles[randomProfilesIndex];
                    parameter._PROFILE_PATH = profile.Path;
                    parameter._PROFILE_NAME = profile.Name;
                    parameter._USERNAME = profile.User;
                    parameter._PROXY = profile.Proxy;

                    if (indexOfPages >= _pages.Count)
                    {
                        indexOfPages = 0;
                    }
                    parameter._PAGE = _pages[indexOfPages++];

                    int randomContentsIndex = random.Next(0, _contents.Count);
                    string content = _contents[randomContentsIndex];
                    string attachment = null;
                    string[] split = content.Split('|');
                    if (split.Length == 2)
                    {
                        content = split[0];
                        attachment = split[1];
                        parameter._ATTACHMENTS = attachment.Split(',').ToList();
                    }
                    parameter._CONTENTS = new List<string>() { content };

                    int numberOfReviewsInSeconds = random.Next(0, (int)(numInHours.Value * 60 * 60));

                    DateTimeOffset startTime = DateTimeOffset.Now
                        .AddSeconds(numberOfReviewsInSeconds);

                    string[] row = {
                        i.ToString(),
                        parameter._PROFILE_NAME,
                        parameter._USERNAME,
                        parameter._PAGE,
                        startTime.ToString(),
                        parameter._CONTENTS[0]
                    };

                    var listViewItem = new ListViewItem(row);
                    lvSchedule.Items.Add(listViewItem);

                    string jsonData = JsonConvert.SerializeObject(parameter, Formatting.None);

                    var guid = Guid.NewGuid().ToString();

                    var path = $"{Constant.REVIEW_PARAMETER_PATH}\\{guid}.json";

                    File.WriteAllText(path, jsonData);

                    _parameters.Add(path);

                    reviewScheduler.Start(path, startTime);

                    schedulers.Add(reviewScheduler.scheduler);
                }
                catch (Exception ex)
                {
                    scheduleStatus.Text = ex.Message;
                }
            }
            //shareObject.Add("lvSchedule", lvSchedule);
            //shareObject.Add("scheduleStatus", scheduleStatus);
        }

        private string openFile()
        {
            string pathToFile = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Text File";
            openFileDialog.Filter = "TXT files|*.txt";
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                pathToFile = openFileDialog.FileName;
            }
            openFileDialog.RestoreDirectory = true;
            return pathToFile;
        }

        private void FBReviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parameters.ForEach(p => File.Delete(p));
        }
    }
}
