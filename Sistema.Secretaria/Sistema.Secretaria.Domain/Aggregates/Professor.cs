using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Professor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Matricula { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}
