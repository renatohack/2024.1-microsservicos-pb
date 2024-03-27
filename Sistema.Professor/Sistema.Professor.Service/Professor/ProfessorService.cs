using Sistema.Professor.Applicatrion;
using Sistema.Professor.Repository.Professor;

namespace Sistema.Professor.Service.Professor
{
    public class ProfessorService
    {

        public ProfessorRepository Repository{ get; set; }

        public ProfessorService()
        {
            Repository = new ProfessorRepository();
        }

        public async Task<IEnumerable<NotasDto>> ConsultarNotas(Guid idTurma, Guid idAluno)
        {
            return await Repository.ObterNotas(idTurma, idAluno);
        }

        public async Task InserirNotas(Guid idTurma, Guid idAluno, NotasDto request)
        {
            await Repository.InserirNotas(idTurma, idAluno, request);
        }

        public async Task DeletarNotas(Guid idTurma, Guid idAluno)
        {
            await Repository.DeletarNotas(idTurma, idAluno);
        }

        public async Task<int> ConsultarPresenca(Guid idTurma, Guid idAluno)
        {
            return await Repository.ConsultarPresenca(idTurma, idAluno);
        }

        public async Task InserirPresenca(Guid idTurma, Guid idAluno, PresencaDto request)
        {
            await Repository.InserirPresenca(idTurma, idAluno, request);
        }

        public async Task AlterarPresenca(Guid idTurma, Guid idAluno, PresencaDto request)
        {
            await Repository.AtualizarPresenca(idTurma, idAluno, request);
        }
    }
}

