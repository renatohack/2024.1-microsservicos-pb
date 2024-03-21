using Sistema.Secretaria.Domain.Aggregates;
using Sistema.Secretaria.Repository.Secretarias;

namespace Sistema.Secretaria.Service.Secretaria;
public class SecretariaService
{
    public SecretariaRepository Repository { get; set; }

    public SecretariaService()
    {
        Repository = new SecretariaRepository();
    }

    public void CriarAluno(string nome)
    {
        Repository.CriarAluno(nome);
    }

    public async Task<Aluno> ObterAluno(Guid id)
    {
        var aluno = await Repository.ObterAluno(id);

        return aluno;
    }
}