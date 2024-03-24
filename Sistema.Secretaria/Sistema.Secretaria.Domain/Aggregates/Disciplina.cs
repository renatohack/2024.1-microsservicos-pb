namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Disciplina
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Turma> Turmas { get; set; }
        public int NumeroAulas { get; set; } 
    }
}
