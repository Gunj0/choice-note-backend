using System;

namespace ChoiceNote.WebAPI.DTOs;

public class ChoiceNoteDto
{
    public int ChoiceNoteId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
