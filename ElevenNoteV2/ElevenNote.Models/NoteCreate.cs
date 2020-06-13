using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteCreate
    {
        [Required]
        [MaxLength(25, ErrorMessage = "Title can be no more than 25 characters")]
        public string Title { get; set; }

        [MaxLength(5000)]
        public string Content { get; set; }
    }
}
