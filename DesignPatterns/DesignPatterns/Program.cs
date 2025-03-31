namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BuilderProblem builderProblem = new BuilderProblem();
            builderProblem.Execute();
            BuilderSolution builderSolution = new BuilderSolution();
            builderSolution.Execute();
            FactoryProblem factoryProblem = new FactoryProblem();
            factoryProblem.Execute();
            FactorySolution factorySolution = new FactorySolution();
            factorySolution.Execute();
            ProxyProblem proxyProblem = new ProxyProblem();
            proxyProblem.Execute();
            ProxySolution proxySolution = new ProxySolution();
            proxySolution.Execute();
            DecoratorProblem decoratorProblem = new DecoratorProblem();
            decoratorProblem.Execute();
            DecoratorSolution decoratorSolution = new DecoratorSolution();
            decoratorSolution.Execute();
            StrategyProblem strategyProblem = new StrategyProblem();
            strategyProblem.Execute();
            StrategySolution strategySolution = new StrategySolution();
            strategySolution.Execute();
            StateProblem stateProblem = new StateProblem();
            stateProblem.Execute();
            StateSolution stateSolution = new StateSolution();
            stateSolution.Execute();
        }
    }
}
