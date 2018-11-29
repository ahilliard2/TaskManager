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
        [Required(ErrorMessage = "First Name Is Required")]
        public string Forename { get; set; }

        [Display(Name = "Surame")]
        [Required(ErrorMessage = "Surame Is Required")]
        public string Surname { get; set; }

        [Display(Name = "Mother's maiden name")]
        [Required(ErrorMessage = "Mothers maiden name Is Required")]
        public string MothersMaidenName { get; set; }

        //[Display(Name = "Email Id")]
        //[RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        //[Required(ErrorMessage = "Employee Name Is Required")]
        //public string EmailId { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }     

        public virtual List<Task> TaskList { get; set; }
    }
}
