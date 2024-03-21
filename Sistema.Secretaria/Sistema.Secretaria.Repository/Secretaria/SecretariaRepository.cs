using Dapper;
using Microsoft.Data.SqlClient;

namespace Sistema.Secretaria.Repository.Secretaria;
public class SecretariaRepository
{
    public SqlConnection _connection { get; set; }

    public SecretariaRepository()
    {
        //Aqui irá a connectionString do banco no docker para podermos acessar
        _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=escolaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public async void CriarAluno(string nome)
    {
        var query = @"INSERT INTO Alunos
                      VALUES (@Nome)";

        await _connection.ExecuteAsync(query, new {Nome = nome});
    }
}