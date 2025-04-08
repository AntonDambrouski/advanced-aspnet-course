namespace GeneralSystemData;

public interface IProjectServices
{
    Project CreateProject(ProjectDto projectDto);
    Project? GetProjectById(int Id);
    void UpdateProject(int Id, ProjectDto projectDto);
    void DeleteProject(int Id);
}
