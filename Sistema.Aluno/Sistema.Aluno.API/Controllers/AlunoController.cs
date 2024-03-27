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
            var response = await Service.RealizarInscricao(idAluno, request);

            if (response.StatusCode == 204){

                return NoContent();
            } 
            
            else {

                return BadRequest(response.Message);

            }

            
        }


    }
}
