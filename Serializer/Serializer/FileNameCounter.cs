using System.IO;

namespace Serializer
{ 
    class FileNameCounter
    {
        string startingPath = @"C:\Users\Noncsi\Desktop\Sheiwa\C#\c-sharp-tw3-serializer-Noncsi\Serializer\People";
        public string finalFileName;

        public FileInfo[] GetAllFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(startingPath);
            FileInfo[] files = directory.GetFiles();
            return files;
        }

        public int GetNumberOfFiles()
        {
            int fileCounter = 0;
            FileInfo[] files = GetAllFiles();
            foreach (FileInfo file in files) if (file.Extension == ".dat") fileCounter++;
            return fileCounter;
        }

        void FileCounterBelow10()
        {
            int fileCounter = GetNumberOfFiles();
            if (fileCounter < 10) finalFileName = "0" + fileCounter.ToString();
            else finalFileName = fileCounter.ToString();
        }

        public string ReturnPathToSerializer()
        {
            FileCounterBelow10();
            string path = startingPath + @"\Person" + finalFileName + ".dat";
            return path;
        }
    }
}
