using Microsoft.AspNetCore.Mvc;
using Sistema.Secretaria.Application.Alunos.Requests;
using Sistema.Secretaria.Service.Alunos;

namespace Sistema.Secretaria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : ControllerBase
{
    public AlunoService Service { get; set; }

    public AlunoController()
    {
        Service = new AlunoService();
    }

    [HttpPost("{idAluno}/realizarInscricao")]
    public async Task<IActionResult> RealizarInscricao([FromRoute] Guid idAluno, [FromBody] RealizarInscricaoRequest request)
    {
        await Service.RealizarInscricao(idAluno, request.IdTurma);

        return NoContent();
    }

    [HttpPatch("cancelarInscricao")]
    public async Task<IActionResult> CancelarInscricao([FromBody] CancelarInscricaoRequest request)
    {
        await Service.CancelarInscricao(request.IdInscricao);

        return NoContent();
    }

    [HttpGet("{idAluno}/consultarHistorico")]
    public async Task<IActionResult> ConsultarHistorico([FromRoute] Guid idAluno)
    {
        var historico = await Service.ConsultarHistorico(idAluno);

        return Ok(historico);
    }

    [HttpGet("{idAluno}/consultarPresenca/{idInscricao}")]
    public async Task<IActionResult> ConsultarPresenca([FromRoute] Guid idAluno, [FromRoute] Guid idInscricao)
    {
        var presenca = await Service.ConsultarPresenca(idAluno, idInscricao);

        return Ok(new { Presenca = presenca });
    }

    [HttpGet("{idAluno}/consultarNotas/{idInscricao}")]
    public async Task<IActionResult> ConsultarNotas([FromRoute] Guid idAluno, [FromRoute] Guid idInscricao)
    {
        var notas = await Service.ConsultarNotas(idAluno, idInscricao);

        return Ok(notas);
    }
}
