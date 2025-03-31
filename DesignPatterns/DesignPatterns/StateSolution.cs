namespace DesignPatterns;

public class StateSolution
{
    public interface IFileState
    {
        void Upload(File file);
        void Download(File file);
    }
    public class File
    {
        public IFileState State { get; set; }

        public File(IFileState fs)
        {
            State = fs;
        }

        public void Upload()
        {
            State.Upload(this);
        }

        public void Download()
        {
            State.Download(this);
        }
    }
        class ReadyToUpload : IFileState
        {
            public void Upload(File file)
            {
                Console.WriteLine("Starting to upload file");
                file.State = new Uploaded();
            }
            public void Download(File file)
            {
                Console.WriteLine("Waiting for file to be uploaded and ready for download");
            }
        }

        class Uploaded : IFileState
        {
            public void Upload(File file)
            {
                Console.WriteLine("Checking if a file is ready to download");
                file.State = new ReadyForDownload();
            }
            public void Download(File file)
            {
                Console.WriteLine("Waiting for file to be ready for download");
            }
        }

        class ReadyForDownload : IFileState
        {
            public void Upload(File file)
            {
                Console.WriteLine("Waiting for file to be ready for upload");
            }

            public void Download(File file)
            {
                Console.WriteLine("Waiting for file to be downloaded");
                file.State = new Downloaded();
            }
        }

        class Downloaded : IFileState
        {
            public void Upload(File file)
            {
                Console.WriteLine("Waiting for file  to be ready for upload");
                file.State = new ReadyToUpload();
            }

            public void Download(File file)
            {
                Console.WriteLine("Waiting for file to be uploaded and ready for download");
            }
        }
    
    public void Execute()
    {
        Console.WriteLine("\nState Solution:");
        File file = new File(new ReadyToUpload());
        file.Upload();
        file.Download();
        file.Upload();
    }
}
