using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Aluno.Service;
using Sistema.Aluno.Application;

namespace Sistema.Aluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            await Service.RealizarInscricao(idAluno, request);

            return NoContent();
        }


    }
}
