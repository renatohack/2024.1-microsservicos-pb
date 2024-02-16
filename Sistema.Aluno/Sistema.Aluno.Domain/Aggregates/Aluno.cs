using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Aluno
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public List<Inscricao> Inscricoes { get; set; }

    }
}
