using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;

        public ProblemsService(SULSContext db)
        {
            this.db = db;
        }

        public void Create(string name, int totalPoints)
        {
            var problem = new Problem
            {
                Name = name,
                Points = totalPoints,

            };
            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public List<Problem> GetAll()
        {
            return this.db.Problems.ToList();
        }

        public Submission GetSubmission(string problemId)
        {
            return this.db.
                Submission.Include(x => x.Problem).Include(x => x.User).Single(x => x.Problem.Id == problemId);
        }

        public Problem GetById(string id)
        {
            return this.db.Problems
                .Include(x => x.Submissions)
                .Single(x => x.Id == id);
        }
    }
}
