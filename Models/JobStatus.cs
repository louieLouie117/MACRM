using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{

    public class JobStatus

    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        // fKey for user
        public int UserId { get; set; }
        // navP
        public User User { get; set; }

    }
}