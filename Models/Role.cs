using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{


    public class Role

    {
        [Key]
        public int RoleId { get; set; }

        public string Title { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        // Relationships
        // fKey for user
        public int UserId { get; set; }
        // navP
        public User Users { get; set; }

    }
}