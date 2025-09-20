namespace ChoiceNote.WebAPI.Services.Models;

public class NoteModel
{
    public int NoteId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
