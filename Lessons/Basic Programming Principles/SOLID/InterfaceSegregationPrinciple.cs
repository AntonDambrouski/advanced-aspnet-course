using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Programming_Principles.SOLID
{
    public class Document
    {
    }

    public interface IMachine
    {
        void Print(Document d);
        void Fax(Document d);
        void Scan(Document d);
    }

    // ok if you need a multifunction machine
    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            //
        }

        public void Fax(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPrint
    {
        void Print(Document d);
    }

    public interface IScan
    {
        void Scan(Document d);
    }

    public interface IFax
    {
        void Fax(Document d);
    }

    public class Printer : IPrint, IScan
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }


    public interface IMachineV2 : IScan, IPrint, IFax
    {
    }

    public class MultiFunctionMachineV2 : IMachineV2
    {
        public void Print(Document d)
        {
            //
        }
        public void Fax(Document d)
        {
            //
        }
        public void Scan(Document d)
        {
            //
        }
    }
}