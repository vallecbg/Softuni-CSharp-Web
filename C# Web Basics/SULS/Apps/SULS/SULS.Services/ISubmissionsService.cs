using System;
using System.Collections.Generic;
using System.Text;
using SULS.Models;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        void Create(Submission submission);

        int GetAllCountOfSubmissions(Problem problem);

        string GetProblemName(string currentProblemId);
        void DeteleSubmission(string submissionId);


    }
}
