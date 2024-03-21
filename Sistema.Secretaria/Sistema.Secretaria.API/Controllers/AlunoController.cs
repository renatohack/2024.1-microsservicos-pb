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
    public IActionResult RealizarInscricao([FromRoute] Guid idAluno, [FromBody] RealizarInscricaoRequest request)
    {
        Service.RealizarInscricao(idAluno, request.IdTurma);

        return Ok();
    }
}
