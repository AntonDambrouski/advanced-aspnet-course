using DesignPatterns.Behavioral_patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral_patterns
{
	// Без применения паттерна, в любом методе, поведение которого зависит от состояния
	// приходится писать большие конструкции if или switch и при добавлении новых состояний
	// нужно будет изменить эти конструкции во всех методах
	public class StateProblem : IExecutor
	{
		public void Execute()
		{
			ProjectProblem problem = new ProjectProblem();
			problem.SetNewState(ProjectState.Dev);
		}
	}

	public enum ProjectState
	{
		Dev,
		Test,
		Prod
	}
	public class ProjectProblem
	{
		public ProjectState State { get; set; }
		public void SetNewState(ProjectState state)
		{
			switch (state)
			{
				case ProjectState.Dev:
					Console.WriteLine("new state is Dev");
					break;
				case ProjectState.Test:
					Console.WriteLine("new state is Test");
					break;
				case ProjectState.Prod:
					Console.WriteLine("new state is Prod");
					break;
			}

		}

	}
}
