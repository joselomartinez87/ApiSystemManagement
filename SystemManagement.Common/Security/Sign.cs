using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.Common.Security
{
    public class Sign
    {

        public string Generate(string fileBase64)
        {
            SHA1Managed sha1 = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(fileBase64);
            byte[] hash = sha1.ComputeHash(data);
            return Convert.ToBase64String(hash);
        }

        public string FileSign(string firm, string fileBase64)
        {
            var file = string.Empty;
            var fileTypeBase64 = fileBase64.Substring(0, 5);
            var fileType = string.Empty;
            switch (fileTypeBase64.ToUpper())
            {
                case "IVBOR":
                    fileType = "png";
                    break;
                case "/9J/4":
                    fileType = "jpg";
                    break;
                case "AAAAF":
                    fileType = "mp4";
                    break;
                case "JVBER":
                    fileType = "pdf";
                    break;
                case "AAABA":
                    fileType = "ico";
                    break;
                case "UMFYI":
                    fileType = "rar";
                    break;
                case "E1XYD":
                    fileType = "rtf";
                    break;
                case "U1PKC":
                    fileType = "txt";
                    break;
                case "MQOWM":
                case "77U/M":
                    fileType = "srt";
                    break;
                default:
                    fileType = string.Empty;
                    break;
            }
            if (fileType == "png" || fileType == "jpg")
            {
                file = WriteImage(fileBase64, firm);
            }
            else if (fileType == "pdf")
            {
                file = WritePdf(fileBase64, firm);
            }
            else
            {
                file = fileBase64;
            }
            return file;
        }

        private string WriteImage(string fileBase64, string text)
        {
            var newImage = string.Empty;
            byte[] imageBytes = Convert.FromBase64String(fileBase64);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                Graphics g = Graphics.FromImage(image);
                using (Font myfont = new Font("Arial", 10))
                {
                    g.DrawString(text, myfont, Brushes.Black, new Point(1, image.Height - 18));
                }
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] newImageBytes = m.ToArray();
                    newImage = Convert.ToBase64String(newImageBytes);
                }
            }
            return newImage;
        }

        private string WritePdf(string fileBase64, string text)
        {
            var newImage = string.Empty;
            var bytes = Convert.FromBase64String(fileBase64);
            Stream stream = new MemoryStream(bytes);
            PdfDocument PDFDoc = PdfReader.Open(stream);

            PdfPage page = PDFDoc.AddPage();

            page.Width = PDFDoc.Pages[0].Width;
            page.Height = PDFDoc.Pages[0].Height;

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 14, XFontStyle.BoldItalic);
            gfx.DrawString(text, font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
            XStringFormats.TopCenter);

            using (MemoryStream ms = new MemoryStream())
            {
                PDFDoc.Save(ms, false);
                byte[] buffer = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Flush();
                ms.Read(buffer, 0, (int)ms.Length);
                newImage = Convert.ToBase64String(ms.ToArray());
            }
            return newImage;
        }

    }
}
