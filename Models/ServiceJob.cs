using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{

    public enum JobStatus { NeedsPreScreen = 0, PreScreenSuccessful = 1, PreScreenUnsuccessful = 2, SentToTriage = 3, PartsOrder = 4, PartsInTransition = 5, Completed = 6, SuccessfullyCompleted = 7, Reschedule = 8 }

    public class ServiceJob

    {
        [Key]
        public int ServiceJobId { get; set; }

        public string SJNumber { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(JobStatus))]
        public JobStatus JobStatus { get; set; }
        public string JobColor { get; set; }


        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }



        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        // Relationships

    }
}