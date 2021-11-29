using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KcPilot.Models
{


    public class NoteComment

    {
        [Key]
        public int NoteCommentId { get; set; }

        public string Notes { get; set; }

        public string UserAddedNotes { get; set; }
        public string UserTitle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        // Relationships

    }
}