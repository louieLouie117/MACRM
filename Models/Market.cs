using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{


    public class Market

    {
        [Key]
        public int MarketId { get; set; }

        public string Location { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        // Relationships

        // fKey for user
        public int UserId { get; set; }
        // navP
        public User User { get; set; }
    }
}