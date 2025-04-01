namespace SolidPrinciples;

internal class SingleResponsibilitySolution
{
    public class Document
    {
        public string Name { get; set; }
    }

    public class UploaderAndDownloader
    {
        public void UploadDocument(Document document)
        {
            Console.WriteLine($"Uploading {document.Name}");
        }

        public void DownloadDocument(Document document)
        {
            Console.WriteLine($"Downloading {document.Name}");
        }
    }

    public class Printer
    {
        public void PrintDocument(Document document)
        {
            Console.WriteLine($"Printing {document.Name}");
        }
    }

    public void Execute()
    {
        Console.WriteLine("\nSingle responsibility solution");
        Document document = new Document()
        {
            Name = "Report"
        };
        UploaderAndDownloader uploaderAndDownloader = new UploaderAndDownloader();
        Printer printer = new Printer();
        uploaderAndDownloader.UploadDocument(document);
        uploaderAndDownloader.DownloadDocument(document);
        printer.PrintDocument(document);
    }
}
