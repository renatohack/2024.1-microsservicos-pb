using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Professor.Domain.Aggregates
{
    public class Inscricao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Ativa { get; set; } = true;
        public Turma Turma { get; set; }
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

        public float ObterFrequencia()
        {
            return (float) this.Presenca / this.Turma.NumeroAulas;
        }



    }
}
