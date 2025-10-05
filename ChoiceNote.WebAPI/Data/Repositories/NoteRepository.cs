using ChoiceNote.WebAPI.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace ChoiceNote.WebAPI.Data.Repositories;

public class NoteRepository(ChoiceNoteDbContext dbContext)
    : INoteRepository
{
    private readonly ChoiceNoteDbContext _dbContext = dbContext
        ?? throw new ArgumentNullException(nameof(dbContext));

    /// <summary>
    /// すべての Note を取得する
    /// </summary>
    /// <returns>NoteModelリスト</returns>
    public async Task<IEnumerable<NoteModel>> GetNotesAsync()
    {
        var entities = await _dbContext.Notes.ToListAsync();
        return entities.Select(e => new NoteModel
        {
            NoteId = e.NoteId,
            Title = e.Title,
            Content = e.Content,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt
        });
    }

    /// <summary>
    /// 指定 ID の Note を取得する
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<NoteModel?> GetNoteByIdAsync(int id)
    {
        var entities = await _dbContext.Notes.FirstOrDefaultAsync(n => n.NoteId == id);
        return entities is null ? null : new NoteModel
        {
            NoteId = entities.NoteId,
            Title = entities.Title,
            Content = entities.Content,
            CreatedAt = entities.CreatedAt,
            UpdatedAt = entities.UpdatedAt
        };
    }
}
