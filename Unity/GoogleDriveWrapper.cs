using GoogleDriveUploader.GoogleDrive;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Unity
{
    public class GoogleDriveWrapper
    {
        private GoogleDriveService _service;

        public GoogleDriveWrapper()
        {
            const string APPLICATION_NAME = "DrawAnyWhere";
            const string CLIENT_SECRETS_FILE_NAME = "clientSecret.json";
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRETS_FILE_NAME);
        }

        public void SaveData(List<Page> pages)
        {

            System.IO.File.WriteAllText("save.txt", Encode(pages));
            UploadFile("save.txt");
        }
        public List<Page> LoadData()
        {
            DownloadFile("save.txt");
            var data = System.IO.File.ReadAllText("save.txt");
            return Decode(data);
        }

        private string Encode(List<Page> pages)
        {
            string result = "";
            foreach (var page in pages)
            {
                result += ".\n";
                foreach (var shape in page.shapeList)
                {
                    result += shape.Serializable();
                }
            }
            return result;
        }
        private List<Page> Decode(string origin)
        {
            var lines = origin.Split('\n');
            var pageIndex = -1;
            List<Page> pages = new List<Page>();
            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    continue;
                }
                if (line == ".")
                {
                    pageIndex++;
                    pages.Add(new Page());
                }
                else
                {
                    pages[pageIndex].Add(DecodeShape(line));
                }
            }
            return pages;
        }

        private Shape DecodeShape(string line)
        {
            var words = line.Split(',');
            Shape shape;
            Point first = new Point(int.Parse(words[1]), int.Parse(words[2]));
            Point second = new Point(int.Parse(words[3]), int.Parse(words[4]));
            Point drawCanvaSize = new Point(int.Parse(words[5]), int.Parse(words[6]));

            if (words[0] == "Line")
            {
                shape = new Line(first, second, drawCanvaSize);
            }
            else if (words[0] == "Rectangle")
            {
                shape = new Rectangle(first, second, drawCanvaSize);
            }
            else if (words[0] == "Ellipse")
            {
                shape = new Ellipse(first, second, drawCanvaSize);
            }
            else
            {
                throw new Exception(words[0] + "shape not found");
            }

            return shape;
        }

        private void UploadFile(string fileName)
        {
            const string content_type = "text/plain";
            _service.UploadFile(fileName, content_type);
        }

        private void DownloadFile(string fileName)
        {
            List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
            Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item =>
            {
                return item.Title == fileName;
            });
            if (foundFile != null)
            {
                _service.DownloadFile(foundFile, Directory.GetCurrentDirectory());
            }
        }
    }
}
