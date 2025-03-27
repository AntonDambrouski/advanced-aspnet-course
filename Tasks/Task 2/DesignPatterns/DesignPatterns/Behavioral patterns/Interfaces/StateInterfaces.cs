using DesignPatterns.Behavioral_patterns.Implementations;


namespace DesignPatterns.Behavioral_patterns.Interfaces
{
	public interface IProjectState
	{
		public void Down(Project project);
		public void Up(Project project);
	}
}
