using System;
using System.IO;
using System.Text;

namespace SoftTestLab2Yamanko
{
    class FileService
    {
        private readonly IFileService fileService;

        public FileService()
        {

        }

        public FileService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public int MergeTemporaryFiles(string dir)
        {
            int count = 0;

            if (Directory.Exists(dir))
            {
                string fileType = "*.tmp";

                if (Directory.GetFiles(dir, fileType).Length <= 0)
                {
                    return 0;
                }

                var result = Directory.EnumerateFiles(dir, fileType);

                try
                {
                    StreamWriter saveFile = new StreamWriter("C:\\Users\\Dmitry\\save.txt");

                    foreach (string s in result)
                    {
                        saveFile.Write(s);
                        File.Delete(s);
                        count++;
                    }

                    saveFile.Close();
                }
                catch (Exception)
                {
                    //
                }
            }
            else
            {
                throw new NullReferenceException("Указана несуществующая директория");
            }

            return count;
        }

        public int RemoveTemporaryFiles(string dir)
        {
            return fileService.RemoveTemporaryFiles(dir);
        }

        public void CreateTempFileForDelete(string dir)
        {
            if (dir.EndsWith("\\"))
            {
                dir += "temp.txt";
            }
            else
            {
                dir = dir + "\\" + "temp.txt";
            }

            StreamWriter writer = new StreamWriter(dir, false, Encoding.Default);

            writer.Write("__");
            writer.Close();
        }
    }
}
