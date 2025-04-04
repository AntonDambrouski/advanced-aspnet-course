using DesignPatterns;
using DesignPatterns.Behavioral_patterns;
using DesignPatterns.Creational_patterns;
using DesignPatterns.Structural_patterns;

Console.WriteLine("AdapterProblem");
AdapterProblem adapterProblem = new AdapterProblem();
adapterProblem.Execute();
Console.WriteLine();

Console.WriteLine("AdapterSolution");
AdapterSolution adapter = new AdapterSolution();
adapter.Execute();
Console.WriteLine();


Console.WriteLine("DecoratorProblem");
DecoratorProblem decoratorProblem = new DecoratorProblem();
decoratorProblem.Execute();
Console.WriteLine();

Console.WriteLine("DecoratorSolution");
DecoratorSolution decoratorSolution = new DecoratorSolution();
decoratorSolution.Execute();
Console.WriteLine();

Console.WriteLine("ObserverProblem");
ObserverProblem observerProblem = new ObserverProblem();
observerProblem.Execute();
Console.WriteLine();

Console.WriteLine("ObserverSolution");
ObserverSolution observerSolution = new ObserverSolution();
observerSolution.Execute();
Console.WriteLine();

Console.WriteLine("StateProblem");
StateProblem stateProblem = new StateProblem();
stateProblem.Execute();
Console.WriteLine();

Console.WriteLine("StateSolution");
StateSolution stateSolution = new StateSolution();
stateSolution.Execute();
Console.WriteLine();

Console.WriteLine("BuilderSolution");
BuilderSolution builderSolution = new BuilderSolution();
builderSolution.Execute();
Console.WriteLine();

Console.WriteLine("PrototypeSolution");
PrototypeSolution PrototypeSolution = new PrototypeSolution();
PrototypeSolution.Execute();
Console.WriteLine();

Console.WriteLine("DynamicFabricPrototype");
BoxElement boxPrototype = new BoxElement();
DynamicFabricPrototype.AddPrototype(boxPrototype);

CircleElement circlePrototype = new CircleElement();
DynamicFabricPrototype.AddPrototype(circlePrototype);
BoxElement newBox = (BoxElement)DynamicFabricPrototype.CreateObject(typeof(BoxElement));
