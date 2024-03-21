using Sistema.Secretaria.Repository.Alunos;

namespace Sistema.Secretaria.Service.Alunos;
public class AlunoService
{
    public AlunoRepository Repository { get; set; }

    public AlunoService()
    {
        Repository = new AlunoRepository();
    }

    public void RealizarInscricao(Guid idAluno, Guid idTurma)
    {
        Repository.RealizarInscricao(idAluno, idTurma);
    }
}