using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Turma
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Professor Professor { get; set; }
        public Disciplina Disciplina { get; set; }
        public List<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();


        public void AdicionarInscricao(Inscricao inscricao)
        {
            this.Inscricoes.Add(inscricao);
        }
    }
}
