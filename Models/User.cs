using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{

    public enum AccountType { Admin = 0, ServiceAdvocate = 1, Triage = 2, Tech = 3, FiledCoach = 4, SACoach = 5, HR = 6 }
    public enum AccountStatus { Active = 0, InActive = 1 }


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



        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DirectPhoneNumber { get; set; }

        public string TeamLink { get; set; }

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
        public string Confirm { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePic { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

    }
}