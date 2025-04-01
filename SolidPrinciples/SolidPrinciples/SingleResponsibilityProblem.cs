namespace SolidPrinciples;

public class SingleResponsibilityProblem
{
    public class Document
    {
        public string Name { get; set; }

        public void UploadDocument()
        {
            Console.WriteLine($"Uploading {Name}");
        }

        public void DownloadDocument()
        {
            Console.WriteLine($"Downloading {Name}");
        }

        public void PrintDocument()
        {
            Console.WriteLine($"Printing {Name}");
        }
    }
    public void Execute()
    {
        Console.WriteLine("\nSingle responsibility problem:");
        Document document = new Document()
        {
            Name = "Report"
        };
        document.UploadDocument();
        document.DownloadDocument();
        document.PrintDocument();
    }
}
