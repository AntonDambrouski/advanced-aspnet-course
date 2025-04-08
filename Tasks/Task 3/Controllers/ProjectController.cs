using GeneralSystemData;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectServices;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger,IProjectServices projectServices)
        {
            _logger=logger;
            _projectServices=projectServices;
        }

        [HttpPost]        
        public ActionResult Create(ProjectDto projectDto)
        {
            var newProject=_projectServices.CreateProject(projectDto);
            if(newProject!=null)
            {
                return View(newProject);
            }
            return View(newProject);
        }
        // GET: Controllers
        public ActionResult Index()
        {
            return View();
        }

    }
}
