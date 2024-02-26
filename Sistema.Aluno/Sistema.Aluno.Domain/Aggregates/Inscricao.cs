using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Inscricao
    {
        public Guid Id { get; init; }
        public Turma Turma { get; init; }
        public Aluno Aluno { get; init; }
        public bool Ativa { get; set; } = true;
        public int Presenca { get; init; } = 0;
        public float NotaP1 { get; init; } = 0;
        public float NotaP2 { get; init; } = 0;
        public float NotaPF { get; init; } = 0;


        // public methods
        public void CancelarInscricao()
        {
            this.Ativa = false;
        }

        public List<float> ObterNotas()
        {
            return new List<float>() { this.NotaP1, this.NotaP2, this.NotaPF };
        }

        public float ObterFrequencia()
        {
            return (float) this.Presenca / this.Turma.Disciplina.NumeroAulas;
        }



    }
}
