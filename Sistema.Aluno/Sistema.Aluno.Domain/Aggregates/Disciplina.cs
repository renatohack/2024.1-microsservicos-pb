using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Disciplina
    {
        public Guid Id { get; init; }
        public string Nome { get; init; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public int NumeroAulas { get; init; } = 1;

    }
}
