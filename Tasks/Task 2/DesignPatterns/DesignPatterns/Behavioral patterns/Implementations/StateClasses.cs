using DesignPatterns.Behavioral_patterns.Interfaces;


namespace DesignPatterns.Behavioral_patterns.Implementations
{
	
	public class Project
	{
		public IProjectState State { get; set; }
		public Project(IProjectState projectState)
		{
			State = projectState;
		}
		public void Down()
		{
			State.Down(this);
		}

		public void Up()
		{
			State.Up(this);
		}
	}


	public class DevProjectState : IProjectState
	{
		public void Down(Project project)
		{
			Console.WriteLine("Continue development");
		}

		public void Up(Project project)
		{
			Console.WriteLine("Start test");
			project.State = new TestProjectState();
		}
	}


	public class TestProjectState : IProjectState
	{
		public void Down(Project project)
		{
			Console.WriteLine("Back to development");
			project.State = new DevProjectState();
		}

		public void Up(Project project)
		{
			Console.WriteLine("Public project");
			project.State = new ProdProjectState();
		}
	}


	public class ProdProjectState : IProjectState
	{
		public void Down(Project project)
		{
			Console.WriteLine("Back to test");
			project.State = new TestProjectState();
		}

		public void Up(Project project)
		{
			Console.WriteLine("Stay in prod");
		}
	}
}
