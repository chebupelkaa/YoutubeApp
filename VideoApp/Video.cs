using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VideoApp
{
    public class Video
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string VideoId { get; set; }
        public Video(string title,string url,string videoId) {
            Title = title;
            Url = url;
            VideoId = videoId;
        }
        public Video() { }

        public string GetVideoIdFromURL()
        {
            string videoId = Url.Split(new[] { "v=" }, StringSplitOptions.None)[1];
            if (videoId.Contains("&"))
            {
                videoId = videoId.Split('&')[0];
            }
            return videoId;
        }

    }
}
