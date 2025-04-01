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
            OpenClosedProblem openClosedProblem = new OpenClosedProblem();
            openClosedProblem.Execute();
            OpenClosedSolution openClosedSolution = new OpenClosedSolution();
            openClosedSolution.Execute();
        }
    }
}
