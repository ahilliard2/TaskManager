using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }

        [Required]
        public string TaskDescription { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Complete { get; set; }

        public virtual User User { get; set; }
    }
}