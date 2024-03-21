using Dapper;
using Npgsql;
using Sistema.Secretaria.Application.Comuns;
using Sistema.Secretaria.Application.Professores.Requests;

namespace Sistema.Secretaria.Repository.Professores;
public class ProfessorRepository
{
    public NpgsqlConnection _connection { get; set; }

    public ProfessorRepository()
    {
        _connection = new NpgsqlConnection(@"HOST=localhost:5432;DataBase=projeto_bloco;UserName=postgres;Password=123456;");
    }

    public async Task<IEnumerable<ConsultarNotasResponse>> ConsultarNotas(Guid idTurma, Guid idAluno)
    {
        var query = @"SELECT nota_p1, 
                             nota_p2, 
                             nota_pf
                      FROM Inscricoes 
                      WHERE turma_id = @IdTurma
                      AND aluno_id = @IdAluno";

        return await _connection.QueryAsync<ConsultarNotasResponse>(query,
                                                                    new
                                                                    {
                                                                        IdTurma = idTurma,
                                                                        IdAluno = idAluno
                                                                    });
    }

    public async Task InserirNotas(Guid idTurma, Guid idAluno, InserirNotasRequest request)
    {
        var query = @"UPDATE Inscricoes 
                      SET nota_p1 = @NotaP1, 
                          nota_p2 = @NotaP2, 
                          nota_pf = @NotaPF
                      WHERE turma_id = @IdTurma
                      AND aluno_id = @IdAluno";

        await _connection.ExecuteAsync(query,
                                        new
                                        {
                                            IdTurma = idTurma,
                                            IdAluno = idAluno,
                                            NotaP1 = request.nota_p1,
                                            NotaP2 = request.nota_p2,
                                            NotaPF = request.nota_pf
                                        });
    }

    public async Task DeletarNotas(Guid idTurma, Guid idAluno)
    {
        var query = @"UPDATE Inscricoes 
                      SET nota_p1 = 0, 
                          nota_p2 = 0, 
                          nota_pf = 0
                      WHERE turma_id = @IdTurma
                      AND aluno_id = @IdAluno";

        await _connection.ExecuteAsync(query,
                                        new
                                        {
                                            IdTurma = idTurma,
                                            IdAluno = idAluno
                                        });
    }

    public async Task<int> ConsultarPresenca(Guid idTurma, Guid idAluno)
    {
        var query = @"SELECT presenca
                      FROM Inscricoes 
                      WHERE turma_id = @IdTurma
                      AND aluno_id = @IdAluno";

        return await _connection.QueryFirstAsync<int>(query,
                                       new
                                       {
                                           IdTurma = idTurma,
                                           IdAluno = idAluno
                                       });
    }

    public async Task InserirPresenca(Guid idTurma, Guid idAluno, InserirPresencaRequest request)
    {
        var query = @"UPDATE Inscricoes 
                      SET presenca = @Presenca
                      WHERE turma_id = @IdTurma
                      AND aluno_id = @IdAluno";

        await _connection.ExecuteAsync(query,
                                        new
                                        {
                                            request.Presenca,
                                            IdTurma = idTurma,
                                            IdAluno = idAluno
                                        });
    }

    public async Task AlterarPresenca(Guid idTurma, Guid idAluno, AlterarPresencaRequest request)
    {
        var query = @"UPDATE Inscricoes 
                      SET presenca = @Presenca
                      WHERE turma_id = @IdTurma
                      AND aluno_id = @IdAluno";

        await _connection.ExecuteAsync(query,
                                        new
                                        {
                                            request.Presenca,
                                            IdTurma = idTurma,
                                            IdAluno = idAluno
                                        });
    }
}