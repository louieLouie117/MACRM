using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{

    public enum UserRole { Admin = 0, ServiceAdvocate = 1, SACoach = 2, Triage = 3, Tech = 4 }
    public enum AccountStatus { Active = 0, InActive = 1 }
    public enum OnlineStatus { Active = 0, Away = 1, Offline = 2, NotAvailed = 3 }

    public class User

    {
        [Key]
        public int UserId { get; set; }
        public string Market { get; set; }
        public string MarketCode { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(UserRole))]
        public UserRole UserRole { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(AccountStatus))]
        public AccountStatus AccountStatus { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(OnlineStatus))]
        public OnlineStatus OnlineStatus { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public string PhoneNumber { get; set; }
        public string Extention { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public string AppVersion { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

    }
}