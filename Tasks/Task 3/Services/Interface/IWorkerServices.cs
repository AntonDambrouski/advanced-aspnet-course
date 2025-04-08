using GeneralSystemData;

public interface IWorkerServices
{
    Worker CreateWorker(WorkerDto workerDto);
    Worker? GetWorkerById(int Id);
    void UpdateWorker(int Id, WorkerDto workerDto);
    void DeleteWorker(int Id);
}