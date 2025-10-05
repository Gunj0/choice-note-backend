using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChoiceNote.WebAPI.Data.Entities;

// TODO: Postgresではクエリに大文字を使うときはダブルクォートで囲む必要があるため
// テーブル名とカラム名は小文字に統一する

[Table("Notes")]
public class Note
{
    [Key] // 主キー
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 自動採番
    public int NoteId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Title { get; set; }

    [MaxLength(1000)]
    public string? Content { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }
}
