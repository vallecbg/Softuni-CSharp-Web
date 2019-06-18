using System;
using System.Collections.Generic;
using System.Text;
using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Submissions
{
    public class SubmissionCreateViewModel
    {
        [RequiredSis]
        public string ProblemId { get; set; }

        [RequiredSis]
        [StringLengthSis(30, 800, "Code should be between 30 and 800 characters!")]
        public string Code { get; set; }
    }
}
