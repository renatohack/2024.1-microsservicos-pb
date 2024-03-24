using Dapper;
using Npgsql;
using Sistema.Secretaria.Application.Secretaria.Response;

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

    public async Task<ObterAlunoResponse> ObterAluno(Guid id)
    {
        var queries = @"SELECT i.inscricao_id FROM Inscricoes i
                      WHERE i.aluno_id = @IdAluno;
                      
                      SELECT aluno_id, nome, matricula FROM Alunos
                      WHERE aluno_id = @IdAluno;";

        using (var multi = await _connection.QueryMultipleAsync(queries, new { IdAluno = id }))
        {
            var inscrioes = await multi.ReadAsync<Guid>();

            var aluno = await multi.ReadFirstAsync<ObterAlunoResponse>();

            aluno.Inscricoes = inscrioes;

            return aluno;
        };
    }
}