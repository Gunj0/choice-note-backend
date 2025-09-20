using ChoiceNote.WebAPI.Controllers.DTOs;
using ChoiceNote.WebAPI.Data.Repositories;

namespace ChoiceNote.WebAPI.Services;

public class NoteService(
    INoteRepository noteRepository)
    : INoteService
{
    private readonly INoteRepository _noteRepository = noteRepository
        ?? throw new ArgumentNullException(nameof(noteRepository));

    /// <summary>
    /// すべての Note を取得する
    /// </summary>
    /// <returns>NoteDtoリスト</returns>
    public async Task<IEnumerable<NoteDto>> GetNotesAsync()
    {
        var noteModels = await _noteRepository.GetNotesAsync();

        return noteModels.Select(model => new NoteDto
        {
            NoteId = model.NoteId,
            Title = model.Title,
            Content = model.Content,
            CreatedAt = model.CreatedAt
        });
    }

    /// <summary>
    /// 指定 ID の Note を取得する
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<NoteDto?> GetNoteByIdAsync(int id)
    {
        var noteModel = await _noteRepository.GetNoteByIdAsync(id);

        if (noteModel is null)
        {
            return null;
        }

        return new NoteDto
        {
            NoteId = noteModel.NoteId,
            Title = noteModel.Title,
            Content = noteModel.Content,
            CreatedAt = noteModel.CreatedAt
        };
    }

}
