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


        [Fact]
        public void DeveRealizarInscricaoComSucesso()
        {
            domain.Aluno aluno = new domain.Aluno()
            {
                Nome = "Jorge",
                Matricula = "1"
            };

            domain.Professor professor = new domain.Professor()
            {
                Matricula = "1",
            };

            domain.Disciplina disciplina = new domain.Disciplina()
            {
                Nome = "Fisica",
            };

            domain.Turma turma = new domain.Turma()
            {
                Disciplina = disciplina,
                Professor = professor,
            };


            Assert.False(aluno.Inscricoes.Any());
            Assert.False(turma.Inscricoes.Any());

            domain.Inscricao inscricao = aluno.RealizarInscricao(turma);

            Assert.True(aluno.Inscricoes.Any());
            Assert.True(turma.Inscricoes.Any());
            Assert.True(inscricao.Ativa);

        }


        [Fact]
        public void DeveCancelarInscricaoComSucesso()
        {
            domain.Aluno aluno = new domain.Aluno()
            {
                Nome = "Jorge",
                Matricula = "1"
            };

            domain.Professor professor = new domain.Professor()
            {
                Matricula = "1",
            };

            domain.Disciplina disciplina = new domain.Disciplina()
            {
                Nome = "Fisica",
            };

            domain.Turma turma = new domain.Turma()
            {
                Disciplina = disciplina,
                Professor = professor,
            };


            Assert.False(aluno.Inscricoes.Any());
            Assert.False(turma.Inscricoes.Any());

            domain.Inscricao inscricao = aluno.RealizarInscricao(turma);

            Assert.True(aluno.Inscricoes.Any());
            Assert.True(turma.Inscricoes.Any());
            Assert.True(inscricao.Ativa == true);


            aluno.CancelarInscricao(inscricao.Id);

            Assert.True(inscricao.Ativa == false);

        }


    }
}