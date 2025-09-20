using ChoiceNote.WebAPI.Controllers.DTOs;
using ChoiceNote.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceNote.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteController(
    ILogger<NoteController> logger,
    INoteService noteService
    )
    : ControllerBase
{
    private readonly ILogger<NoteController> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    private readonly INoteService _noteService = noteService
        ?? throw new ArgumentNullException(nameof(noteService));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotesAsync()
    {
        _logger.LogInformation("GetNotesAsync called");

        var noteDtos = await _noteService.GetNotesAsync();

        if (noteDtos == null || !noteDtos.Any())
        {
            _logger.LogInformation("No notes found");
            return Ok(new List<NoteDto>());
        }

        _logger.LogInformation("Notes Count: {Count}", noteDtos.Count());

        return Ok(noteDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NoteDto>> GetNoteByIdAsync(int? id)
    {
        _logger.LogInformation("GetNote id:{id} called", id);

        if (id is null)
        {
            _logger.LogWarning("GetNote id:{id} is null", id);
            return BadRequest("id is null");
        }

        var noteDto = await _noteService.GetNoteByIdAsync(id.Value);

        if (noteDto is null)
        {
            _logger.LogWarning("Note id:{id} not found", id);
            return NotFound();
        }

        _logger.LogInformation("Note id:{id}", id);

        return Ok(noteDto);
    }
}
