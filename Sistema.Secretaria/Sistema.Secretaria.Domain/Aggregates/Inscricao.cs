﻿namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Inscricao
    {
        public Guid inscricao_id { get; set; } = Guid.NewGuid();
        public bool Ativa { get; set; } = true;
        public Guid turma_id { get; set; }
        public Turma Turma { get; set; }
        public Guid aluno_id { get; set; }
        public Aluno Aluno { get; set; }
        public int Presenca { get; set; } = 0;
        public float NotaP1 { get; set; } = 0;
        public float NotaP2 { get; set; } = 0;
        public float NotaPF { get; set; } = 0;



        // public methods
        public void CancelarInscricao()
        {
            this.Ativa = false;
        }

        public List<float> ObterNotas()
        {
            return new List<float>() { this.NotaP1, this.NotaP2, this.NotaPF };
        }

        //public float ObterFrequencia()
        //{
        //    return (float) this.Presenca / this.Turma.NumeroAulas;
        //}



    }
}
