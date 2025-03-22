using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.OCP
{
    class OCPSolution
    {
        public string PersonName { get; set; }

        public OCPSolution(string name) {

        }
        public void Read(IRead objectToRead) {
            objectToRead.Read();
        }
    }
    interface IRead {
        void Read();
    }

    public class Newspapers : IRead {
        public void Read() {
            Console.WriteLine($"I can read newspapers");
        }
    }
    public class Magazines : IRead {
        public void Read() {
            Console.WriteLine($"I can read magazines");
        }
    }
    public class Journals : IRead {
        public void Read() {
            Console.WriteLine($"I can read Journals");
        }
    }
    public class Books : IRead {
        public void Read() {
            Console.WriteLine($"I can read books");
        }
    }
}
