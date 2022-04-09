using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{


    public class JobComment

    {
        [Key]
        public int JobCommentId { get; set; }

        public string Notes { get; set; }

        public string Job { get; set; }
        public string UserTitle { get; set; }
        public bool EditComment { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        // Relationships
        // fKey for user
        public int JobId { get; set; }
        // navP
        public Job Jobs { get; set; }

    }
}