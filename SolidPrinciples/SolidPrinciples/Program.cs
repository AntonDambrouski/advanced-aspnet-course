namespace SolidPrinciples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleResponsibilityProblem singleResposibilityProblem = new SingleResponsibilityProblem();
            singleResposibilityProblem.Execute();
            SingleResponsibilitySolution singleResposibilitySolution = new SingleResponsibilitySolution();
            singleResposibilitySolution.Execute();
        }
    }
}
