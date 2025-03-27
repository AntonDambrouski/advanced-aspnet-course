// See https://aka.ms/new-console-template for more information


using SolidPrinciples;

Console.WriteLine("DependencyInversionPrincipleProblem");
DependencyInversionPrincipleProblem dipProblem = new DependencyInversionPrincipleProblem();
dipProblem.Execute();
Console.WriteLine();

Console.WriteLine("DependencyInversionPrincipleSolution");
DependencyInversionPrincipleSolution dipSolution = new DependencyInversionPrincipleSolution();
dipSolution.Execute();
Console.WriteLine();

Console.WriteLine("OpenClosedPrincipleProblem");
OpenClosedPrincipleProblem ocpProblem = new OpenClosedPrincipleProblem();
ocpProblem.Execute();
Console.WriteLine();

Console.WriteLine("OpenClosedPrincipleSolution");
OpenClosedPrincipleSolution ocpSolution = new OpenClosedPrincipleSolution();
ocpSolution.Execute();
Console.WriteLine();

