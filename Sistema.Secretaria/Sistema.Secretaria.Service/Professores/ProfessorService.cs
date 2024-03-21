using Sistema.Secretaria.Application.Comuns;
using Sistema.Secretaria.Application.Professores.Requests;
using Sistema.Secretaria.Repository.Professores;

namespace Sistema.Secretaria.Service.Professores;
public class ProfessorService
{
    public ProfessorRepository Repository { get; set; }

    public ProfessorService()
    {
        Repository = new ProfessorRepository();
    }

    public async Task<IEnumerable<ConsultarNotasResponse>> ConsultarNotas(Guid idTurma, Guid idAluno)
    {
        return await Repository.ConsultarNotas(idTurma, idAluno);
    }

    public async Task InserirNotas(Guid idTurma, Guid idAluno, InserirNotasRequest request)
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

    public async Task InserirPresenca(Guid idTurma, Guid idAluno, InserirPresencaRequest request)
    {
        await Repository.InserirPresenca(idTurma, idAluno, request);
    }

    public async Task AlterarPresenca(Guid idTurma, Guid idAluno, AlterarPresencaRequest request)
    {
        await Repository.AlterarPresenca(idTurma, idAluno, request);
    }
}