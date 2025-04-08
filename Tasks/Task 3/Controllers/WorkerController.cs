using Microsoft.AspNetCore.Mvc;
using GeneralSystemData;
namespace MyApp.Namespace
{
    public class WorkerController : Controller
    {
        private readonly IWorkerServices _workerService;
        private readonly ILogger _logger;
        public WorkerController(ILogger logger, IWorkerServices workerService)
        {
            _logger= logger;
            _workerService= workerService;
        }

        // GET: Controllers
        public ActionResult Index()
        {
            return View();
        }

    }
}
