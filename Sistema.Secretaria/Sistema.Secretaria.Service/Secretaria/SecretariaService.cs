using Sistema.Secretaria.Repository.Secretaria;

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
}