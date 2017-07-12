using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{ 
    class FileNameCounter
    {
        string startingPath = @"C:\Users\Noncsi\Desktop\Sheiwa\C#\c-sharp-tw3-serializer-Noncsi\Serializer";
        int fileCounter;
        string finalFileName;

        void GetAllPersonObject()
        {
            DirectoryInfo directory = new DirectoryInfo(startingPath);
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files) if (file.Extension == ".dat") fileCounter++;
        }

        void FileCounterBelow10()
        {
            if (fileCounter < 10) finalFileName = "0" + fileCounter.ToString();
            else finalFileName = fileCounter.ToString();
        }

        public string ReturnPathToSerializer()
        {
            GetAllPersonObject();
            FileCounterBelow10();
            string path = startingPath + @"\Person" + finalFileName + ".dat";
            return path;
        }
    }
}
