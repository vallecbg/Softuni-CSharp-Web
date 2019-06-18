using System.Collections.Generic;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Home;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public HomeController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var allProblems = problemsService.GetAll();
                var viewModel = new List<CurrentProblemViewModel>();
                foreach (var problem in allProblems)
                {
                    var currProblem = new CurrentProblemViewModel
                    {
                        Id = problem.Id,
                        Name = problem.Name,
                        Count = this.submissionsService.GetAllCountOfSubmissions(problem)
                    };
                    viewModel.Add(currProblem);
                }

                var resultViewModel = new AllProblemsViewModel
                {
                    Problems = viewModel
                };
                return this.View(resultViewModel, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }


    }
}