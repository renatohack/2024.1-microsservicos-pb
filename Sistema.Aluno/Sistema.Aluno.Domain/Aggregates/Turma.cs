using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Turma
    {
        public Guid Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int Sala { get; set; }
        public Professor Professor { get; set; }
        public List<Inscricao> Inscricoes { get; set; }
        public int NumeroAulas { get; set; }

    }
}
