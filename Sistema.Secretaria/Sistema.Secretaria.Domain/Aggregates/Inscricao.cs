namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Inscricao
    {
        public Guid inscricao_id { get; set; }
        public bool Ativa { get; set; }
        public Guid aluno_id { get; set; }
        public Guid turma_id { get; set; }
        public int Presenca { get; set; } 
        public float NotaP1 { get; set; }
        public float NotaP2 { get; set; }
        public float NotaPF { get; set; }
    }
}
