using FBTool.BLL.Interface.Facebook;
using FBTool.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace FBTool.App.Views
{
    public partial class MainForm : RadForm
    {
        private List<IFacebookBussiness> _facebookBussinesses = new List<IFacebookBussiness>();
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Start()
        {
            //List<Profile> profiles = ((IEnumerable)lvProfiles.DataSource).Cast<Profile>().ToList();
            //profiles.ForEach(p =>
            //{
                var task = new Task(() =>
                {
                    var random = new Random();
                    IFacebookBussiness facebookBussiness = Program.GetService<IFacebookBussiness>();
                    facebookBussiness.ChromeProfile(cbProfiles.Text, "Profile 1", false);
                    string[] pages = tbPages.Lines;
                    string[] contents = tbContents.Lines;
                    foreach(string page in pages)
                    {
                        string content = contents[random.Next(contents.Length)];
                        string[] split = content.Split('|');
                        string text = split[0].TrimEnd('\r', '\n');
                        string photo = split[1].TrimEnd('\r', '\n');
                        facebookBussiness.ReviewsPage(page, text, photo);
                    }
                    _facebookBussinesses.Add(facebookBussiness);
                });
                task.Start();
            //});
        }

        private void Stop()
        {
            _facebookBussinesses.ForEach(fb =>
            {
                fb.Close();
            });
            _facebookBussinesses.Clear();
        }

        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Stop();
        }

        private void radButton4_Click(object sender, System.EventArgs e)
        {
            if (btnRun.Text.Equals("Start"))
            {
                btnRun.Text = "Stop";
                Start();
            } else
            {
                btnRun.Text = "Start";
                Stop();
            }

        }

        private void radButton1_Click(object sender, System.EventArgs e) {
            SaveFileDialog f = new SaveFileDialog();
            f.ShowDialog();

            //RadOpenFolderDialog openFolderDialog = new RadOpenFolderDialog();
            //DialogResult dialogResult = openFolderDialog.ShowDialog();
           
            //if (dialogResult.Equals(DialogResult.OK))
            //{
            //    MainForm_Load(sender, e);
            //}

            //openFolderDialog.RestoreDirectory = true;
        }

        private void radButton2_Click(object sender, System.EventArgs e)
        {
            RadOpenFileDialog openFileDialog = new RadOpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            
            if (dialogResult.Equals(DialogResult.OK))
            {
                Stream fileStream = openFileDialog.OpenFile();
                StreamReader streamReader = new StreamReader(fileStream);
                tbPages.Text = streamReader.ReadToEnd();
            }
            openFileDialog.RestoreDirectory = true;
        }

        private void radButton3_Click(object sender, System.EventArgs e)
        {
            RadOpenFileDialog openFileDialog = new RadOpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult.Equals(DialogResult.OK))
            {
                Stream fileStream = openFileDialog.OpenFile();
                StreamReader streamReader = new StreamReader(fileStream);
                tbContents.Text = streamReader.ReadToEnd();
            }
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            var subdirs = Directory.GetDirectories(cbProfiles.Text)
                 .Select(path => new DirectoryInfo(path))
                 .Where(path => Regex.IsMatch(path.FullName, @"Profile\s\d*$"))
                 .Select(directory => new Profile(directory.Name, directory.FullName))
                 .ToArray();
              
            lvProfiles.DataSource = subdirs;
        }
    }
}
