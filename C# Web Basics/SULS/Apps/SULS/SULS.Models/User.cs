using System;
using System.Collections.Generic;

namespace SULS.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            //TODO: check if needed hashset
            this.Submissions = new List<Submission>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        //TODO: Check
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}