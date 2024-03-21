using Microsoft.AspNetCore.Mvc;
using Sistema.Secretaria.Application.Professores.Requests;
using Sistema.Secretaria.Service.Professores;

namespace Sistema.Secretaria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessorController : ControllerBase
{
    public ProfessorService Service { get; set; }

    public ProfessorController()
    {
        Service = new ProfessorService();
    }

    [HttpGet("consultarNotas/{idTurma}/{idAluno}")]
    public async Task<IActionResult> ConsultarNotas([FromRoute] Guid idTurma, [FromRoute] Guid idAluno)
    {
        var notas = await Service.ConsultarNotas(idTurma, idAluno);

        return Ok(notas);
    }

    [HttpPatch("inserirNotas/{idTurma}/{idAluno}")]
    public async Task<IActionResult> InserirNotas([FromRoute] Guid idTurma, [FromRoute] Guid idAluno, [FromBody] InserirNotasRequest request)
    {
        await Service.InserirNotas(idTurma, idAluno, request);

        return NoContent();
    }

    [HttpDelete("deletarNotas/{idTurma}/{idAluno}")]
    public async Task<IActionResult> DeletarNotas([FromRoute] Guid idTurma, [FromRoute] Guid idAluno)
    {
        await Service.DeletarNotas(idTurma, idAluno);

        return NoContent();
    }

    [HttpGet("consultarPresenca/{idTurma}/{idAluno}")]
    public async Task<IActionResult> ConsultarPresenca([FromRoute] Guid idTurma, [FromRoute] Guid idAluno)
    {
        var presenca = await Service.ConsultarPresenca(idTurma, idAluno);

        return Ok(new { Presenca = presenca });
    }

    [HttpPatch("inserirPresenca/{idTurma}/{idAluno}")]
    public async Task<IActionResult> InserirPresenca([FromRoute] Guid idTurma, [FromRoute] Guid idAluno, [FromBody] InserirPresencaRequest request)
    {
        await Service.InserirPresenca(idTurma, idAluno, request);

        return NoContent();
    }

    [HttpPatch("alterarPresenca/{idTurma}/{idAluno}")]
    public async Task<IActionResult> AlterarPresenca([FromRoute] Guid idTurma, [FromRoute] Guid idAluno, [FromBody] AlterarPresencaRequest request)
    {
        await Service.AlterarPresenca(idTurma, idAluno, request);

        return NoContent();
    }
}