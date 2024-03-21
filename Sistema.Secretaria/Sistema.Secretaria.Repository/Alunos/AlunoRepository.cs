using Dapper;
using Npgsql;

namespace Sistema.Secretaria.Repository.Alunos;
public class AlunoRepository
{
    public NpgsqlConnection _connection { get; set; }

    public AlunoRepository()
    {
        _connection = new NpgsqlConnection(@"HOST=localhost:5432;DataBase=projeto_bloco;UserName=postgres;Password=123456;");
    }

    public async void RealizarInscricao(Guid idAluno, Guid idTurma)
    {
        var query = @"INSERT INTO Inscricoes 
                    (inscricao_id, ativa, presenca, nota_p1, nota_p2, nota_pf, aluno_id, turma_id)
                    VALUES (@Id, @Ativa, @Presenca, @NotaP1, @NotaP2, @NotaPF, @IdAluno, @IdTurma)";

        await _connection.ExecuteAsync(query,
                                       new { 
                                           Id = Guid.NewGuid(),
                                           Ativa = true,
                                           Presenca = 0,
                                           NotaP1 = 0,
                                           NotaP2 = 0,
                                           NotaPF = 0,
                                           IdAluno = idAluno,
                                           IdTurma = idTurma
                                       });
    }
}