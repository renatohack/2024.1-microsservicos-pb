using Microsoft.AspNetCore.Mvc;
using Sistema.Secretaria.Application.Secretaria.Requests;
using Sistema.Secretaria.Service.Secretaria;

namespace Sistema.Secretaria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecretariaController : ControllerBase
{
    public SecretariaService Service { get; set; }

    public SecretariaController()
    {
        Service = new SecretariaService();
    }

    [HttpPost("criarAluno")]
    public async Task<IActionResult> CriarAluno([FromBody] CriarAlunoRequest request)
    {
        await Service.CriarAluno(request.Nome);

        return Ok();
    }

    [HttpGet("obterAluno/{id}")]
    public async Task<IActionResult> ObterAluno([FromRoute] Guid id)
    {
        var aluno = await Service.ObterAluno(id);

        return Ok(aluno);
    }
}