using Dapper;
using Npgsql;
using Sistema.Secretaria.Domain.Aggregates;
using Sistema.Secretaria.Repository.Secretarias;

namespace Sistema.Secretaria.Test.Repository.Secretaria;
public class SecretariaRepositoryTests
{
    public SecretariaRepository Repository { get; set; }

    public NpgsqlConnection Connection { get; set; }

    public SecretariaRepositoryTests()
    {
        Repository = new SecretariaRepository();
        Connection = new NpgsqlConnection(@"HOST=localhost:5432;DataBase=projeto_bloco;UserName=postgres;Password=123456;");
    }

    [Fact]
    public async Task DeveCriarAlunoComSucesso()
    {
        // Arrange
        var nome = "Aluno teste";

        // Act
        await Repository.CriarAluno(nome);

        // Assert
        var aluno = await BuscarAluno(nome);

        Assert.NotNull(aluno);
        Assert.Equal(nome, aluno.Nome);

        await DeletarAluno(aluno.Aluno_id);
    }

    [Fact]
    public async Task DeveObterAlunoComSucesso()
    {
        // Arrange
        var nome = "Aluno teste";
        await Repository.CriarAluno(nome);
        var aluno = await BuscarAluno(nome);

        // Act
        var result = await Repository.ObterAluno(aluno.Aluno_id);

        // Assert

        Assert.NotNull(result);
        Assert.Equal(result.Nome, aluno.Nome);
        Assert.Equal(result.aluno_id, aluno.Aluno_id);
        Assert.Equal(result.Matricula, aluno.Matricula);
        Assert.Empty(result.Inscricoes);

        await DeletarAluno(aluno.Aluno_id);
    }


    private async Task<Aluno> BuscarAluno(string nome)
    {
        var query = "SELECT * FROM Alunos WHERE nome = @Nome";

        return await Connection.QueryFirstAsync<Aluno>(query, new { Nome = nome });
    }

    private async Task DeletarAluno(Guid id)
    {
        var query = "DELETE FROM Alunos WHERE aluno_id = @Id";

        await Connection.ExecuteAsync(query, new { Id = id });
    }
}