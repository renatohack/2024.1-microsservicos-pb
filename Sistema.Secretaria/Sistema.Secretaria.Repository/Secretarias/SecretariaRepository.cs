using Dapper;
using Npgsql;
using Sistema.Secretaria.Domain.Aggregates;

namespace Sistema.Secretaria.Repository.Secretarias;
public class SecretariaRepository
{
    public NpgsqlConnection _connection { get; set; }

    public SecretariaRepository()
    {
        _connection = new NpgsqlConnection(@"HOST=localhost:5432;DataBase=projeto_bloco;UserName=postgres;Password=123456;");
    }

    public async void CriarAluno(string nome)
    {
        var query = @"INSERT INTO Alunos
                      (aluno_id, nome)
                      VALUES (@Id, @Nome)";

        await _connection.ExecuteAsync(query, new { Id = Guid.NewGuid(), Nome = nome });
    }

    public async Task<Aluno> ObterAluno(Guid id)
    {
        var query = @"SELECT * FROM Alunos
                      WHERE aluno_id = @IdAluno";

        var aluno = await _connection.QueryFirstAsync<Aluno>(query, new { IdAluno = id });

        return aluno;
    }
}