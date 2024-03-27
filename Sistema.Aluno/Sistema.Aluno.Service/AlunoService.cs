using Sistema.Aluno.Application;
using Sistema.Aluno.Core;
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

        public async Task<ResponseModel> RealizarInscricao(Guid idAluno, RealizarInscricaoRequest request)
        {
            return await Repository.RealizarInscricao(idAluno, request);
        }

        public async Task CancelarInscricao(CancelarInscricaoRequest request)
        {
            await Repository.CancelarInscricao(request);
        }

        public async Task<IEnumerable<ConsultarHistoricoResponse>> ConsultarHistorico(Guid idAluno)
        {
            return await Repository.ConsultarHistorico(idAluno);
        }

        public async Task<int> ConsultarPresenca(Guid idAluno, Guid idInscricao)
        {
            return await Repository.ConsultarPresenca(idAluno, idInscricao);
        }
    }
}
