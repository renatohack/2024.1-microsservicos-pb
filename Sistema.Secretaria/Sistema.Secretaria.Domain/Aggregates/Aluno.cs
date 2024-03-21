namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Aluno
    {
        // properties
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public List<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();



        //// public methods
        //public static Aluno CriarAluno(string nome, string matricula)
        //{
        //    Aluno aluno = new Aluno()
        //    {
        //        Nome = nome,
        //        Matricula = matricula
        //    };

        //    return aluno;
        //}

        //public Inscricao RealizarInscricao(Turma turma)
        //{
        //    Inscricao inscricao = new Inscricao()
        //    {
        //        Turma = turma,
        //        Aluno = this,
        //    };

        //    this.Inscricoes.Add(inscricao);
        //    turma.Inscricoes.Add(inscricao);

        //    return inscricao;
        //}

        //public void CancelarInscricao(Guid idInscricao)
        //{
        //    this.Inscricoes.FirstOrDefault(inscricao => inscricao.Id == idInscricao).CancelarInscricao();
        //}

        //public List<float> ConsultarNotasDeDisciplina(Guid idInscricao)
        //{
        //    return this.Inscricoes.FirstOrDefault(inscricao => inscricao.Id == idInscricao).ObterNotas();
        //}

        ////public float ConsultarFrequenciaEmDisciplina(Guid idInscricao)
        ////{
        ////    return this.Inscricoes.FirstOrDefault(inscricao => inscricao.Id == idInscricao).ObterFrequencia();
        ////}

        //public List<Inscricao> ConsultarHistorico()
        //{
        //    return this.Inscricoes;
        //}

        //public void AlterarNotasDeDisciplina(Guid idInscricao, float notap1, float notap2, float notapf)
        //{
        //    Inscricao inscricao = this.Inscricoes.FirstOrDefault(inscricao => inscricao.Id == idInscricao);

        //    inscricao.NotaP1 = notap1;
        //    inscricao.NotaP2 = notap2;
        //    inscricao.NotaPF = notapf;
        //}

        //public void AlterarPresencaEmDisciplina(Guid idInscricao, int presenca)
        //{
        //    Inscricao inscricao = this.Inscricoes.FirstOrDefault(inscricao => inscricao.Id == idInscricao);

        //    inscricao.Presenca = presenca;
        //}

    }
}
