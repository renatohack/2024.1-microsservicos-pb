namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Turma
    {
        public Guid Id { get; set; }
        public Professor Professor { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Inscricao> Inscricoes { get; set; }
    }
}
