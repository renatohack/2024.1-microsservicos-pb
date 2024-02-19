using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Turma
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Professor Professor { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();

    }
}
