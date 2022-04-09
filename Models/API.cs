using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{

    // public enum JobStatus { NeedsPreScreen = 0, PreScreenSuccessful = 1, PreScreenUnsuccessful = 2, SentToTriage = 3, MoreInfoNeedByTriage = 4, PartsOrder = 5, PartsInTransition = 6, Completed = 7, CompletionReviewed = 8, Reschedule = 9 }

    public class API

    {
        [Key]
        public int JobStatusId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        // Job Status
        public string Market { get; set; }
        public string MarketCode { get; set; }
        public string ServiceStatus { get; set; }
        public string JobStatus { get; set; }
        public string JobStatusColor { get; set; }
        public string ServiceJobNumber { get; set; }
        public string SamsungJobNumber { get; set; }
        public string InWarranty { get; set; }


        // Appointment info
        [Display(Name = "Appointment Day")]
        public DateTime AppointmentDay { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string AppointmentWindow { get; set; }
        public string SpecialInstructions { get; set; }
        public int NumberOfConactMede { get; set; }
        public int NumberOfTimesReschedual { get; set; }

        //  Customer info
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Product info
        public string ProductLine { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public bool TwoManJob { get; set; }



        // Assignment info
        public string TechName { get; set; }
        public bool TechAssigned { get; set; }
        public string ServiceAdvocateName { get; set; }
        public bool SAAssigned { get; set; }
        public string SecondPersonName { get; set; }
        public bool SecondPersonAssigned { get; set; }



        // fKey for user
        public int UserId { get; set; }
        // navP
        public User User { get; set; }


    }
}