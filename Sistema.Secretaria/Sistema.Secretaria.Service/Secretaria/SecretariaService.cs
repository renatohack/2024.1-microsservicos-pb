using Sistema.Secretaria.Application.Secretaria.Response;
using Sistema.Secretaria.Repository.Secretarias;

namespace Sistema.Secretaria.Service.Secretaria;
public class SecretariaService
{
    public SecretariaRepository Repository { get; set; }

    public SecretariaService()
    {
        Repository = new SecretariaRepository();
    }

    public async Task CriarAluno(string nome)
    {
        await Repository.CriarAluno(nome);
    }

    public async Task<ObterAlunoResponse> ObterAluno(Guid id)
    {
        var aluno = await Repository.ObterAluno(id);

        return aluno;
    }
}