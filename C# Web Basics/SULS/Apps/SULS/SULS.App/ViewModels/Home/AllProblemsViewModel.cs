using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Home
{
    public class AllProblemsViewModel
    {
        public AllProblemsViewModel()
        {
            //TODO: check if needed hashset
            this.Problems = new List<CurrentProblemViewModel>();
        }

        public ICollection<CurrentProblemViewModel> Problems { get; set; }

    }
}
