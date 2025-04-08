using GeneralSystemData;

public class WorkerServices : IWorkerServices
{
    private readonly List<Worker> _workers = new List<Worker>();

    public WorkerServices()
    {
        _workers.Add(new Worker()
        {
            Id=1,
            Name="Иван",
            Surname="Иваный",
            WorkProject=new List<Project>()
        });
         _workers.Add(new Worker()
        {
            Id=2,
            Name="Петр",
            Surname="Петрович",
            WorkProject=new List<Project>()
        });
         _workers.Add(new Worker()
        {
            Id=1,
            Name="Сергей",
            Surname="кто-то",
            WorkProject=new List<Project>()
        });
    }

    public Worker CreateWorker(WorkerDto workerDto)
    {
        int Id=_workers.Count+1;
        Worker worker= new Worker();
        worker.Name=workerDto.Name;
        worker.Surname=workerDto.Surname;
        worker.Id=Id;
        return worker;
    }

    public void DeleteWorker(int Id)
    {
        var getWorker= _workers.FirstOrDefault(x => x.Id==Id);
        if (getWorker!=null)
        {
            _workers.Remove(getWorker);
        }
    }

    public Worker? GetWorkerById(int Id)
    {
        var getWorker=_workers.FirstOrDefault(x => x.Id == Id);
        if (getWorker!=null) return getWorker;
        return null;
    }

    public void UpdateWorker(int Id, WorkerDto workerDto)
    {
        var getWorker = _workers.FirstOrDefault(x => x.Id== Id);
        if (getWorker!=null)
        {
            getWorker.Surname = workerDto.Surname;
            getWorker.Name=workerDto.Name;
        }
    }
}