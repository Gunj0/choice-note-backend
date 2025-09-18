using System;
using ChoiceNote.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChoiceNote.WebAPI.Data;

/// <summary>
/// ChoiceNoteのDBコンテキスト
/// </summary>
/// <param name="options">DbContextのオプション</param>
public class ChoiceNoteDbContext(
    DbContextOptions<ChoiceNoteDbContext> options)
    : DbContext(options)
{
    /// <summary>
    /// Note Entity
    /// </summary>
    public DbSet<Note> Notes { get; set; }

    public override int SaveChanges()
    {
        ApplyTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        ApplyTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// エンティティのCreatedAtとUpdatedAtを自動設定
    /// </summary>
    private void ApplyTimestamps()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is Note &&
                (e.State == EntityState.Added ||
                    e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (Note)entry.Entity;
            var now = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = now;
            }

            entity.UpdatedAt = now;
        }
    }
}
