using Dapper;
using Npgsql;
using Sistema.Secretaria.Application.Alunos.Response;
using Sistema.Secretaria.Application.Comuns;

namespace Sistema.Secretaria.Repository.Alunos;
public class AlunoRepository
{
    public NpgsqlConnection _connection { get; set; }

    public AlunoRepository()
    {
        _connection = new NpgsqlConnection(@"HOST=localhost:5432;DataBase=projeto_bloco;UserName=postgres;Password=123456;");
    }

    public async Task RealizarInscricao(Guid idAluno, Guid idTurma)
    {
        var query = @"INSERT INTO Inscricoes 
                    (inscricao_id, aluno_id, turma_id)
                    VALUES 
                    (@Id, @IdAluno, @IdTurma);";

        await _connection.ExecuteAsync(query,
                                       new
                                       {
                                           Id = Guid.NewGuid(),
                                           IdAluno = idAluno,
                                           IdTurma = idTurma
                                       });
    }

    public async Task CancelarInscricao(Guid idInscricao)
    {
        var query = @"UPDATE Inscricoes 
                      SET ativa = @Ativa
                      WHERE inscricao_id = @Id;";

        await _connection.ExecuteAsync(query,
                                       new
                                       {
                                           Id = idInscricao,
                                           Ativa = false
                                       });
    }

    public async Task<IEnumerable<ConsultarHistoricoResponse>> ConsultarHistorico(Guid idAluno)
    {
        var query = @"SELECT ativa, 
                             presenca, 
                             nota_p1, 
                             nota_p2, 
                             nota_pf,
                             turma_id
                      FROM Inscricoes 
                      WHERE aluno_id = @IdAluno;";

        return await _connection.QueryAsync<ConsultarHistoricoResponse>(query,
                                       new
                                       {
                                           IdAluno = idAluno
                                       });
    }

    public async Task<int> ConsultarPresenca(Guid idAluno, Guid idInscricao)
    {
        var query = @"SELECT presenca
                      FROM Inscricoes 
                      WHERE inscricao_id = @IdInscricao
                      AND aluno_id = @IdAluno";

        return await _connection.QueryFirstOrDefaultAsync<int>(query,
                                       new
                                       {
                                           IdInscricao = idInscricao,
                                           IdAluno = idAluno
                                       });
    }

    public async Task<IEnumerable<ConsultarNotasResponse>> ConsultarNotas(Guid idAluno, Guid idInscricao)
    {
        var query = @"SELECT nota_p1, 
                             nota_p2, 
                             nota_pf
                      FROM Inscricoes 
                      WHERE inscricao_id = @IdInscricao
                      AND aluno_id = @IdAluno";

        return await _connection.QueryAsync<ConsultarNotasResponse>(query,
                                       new
                                       {
                                           IdInscricao = idInscricao,
                                           IdAluno = idAluno
                                       });
    }

    public async Task<Guid> ConsultarInscricao(Guid idAluno, Guid idTurma)
    {
        var query = @"SELECT inscricao_id
                      FROM Inscricoes 
                      WHERE turma_id = @IdTurma
                      AND aluno_id = @IdAluno";

        return await _connection.QueryFirstOrDefaultAsync<Guid>(query,
                                       new
                                       {
                                           IdTurma = idTurma,
                                           IdAluno = idAluno
                                       });
    }

    public async Task<Guid> ConsultaTurma(Guid idTurma)
    {
        var query = @"SELECT turma_id
                      FROM Turmas 
                      WHERE turma_id = @IdTurma";

        return await _connection.QueryFirstOrDefaultAsync<Guid>(query,
                                       new
                                       {
                                           IdTurma = idTurma
                                       });
    }
}