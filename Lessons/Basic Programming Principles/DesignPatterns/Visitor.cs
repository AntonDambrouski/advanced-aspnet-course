namespace Basic_Programming_Principles.DesignPatterns
{
    public interface IShape
    {
        void PrintDetails();
        void Accept(IVisitor visitor);
    }

    public class Circle : IShape
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void PrintDetails() => Console.WriteLine("This is a Circle.");
    }

    public class Square : IShape
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void PrintDetails() => Console.WriteLine("This is a Square.");
    }

    public interface IVisitor
    {
        void Visit(Circle circle);
        void Visit(Square square);
    }

    public class PrintVisitor : IVisitor
    {
        public void Visit(Circle circle) => circle.PrintDetails();
        public void Visit(Square square) => square.PrintDetails();
    }

    public class XmlExporterVisitor : IVisitor
    {
        public void Visit(Circle circle) => Console.WriteLine("<Circle></Circle>");
        public void Visit(Square square) => Console.WriteLine("<Square></Square>");
    }



    static class VisitorDemo
    {
        public static void Execute()
        {
            Circle circle = new Circle();
            Square square = new Square();

            circle.PrintDetails();
            square.PrintDetails();
        }
    }
}
