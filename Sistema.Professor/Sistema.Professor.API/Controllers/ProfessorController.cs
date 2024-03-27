using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Professor.Applicatrion;
using Sistema.Professor.Service.Professor;

namespace Sistema.Professor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> InserirNotas([FromRoute] Guid idTurma, [FromRoute] Guid idAluno, [FromBody] NotasDto notas)
        {
            await Service.InserirNotas(idTurma, idAluno, notas);

            return Ok(notas);
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
        public async Task<IActionResult> InserirPresenca([FromRoute] Guid idTurma, [FromRoute] Guid idAluno, [FromBody] PresencaDto request)
        {
            await Service.InserirPresenca(idTurma, idAluno, request);

            return NoContent();
        }

        [HttpPatch("alterarPresenca/{idTurma}/{idAluno}")]
        public async Task<IActionResult> AlterarPresenca([FromRoute] Guid idTurma, [FromRoute] Guid idAluno, [FromBody] PresencaDto request)
        {
            await Service.AlterarPresenca(idTurma, idAluno, request);

            return NoContent();
        }
    }

}
