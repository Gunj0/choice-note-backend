using System;

namespace ChoiceNote.WebAPI.Entities;

public class ChoiceNote
{
    public int ChoiceNoteId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
