using ChoiceNote.WebAPI.Services.Models;

namespace ChoiceNote.WebAPI.Data.Repositories;

public interface INoteRepository
{
    /// <summary>
    /// すべての Note を取得する
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<NoteModel>> GetNotesAsync();

    /// <summary>
    /// 指定 ID の Note を取得する
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<NoteModel?> GetNoteByIdAsync(int id);
}
