using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{

    public class JobStatus

    {
        [Key]
        public int JobStatusId { get; set; }
        public string Outcome { get; set; }
        public string TechName { get; set; }
        public string ServiceJobNumber { get; set; }
        public string SA { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

    }
}