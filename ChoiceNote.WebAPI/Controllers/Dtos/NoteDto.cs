namespace ChoiceNote.WebAPI.Controllers.DTOs;

public record NoteDto
{
    public int NoteId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
