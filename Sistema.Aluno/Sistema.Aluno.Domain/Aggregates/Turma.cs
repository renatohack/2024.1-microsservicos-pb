using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Turma
    {
        public Guid Id { get; init; }
        public Professor Professor { get; init; }
        public Disciplina Disciplina { get; init; }
        public List<Inscricao> Inscricoes { get; init; } = new List<Inscricao>();


        public void AdicionarInscricao(Inscricao inscricao)
        {
            this.Inscricoes.Add(inscricao);
        }
    }
}
