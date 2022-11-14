namespace LoggerWithExceptions.Services
{
    // Write data into a file
    internal class FileService : IService
    {
        private string _filePath;
        private string _dirPath;

        public FileService()
        {
            _dirPath = JsonService.GetDirectoryPath();
            _filePath = _dirPath + "/" + DateTime.Now.ToString("HH.mm.ss dd.MM.yyyy") + ".txt";
        }

        public void Print(string data)
        {
            // we only create directory when we are ready to create a new file
            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
            }

            // we only remove extra (useless) file when we are ready to create a new one
            CheckExtraFile();

            using (StreamWriter writer = new StreamWriter(_filePath, append: true))
            {
                writer.WriteLine(data);
            }
        }

        // check if there a file needed to be removed from the directory
        private void CheckExtraFile()
        {
            string? extraFileToRemove = FindExtraFile();

            if (extraFileToRemove is not null)
            {
                File.Delete(extraFileToRemove);
            }
        }

        // find extra file which will be deleted afterwards
        // if directory consists of 3 files already
        // and return null if less than 3
        private string? FindExtraFile()
        {
            string[] files = Directory.GetFiles(_dirPath);

            // 3 files in directory = MAX
            if (files.Length <= 3)
            {
                return null;
            }

            DateTime oldestFileTime = File.GetCreationTime(files[0]);
            string fileToRemove = files[0];

            foreach (string file in files)
            {
                DateTime currFileTime = File.GetCreationTime(file);

                if (oldestFileTime > currFileTime)
                {
                    oldestFileTime = currFileTime;
                    fileToRemove = file;
                }
            }

            return fileToRemove;
        }
    }
}
