using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Inscricao
    {
        public Guid Id { get; set; }
        public bool Ativa { get; set; }
        public Turma Turma { get; set; }
        public Aluno Aluno { get; set; }
        public float Frequencia { get; set; }
        public float NotaP1 { get; set; }
        public float NotaP2 { get; set; }
        public float NotaPF { get; set; }

    }
}
