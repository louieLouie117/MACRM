using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{

    // public enum JobStatus { NeedsPreScreen = 0, PreScreenSuccessful = 1, PreScreenUnsuccessful = 2, SentToTriage = 3, MoreInfoNeedByTriage = 4, PartsOrder = 5, PartsInTransition = 6, Completed = 7, CompletionReviewed = 8, Reschedule = 9 }

    public class ServiceJob

    {
        [Key]
        public int ServiceJobId { get; set; }
        // 

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(JobStatus))]
        // public JobStatus JobStatus { get; set; }
        public string JobColor { get; set; }
        public string SJNumber { get; set; }


        public bool InWarrantyCustomer { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public bool GreetedCustomer { get; set; }
        public bool ExplainDiagnosticFees { get; set; }
        public bool ConfirmServiceAndShippingAddress { get; set; }
        public bool InformCallMaybeRecordedForQualityAndTraining { get; set; }
        public bool ConfirmModelAndSerialNumber { get; set; }
        public bool AskedCovidQuestions { get; set; }
        public bool SetAnAppointmentDate { get; set; }
        public DateTime AppointmentDate { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        // Relationships

    }
}