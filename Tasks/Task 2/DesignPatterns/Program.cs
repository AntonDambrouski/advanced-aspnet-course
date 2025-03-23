using DesignPatterns.FactoryMethodProblem;
using DesignPatterns.AbtractFactoryProblem;
using DesignPatterns.AbtractFactorySolution;
using DesignPatterns.FactoryMethodSolution;
using DesignPatterns.FlyweightProblem;


using DesignPatterns.FlyweightSolution;
using DesignPatterns.ProxyProblem;
using DesignPatterns.ProxySolution;
using DesignPatterns.VisitorProblem;
using DesignPatterns.VisitorSolution;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.ChainOfResponsibilitySolution;


List<IDemo> demos = new List<IDemo>()
{
    new FactoryMethodProblemDemo(),
    new FactoryMethodSolutionDemo(),
    new AbstractFactoryProblemDemo(),
    new AbstractFactorySolutionDemo(),
    new FlyweightProblemDemo(),
    new FlyweightSolutionDemo(),
    new ProxyProblemDemo(),
    new ProxySolutionDemo(),
    new VisitorProblemDemo(),
    new VisitorSolutionDemo(),
    new ChainOfResponsibilityDemo(),
    new ChainOfResponsibilitySolutionDemo(),
};

IMainVisitor mainVisitor = new MainVisitor();
foreach (IDemo demo in demos)
{
    demo.Accept(mainVisitor);
}  


public interface IDemo
{
    public void Execute();

    public void Accept(IMainVisitor visitor);
}


public interface IMainVisitor
{
    public void Visit(IDemo demo);
}

public class MainVisitor: IMainVisitor
{
    public void Visit(IDemo demo)
    {
        Console.WriteLine();
        Console.WriteLine(demo.ToString());
        demo.Execute();
    }
}



