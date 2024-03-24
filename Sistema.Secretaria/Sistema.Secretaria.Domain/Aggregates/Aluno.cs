namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Aluno
    {
        public Guid Aluno_id { get; set; } 
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public List<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
