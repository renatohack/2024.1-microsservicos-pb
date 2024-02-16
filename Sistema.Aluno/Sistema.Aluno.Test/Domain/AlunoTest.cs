using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain = Sistema.Aluno.Domain.Aggregates;

namespace Sistema.Aluno.Test.Domain
{
    public class AlunoTest
    {

        [Fact]
        public void DeveCriarAlunoComSucesso()
        {
            domain.Aluno aluno = new domain.Aluno()
            {
                Nome = "Jorge",
                Matricula = "1"
            };


            Assert.NotNull(aluno);
            Assert.True(aluno.Id != Guid.Empty);
            Assert.False(String.IsNullOrEmpty(aluno.Nome));
            Assert.False(String.IsNullOrEmpty(aluno.Matricula));
            Assert.NotNull(aluno.Inscricoes);
            Assert.False(aluno.Inscricoes.Any());

        }

    }
}
