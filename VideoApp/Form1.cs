using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using CefSharp.WinForms;
using CefSharp;
using System.IO;

namespace VideoApp
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;

        private string currentURL;
        private string currentName;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            InitializeChromium();
            LoadLastVideo();

            //Panel topPanel = new Panel();
            //topPanel.Dock = DockStyle.Top;
            //topPanel.Height = 30;
            //this.Controls.Add(topPanel);

            this.Icon = new Icon("youtube-icon2.ico");
            //browser.Load("https://www.youtube.com");
        }
        private void InitializeChromium()
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser();
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }
        private void btnInputURL_Click(object sender, EventArgs e)
        {
            try
            {
                string url = textBoxURL.Text;
                string videoId = ExtractVideoId(url);

                if (!string.IsNullOrEmpty(videoId))
                {
                    browser.Load($"https://www.youtube.com/embed/{videoId}");
                    //var title=await browser.EvaluateScriptAsync("document.title");
                    SaveLastVideo(url);
                    currentURL = url;
                    //currentName = title.Result.ToString();
                    //MessageBox.Show(title.Result.ToString(), "Название видео");
                    browser.LoadingStateChanged += OnLoadingStateChanged;
                }
                else
                {
                    MessageBox.Show("Введите корректную ссылку на YouTube видео.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Формат URL некорректен. Пожалуйста, введите правильный URL.");
            }

        }

        private async void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                var title = await browser.EvaluateScriptAsync("document.title");
                if (title.Success)
                {
                    currentName = title.Result.ToString();
                }
            }
        }

        private string ExtractVideoId(string url)
        {
            var uri = new Uri(url);
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            return query["v"] ?? uri.Segments[uri.Segments.Length - 1];
        }

        private void SaveLastVideo(string url)
        {
            if (!File.Exists("lastVideo.txt"))
            {
                File.Create("lastVideo.txt").Close(); 
            }
            File.WriteAllText("lastVideo.txt", url);
        }

        private void LoadLastVideo()
        {
            if (System.IO.File.Exists("lastVideo.txt"))
            {
                string lastVideoUrl = File.ReadAllText("lastVideo.txt");
                string videoId = ExtractVideoId(lastVideoUrl);

                if (!string.IsNullOrEmpty(videoId))
                {
                    browser.Load($"https://www.youtube.com/embed/{videoId}");
                    currentURL = $"https://www.youtube.com/embed/{videoId}";
                    browser.LoadingStateChanged += OnLoadingStateChanged;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxURL.Clear();
        }

        private void collectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectionForm collectionForm = new collectionForm(currentName,currentURL);
            
            collectionForm.Show();
        }
    }
}
