namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Professor
    {
        public Guid Id { get; set; }
        public string Matricula { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}
