using System;
using System.Collections.Generic;
using System.Text;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public ProblemsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProblemCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.Create(model.Name, model.TotalPoints);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            
            var submission = problemsService.GetSubmission(id);

            var allSubmissions = new List<SubmissionViewModel>();

            foreach (var currSubmission in submission.Problem.Submissions)
            {
                allSubmissions.Add(new SubmissionViewModel()
                {
                    AchievedResult = currSubmission.AchievedResult,
                    CreatedOn = currSubmission.CreatedOn.ToString(),
                    MaxPoints = currSubmission.Problem.Points,
                    SubmissionId = currSubmission.Id,
                    Username = currSubmission.User.Username
                });

            }

            var viewmodel = new ProblemDetailsViewModel
            {
                Id = id,
                Name = this.submissionsService.GetProblemName(id),
                Submissions = allSubmissions
            };

            return this.View(viewmodel);
        }

        
    }
}
