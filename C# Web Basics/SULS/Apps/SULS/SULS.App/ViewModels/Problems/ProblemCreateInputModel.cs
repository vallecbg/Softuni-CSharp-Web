using System;
using System.Collections.Generic;
using System.Text;
using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemCreateInputModel
    {

        [RequiredSis]
        [StringLengthSis(5, 20, "Name should be between 5 and 20 characters")]
        public string Name { get; set; }


        [RequiredSis]
        [RangeSis(50, 300, "Total Points should be between 50 and 300 characters")]
        public int TotalPoints { get; set; }
    }
}
