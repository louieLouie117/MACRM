using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{

    public class ServiveJobDetail

    {
        [Key]
        public int ServiveJobDetailId { get; set; }

        // Job Readyness
        public string ServiceAdvocateAssigned { get; set; }
        public string TechAssigned { get; set; }
        public string TriageDoneBy { get; set; }
        public string SpecialtyJob { get; set; }
        public bool PartsDelivered { get; set; }
        public bool RunningWithoutAllParts { get; set; }
        public bool AssignedInClick { get; set; }
        public bool ReadyToRun { get; set; }
        public bool Pined { get; set; }
        public bool TechAwareOfJob { get; set; }
        public bool JobInFieldApp { get; set; }
        public string SpecificTechRequired { get; set; }
        public bool ContactAttempt { get; set; }
        public bool CustomerContacted { get; set; }
        public bool CustomerReminded { get; set; }

        // Job Successfully Completed
        public bool SuccessfullyCompleted { get; set; }

        public string JobOutcome { get; set; }
        public string NextAction { get; set; }
        public bool CandidateForCancellation { get; set; }
        public string PartsIssueReason { get; set; }
        public bool FollowUpReminder { get; set; }
        public DateTime FollowUpDate { get; set; }
        public string ReasonNotResolved { get; set; }
        public bool EscalationOrEPP { get; set; }
        public string JobType { get; set; }
        public bool ResolvedToday { get; set; }
        public bool CustomerNoShow { get; set; }
        public string Exception { get; set; }
        public bool GspnCmp { get; set; }



        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        // Relationships

    }
}