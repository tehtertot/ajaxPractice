using System;

namespace ajaxNotesTest.Models
{
    public class Note : BaseEntity {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt {get; set; }
    }
}