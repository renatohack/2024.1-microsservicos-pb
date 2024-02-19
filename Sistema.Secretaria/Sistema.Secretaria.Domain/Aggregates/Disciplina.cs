using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Disciplina
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public int NumeroAulas { get; set; } = 1;

    }
}
