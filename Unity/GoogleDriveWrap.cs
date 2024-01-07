using GoogleDriveUploader.GoogleDrive;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Unity
{
    public class GoogleDriveWrap
    {
        const char COMMA = ',';
        const string END = ".";
        const string NEW = "\n";
        const char NEW_CHAR = '\n';
        const string FILE_NAME = "save.txt";
        private GoogleDriveService _service;

        public GoogleDriveWrap()
        {
            const string APPLICATION_NAME = "DrawAnyWhere";
            const string CLIENT_SECRETS_FILE_NAME = "clientSecret.json";
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRETS_FILE_NAME);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SaveData(List<Page> pages)
        {

            System.IO.File.WriteAllText(FILE_NAME, DoEncode(pages));
            UploadFile(FILE_NAME);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public List<Page> LoadData()
        {
            DownloadFile(FILE_NAME);
            var data = System.IO.File.ReadAllText(FILE_NAME);
            return DoNoEncode(data);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private string DoEncode(List<Page> pages)
        {
            string result = "";
            foreach (var page in pages)
            {
                result += END + NEW;
                foreach (var shape in page.shapeList)
                {
                    result += shape.GetFile();
                }
            }
            return result;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private List<Page> DoNoEncode(string origin)
        {
            var lines = origin.Split(NEW_CHAR);
            var pageIndex = -1;
            List<Page> pages = new List<Page>();
            foreach (var line in lines)
            {
                if (line == END)
                {
                    pageIndex++;
                    pages.Add(new Page());
                }
                else if (line.Length != 0)
                {
                    pages[pageIndex].Add(DoNoEncodeShape(line));
                }
            }
            return pages;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private Shape DoNoEncodeShape(string line)
        {
            var words = line.Split(COMMA);
            Shape shape;
            Point first = new Point(int.Parse(words[1]), int.Parse(words[1 + 1]));
            Point second = new Point(int.Parse(words[1 + 1 + 1]), int.Parse(words[1 + 1 + 1 + 1]));
            Point drawCanvasSize = new Point(int.Parse(words[1 + 1 + 1 + 1 + 1]), int.Parse(words[1 + 1 + 1 + 1 + 1 + 1]));

            shape = CreateShape(words, first, second, drawCanvasSize);

            return shape;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="words"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="drawCanvasSize"></param>
        /// <returns></returns>
        private static Shape CreateShape(string[] words, Point first, Point second, Point drawCanvasSize)
        {
            if (words[0] == ShapeType.Line.ToString())
            {
                return new Line(first, second, drawCanvasSize);
            }
            else if (words[0] == ShapeType.Rectangle.ToString())
            {
                return new Rectangle(first, second, drawCanvasSize);
            }
            else if (words[0] == ShapeType.Ellipse.ToString())
            {
                return new Ellipse(first, second, drawCanvasSize);
            }
            return new Line(first, second, drawCanvasSize);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void UploadFile(string fileName)
        {
            const string CONTENT_TYPE = "text/plain";
            _service.UploadFile(fileName, CONTENT_TYPE);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
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
