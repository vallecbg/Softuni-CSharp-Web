using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext db;

        public SubmissionsService(SULSContext db)
        {
            this.db = db;
        }

        public void Create(Submission submission)
        {
            this.db.Submission.Add(submission);
            this.db.SaveChanges();
        }

        public int GetAllCountOfSubmissions(Problem problem)
        {
            //TODO: check
            return this.db.Submission.Count(x => x.Problem.Equals(problem));
        }

        //TODO: Move it in problems service
        public string GetProblemName(string currentProblemId)
        {
            var currentProblem = db.Problems.Include(x => x.Submissions).Single(x => x.Id == currentProblemId);

            return currentProblem.Name;
        }

        public void DeteleSubmission(string submissionId)
        {
            var submission = this.db.
                Submission.Include(x => x.Problem).Include(x => x.User).Single(x => x.Id == submissionId);
            this.db.Submission.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
