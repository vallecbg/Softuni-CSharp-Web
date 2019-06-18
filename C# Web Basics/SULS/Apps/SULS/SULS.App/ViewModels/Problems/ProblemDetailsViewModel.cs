using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemDetailsViewModel
    {
        public ProblemDetailsViewModel()
        {
            this.Submissions = new List<SubmissionViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        

        
        public ICollection<SubmissionViewModel> Submissions { get; set; }
    }
}
