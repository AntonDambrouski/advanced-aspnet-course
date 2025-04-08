using GeneralSystemData;

public class ProjectServices :IProjectServices
{
    private readonly List<Project> _projects=new List<Project>();
    public ProjectServices()
    {
        _projects.Add(new Project()
        {
            Id=1,
            Name = "Замена многоканатной подъемной машины",
            NumberContract=72,
            DateOfConclusion=new DateTime(0, 1, 1),
            ListConstruction=new List<Construction>()
            {
                new Construction()
                {
                    Number=3,
                    Name="Севераня башня",
                },
                new Construction()
                {
                    Number=4,
                    Name="южная башня", 
                }
            }
        });
        _projects.Add(new Project()
        {
            Id=2,
            Name = "Замена вакуум-кристаллизатора",
            NumberContract=72,
            DateOfConclusion=new DateTime(0, 1, 1),
            ListConstruction=new List<Construction>()
            {
                new Construction()
                {
                    Number=12,
                    Name="СОФ",
                },
                new Construction()
                {
                    Number=25,
                    Name="МПСГИ", 
                }
            }
        });
    }

    public Project CreateProject(ProjectDto projectDto)
    {
        int Id=_projects.Count+1;
        Project project=new Project();
        project.NumberContract=projectDto.numberContract;
        project.Name=projectDto.Name;

        //TODO выполинть констурктор текущей даты или даты заключения договора 
        project.DateOfConclusion=projectDto.DateOfConclusion; 
        project.ListConstruction=new List<Construction>();

        return project;
    }

    public void DeleteProject(int Id)
    {
        var getProject=_projects.Find(x => x.Id==Id);
        if(getProject!=null)
        {
            _projects.Remove(getProject);
        }
    }

    public Project? GetProjectById(int Id)
    {
        var getProject=_projects.FirstOrDefault(x=>x.Id==Id);
        if(getProject!=null)
        {
            return getProject;
        }
        return null;
    }

    public void UpdateProject(int Id,ProjectDto projectDto)
    {
        var getProject = _projects.FirstOrDefault(x=>x.Id==Id);
        if(getProject!=null)
        {
            getProject.Name=projectDto.Name;
            getProject.DateOfConclusion=projectDto.DateOfConclusion;
            getProject.NumberContract=projectDto.numberContract;
        }
    }
}