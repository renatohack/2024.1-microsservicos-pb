using Sistema.Aluno.Application;
using Sistema.Aluno.Repository;

namespace Sistema.Aluno.Service
{
    public class AlunoService
    {
        public AlunoRepository Repository { get; set; }

        public AlunoService()
        {
            Repository = new AlunoRepository();
        }

        public async Task RealizarInscricao(Guid idAluno, RealizarInscricaoRequest request)
        {
            await Repository.RealizarInscricao(idAluno, request);
        }
    }
}
