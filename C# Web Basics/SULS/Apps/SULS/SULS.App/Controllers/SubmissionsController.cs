using System;
using System.Collections.Generic;
using System.Text;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Models;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;
        private readonly IUsersService usersService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService, IUsersService usersService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
            this.usersService = usersService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemsService.GetById(id);

            if (problem == null)
            {
                return Redirect("/");
            }

            var viewModel = new ProblemModel()
            {
                ProblemId = problem.Id,
                Name = problem.Name
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(SubmissionCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Submissions/Create");
            }

            var problem = this.problemsService.GetById(model.ProblemId);
            var user = this.usersService.GetById(User.Id);

            var rnd = new Random();
            var randomScore = rnd.Next(0, problem.Points);

            var submission = new Submission()
            {
                AchievedResult = randomScore,
                Code = model.Code,
                CreatedOn = DateTime.UtcNow,
                UserId = User.Id,
                ProblemId = problem.Id
            };

            this.submissionsService.Create(submission);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(SubmissionDeleteModel model)
        {
            this.submissionsService.DeteleSubmission(model.Id);
            return Redirect("/");
        }
    }
}
