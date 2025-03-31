namespace DesignPatterns;

public class StateProblem
{
    public enum FileState
    {
        ReadyToUpload,
        Uploaded,
        ReadyToDownload,
        Downloaded
    }
    public class File
    {
        public FileState State { get; set; }

        public File(FileState state)
        {
            State = state;
        }
        public void Upload()
        {
            if (State == FileState.ReadyToUpload)
            {
                Console.WriteLine("Starting to upload file");
            }
            else if (State == FileState.Uploaded)
            {
                Console.WriteLine("Checking if a file is ready to download");
            }
            else if (State == FileState.Downloaded)
            {
                Console.WriteLine("Waiting for file to be ready to upload");
            }
        }

        public void Download()
        {
            if (State == FileState.ReadyToDownload)
            {
                Console.WriteLine("Starting to download file");
            }
            else if (State == FileState.Downloaded)
            {
                Console.WriteLine("Working with file");
            }
            else if (State == FileState.Uploaded)
            {
                Console.WriteLine("Waiting for file to be ready to download");
            }
        }
    }

    public void Execute()
    {
        Console.WriteLine("\nState Problem:");
        File file = new File(FileState.ReadyToUpload);
        file.Upload();
        file.State = FileState.Uploaded;
        file.Upload();
        file.State = FileState.ReadyToDownload;
        file.Download();
        file.State = FileState.Downloaded;
        file.Download();

    }
}
