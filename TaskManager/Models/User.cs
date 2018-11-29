using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{ 
    public partial class User
    {
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        public string Forename { get; set; }

        [Display(Name = "Surame")]
        public string Surname { get; set; }

        [Display(Name = "Mother's maiden name")]
        public string MothersMaidenName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Username")]
        [Required]
        public string UserName { get; set; }     

        public virtual List<Task> TaskList { get; set; }
    }
}
