namespace Basic_Programming_Principles.SOLID
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        // Viaolates Single Responsibility Principle 
        public string LoadFromFile()
        {
            var path = @"C:\temp\journal.txt";
            return File.ReadAllText(path);
        }

        public void SaveToFile()
        {
            var path = @"C:\temp\journal.txt";
            File.WriteAllText(path, ToString());
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class JournalManager
    {


        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, journal.ToString());
            }
        }

        //public Journal LoadFromFile(string filename)
        //{
        //    var json = File.ReadAllText(filename);
        //    // implentation
        //}
    }
}
