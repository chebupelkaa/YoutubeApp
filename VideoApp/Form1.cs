using System;
using System.Drawing;
using System.Windows.Forms;
using System.Web;
using CefSharp.WinForms;
using CefSharp;
using Google.Apis.YouTube.v3.Data;

namespace VideoApp
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;

        public Video video =new Video();

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            InitializeChromium();

            Panel topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 35;
            this.Controls.Add(topPanel);

            this.Icon = new Icon("youtube-icon2.ico");
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
                    video.Url = url;
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
                    string fullTitle = title.Result.ToString();
                    video.Title = fullTitle.Replace(" - YouTube", "").Trim();
                }
            }
        }

        private string ExtractVideoId(string url)
        {
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            return query["v"] ?? uri.Segments[uri.Segments.Length - 1];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxURL.Clear();
        }

        private void OnUrlSelected(string url)
        {
            string id = ExtractVideoId(url);
            browser.Load($"https://www.youtube.com/embed/{id}");
            video.Url = url;
            textBoxURL.Text = url;
            browser.LoadingStateChanged += OnLoadingStateChanged;
        }


        private void buttonCollection_Click(object sender, EventArgs e)
        {
            collectionForm collectionForm = new collectionForm(video);
            collectionForm.UrlSelected += OnUrlSelected;
            collectionForm.Show();
        }
    }
}
