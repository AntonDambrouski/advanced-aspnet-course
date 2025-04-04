using SolidPrinciples.LiskovSubstituteProblem;
using SolidPrinciples.LiskovSubstituteSolution;
using SolidPrinciples.SingleResponsibilityProblem;
using SolidPrinciples.SingleResponsibilitySolution;

//Single Responsibility
SingleResponsibilityProblem  singleResponsibilityProblem = new SingleResponsibilityProblem();
Console.WriteLine(singleResponsibilityProblem.ToString());
singleResponsibilityProblem.Execute();
Console.WriteLine();
SingleResponsibilitySolution singleResponsibilitySolution = new SingleResponsibilitySolution();
Console.WriteLine(singleResponsibilitySolution.ToString());
singleResponsibilitySolution.Execute(); 

Console.WriteLine();

//Liskov Substitute
LiskovSubstituteProblem liskovSubstituteProblem = new LiskovSubstituteProblem();
Console.WriteLine(liskovSubstituteProblem.ToString());
liskovSubstituteProblem.Execute();
Console.WriteLine();
LiskovSubstituteSolution liskovSubstituteSolution = new LiskovSubstituteSolution();
Console.WriteLine(liskovSubstituteSolution.ToString());
liskovSubstituteSolution.Execute();





