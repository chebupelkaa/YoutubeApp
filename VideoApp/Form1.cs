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

namespace VideoApp
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;
        private readonly string apiKey = "AIzaSyByzPkKv-T5Izf_V7yHTvzGiGGITvAUNWw";
        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
            this.WindowState = FormWindowState.Maximized;
 
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

        private string ExtractVideoId(string url)
        {
            var uri = new Uri(url);
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            return query["v"] ?? uri.Segments[uri.Segments.Length - 1];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxURL.Clear();
        }
    }
}
