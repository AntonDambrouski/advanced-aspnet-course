using DesignPatterns.Behavioral_patterns.Implementations;


namespace DesignPatterns.Behavioral_patterns
{

    public class StateSolution : IExecutor
    {
        public void Execute() 
        {
			Project project = new Project(new DevProjectState());
			project.Up();
			project.Down();
			project.Up();
			project.Up();
			project.Up();

		}
    }



	

	

}
