using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.OCP
{
    class OCPProblem
    { 
        public string PersonName { get; set; }
        public OCPProblem(string name)
        {
            PersonName = name;
        }
        public void Read()
        {
            Console.WriteLine($"I can read books only");
        }
    }
}
