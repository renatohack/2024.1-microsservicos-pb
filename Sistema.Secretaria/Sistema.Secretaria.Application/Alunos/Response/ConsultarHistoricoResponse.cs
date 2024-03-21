namespace Sistema.Secretaria.Application.Alunos.Response;

public class ConsultarHistoricoResponse
{
    public bool Ativa { get; set; }
    public int Presenca { get; set; }
    public float NotaP1 { get; set; }
    public float NotaP2 { get; set; }
    public float NotaPF { get; set; }
    public Guid turma_id { get; set; }
}