using Sistema.Secretaria.Application.Alunos.Response;
using Sistema.Secretaria.Domain.Aggregates;
using Sistema.Secretaria.Repository.Alunos;

namespace Sistema.Secretaria.Service.Alunos;
public class AlunoService
{
    public AlunoRepository Repository { get; set; }

    public AlunoService()
    {
        Repository = new AlunoRepository();
    }

    public async Task RealizarInscricao(Guid idAluno, Guid idTurma)
    {
        await Repository.RealizarInscricao(idAluno, idTurma);
    }

    public async Task CancelarInscricao(Guid idInscricao)
    {
        await Repository.CancelarInscricao(idInscricao);
    }

    public async Task<IEnumerable<ConsultarHistoricoResponse>> ConsultarHistorico(Guid idAluno)
    {
        return await Repository.ConsultarHistorico(idAluno);
    }

    public async Task<int> ConsultarFrequencia(Guid idAluno, Guid idInscricao)
    {
        return await Repository.ConsultarFrequencia(idAluno, idInscricao);
    }

    public async Task<IEnumerable<ConsultarNotasResponse>> ConsultarNotas(Guid idAluno, Guid idInscricao)
    {
        return await Repository.ConsultarNotas(idAluno, idInscricao);
    }
}