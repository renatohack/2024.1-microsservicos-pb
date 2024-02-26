using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain = Sistema.Aluno.Domain.Aggregates;

namespace Sistema.Aluno.Repository
{
    public class AlunoRepository
    {
        private static List<domain.Aluno> _Alunos = new List<domain.Aluno>();

        public void SalvarAlunoNaBase(domain.Aluno Aluno)
        {

            domain.Aluno AlunoBanco = this.ObterAlunoPorId(Aluno.Id);

            if (AlunoBanco == null)
            {
                AlunoRepository._Alunos.Add(Aluno);
            }
            else
            {
                int indexToUpdate = AlunoRepository._Alunos.FindIndex(a => a.Id.Equals(Aluno.Id));
                AlunoRepository._Alunos[indexToUpdate] = Aluno;
            }

        }


        public domain.Aluno ObterAlunoPorId(Guid idAluno) => AlunoRepository._Alunos.FirstOrDefault(Aluno => Aluno.Id == idAluno);
    }
}
