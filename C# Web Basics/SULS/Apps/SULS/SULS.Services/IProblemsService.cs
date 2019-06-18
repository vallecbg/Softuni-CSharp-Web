using System;
using System.Collections.Generic;
using System.Text;
using SULS.Models;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void Create(string name, int totalPoints);

        List<Problem> GetAll();

        Submission GetSubmission(string problemId);

        Problem GetById(string id);
    }
}
