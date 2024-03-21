using Microsoft.AspNetCore.Mvc;
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
    public IActionResult CriarAluno(AlunoReqeust reqeust)
    {
        Service.CriarAluno(reqeust.Nome);

        return Ok();
    }
}

public class AlunoReqeust
{
    public string Nome { get; set; }
}