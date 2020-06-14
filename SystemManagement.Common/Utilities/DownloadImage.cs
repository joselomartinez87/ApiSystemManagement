using System.Net;

namespace SystemManagement.Common.Utilities
{
    public class DownloadImage
    {
        public byte[] DownloadImages(string URL)
        {
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(URL);
            return imageBytes;
        }
    }
}
