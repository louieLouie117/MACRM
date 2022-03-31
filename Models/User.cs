using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{

    public enum AccountType { Admin = 0, ServiceAdvocate = 1, SACoach = 2, Triage = 3, Tech = 4 }
    public enum AccountStatus { Active = 0, InActive = 1 }
    public enum OnlineStatus { Active = 0, Away = 1, Offline = 2, NotAvailed = 3 }

    public class User

    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(AccountType))]
        public AccountType AccountType { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(AccountStatus))]
        public AccountStatus AccountStatus { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(OnlineStatus))]
        public OnlineStatus OnlineStatus { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password { get; set; }


        public string ProfilePhoto { get; set; }
        public string PhoneNumber { get; set; }


        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

    }
}