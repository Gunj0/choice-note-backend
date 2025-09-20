using ChoiceNote.WebAPI.Controllers.DTOs;

namespace ChoiceNote.WebAPI.Services;

public interface INoteService
{
    /// <summary>
    /// すべての Note を取得する
    /// </summary>
    /// <returns>NoteDtoリスト</returns>
    Task<IEnumerable<NoteDto>> GetNotesAsync();

    /// <summary>
    /// 指定 ID の Note を取得する
    /// </summary>
    /// <param name="id">NoteId</param>
    /// <returns></returns>
    Task<NoteDto?> GetNoteByIdAsync(int id);
}
