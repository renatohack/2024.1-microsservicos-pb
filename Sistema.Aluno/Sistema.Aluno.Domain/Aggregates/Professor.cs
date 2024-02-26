using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Professor
    {
        public Guid Id { get; init; }
        public string Matricula { get; init; }
        public List<Turma> Turmas { get; init; }
    }
}
