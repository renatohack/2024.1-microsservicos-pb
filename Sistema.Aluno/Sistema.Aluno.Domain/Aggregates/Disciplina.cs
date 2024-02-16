using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Disciplina
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Turma> Turmas { get; set; }

    }
}
