using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SULS.Models
{
    public class Problem
    {
        public Problem()
        {
            //TODO: check if needed hashset
            this.Submissions = new List<Submission>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        //TODO: Check
        [Range(50, 300)]
        public int Points { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}
