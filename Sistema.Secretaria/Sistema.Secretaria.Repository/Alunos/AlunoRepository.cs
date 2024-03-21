﻿using Dapper;
using Npgsql;
using Sistema.Secretaria.Application.Alunos.Response;
using Sistema.Secretaria.Domain.Aggregates;

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
                    (inscricao_id, ativa, presenca, nota_p1, nota_p2, nota_pf, aluno_id, turma_id)
                    VALUES 
                    (@Id, @Ativa, @Presenca, @NotaP1, @NotaP2, @NotaPF, @IdAluno, @IdTurma);";

        await _connection.ExecuteAsync(query,
                                       new
                                       {
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

    public async Task<IEnumerable<Inscricao>> ConsultarHistorico(Guid idAluno)
    {
        var query = @"SELECT *
                      FROM Inscricoes 
                      WHERE aluno_id = @IdAluno;";

        return await _connection.QueryAsync<Inscricao>(query,
                                       new
                                       {
                                           IdAluno = idAluno
                                       });
    }

    public async Task<int> ConsultarFrequencia(Guid idAluno, Guid idInscricao)
    {
        var query = @"SELECT presenca
                      FROM Inscricoes 
                      WHERE inscricao_id = @IdInscricao
                      AND aluno_id = @IdAluno";

        return await _connection.QueryFirstAsync<int>(query,
                                       new
                                       {
                                           IdInscricao = idInscricao,
                                           IdAluno = idAluno
                                       });
    }

    public async Task<IEnumerable<ConsultarNotasResponse>> ConsultarNotas(Guid idAluno, Guid idInscricao)
    {
        var query = @"SELECT presenca
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
}