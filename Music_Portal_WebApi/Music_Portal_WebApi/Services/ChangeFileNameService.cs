namespace Music_Portal_WebApi.Services
{
    public class ChangeFileNameService
    {

        private IWebHostEnvironment? _environment;
        private ILogger<ChangeFileNameService>? _logger;

        public ChangeFileNameService(IWebHostEnvironment? environment, ILogger<ChangeFileNameService>? logger)
        {
            _environment = environment;
            _logger = logger;
        }
        public void ChangeFileNameAsync(string oldname, string newName)
        {
            string path = _environment.WebRootPath + "\\Music";
            string[] filePaths = Directory.GetFiles(path,oldname, SearchOption.AllDirectories);
            string temp = "";

            Task.Run(() => {
                foreach (string filePath in filePaths)
                {
                    temp = filePath;
                }
                FileInfo fileInfo = new FileInfo(temp);
                fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + $"{newName}");
            });


        }

        public async void ChangeDirectoryAsync(string oldname, string newName)
        {

            string path = _environment.WebRootPath + "\\Music";
            string searchPattern = $"{oldname}";
            string[] filePaths = Directory.GetDirectories(path, searchPattern, SearchOption.AllDirectories);

            string temp = "";

            await  Task.Run(() => {
                foreach (string Path in filePaths)
                {
                  temp = Path;
                }
                 DirectoryInfo diInfo = new DirectoryInfo(temp);
                 diInfo.MoveTo(temp.Replace(oldname,newName));
            });
        }
    }
}
