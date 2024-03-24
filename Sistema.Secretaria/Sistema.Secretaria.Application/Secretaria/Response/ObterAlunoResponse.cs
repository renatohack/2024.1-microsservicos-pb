namespace Sistema.Secretaria.Application.Secretaria.Response;
public class ObterAlunoResponse
{
    public IEnumerable<Guid> Inscricoes { get; set; }
    public Guid aluno_id { get; set; }
    public string Nome { get; set; }
    public int Matricula { get; set; }
}