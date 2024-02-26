using Sistema.Aluno.Domain.Aggregates;
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
        public void DeveRealizarInscricaoComSucesso()
        {
            domain.Aluno aluno = new domain.Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Jorge",
                Matricula = "1"
            };

            domain.Professor professor = new domain.Professor()
            {
                Id = Guid.NewGuid(),
                Matricula = "1",
            };

            domain.Disciplina disciplina = new domain.Disciplina()
            {
                Id = Guid.NewGuid(),
                Nome = "Fisica",
            };

            domain.Turma turma = new domain.Turma()
            {
                Id = Guid.NewGuid(),
                Disciplina = disciplina,
                Professor = professor,
            };


            Assert.False(aluno.Inscricoes.Any());
            Assert.False(turma.Inscricoes.Any());

            aluno.RealizarInscricao(turma);

            Assert.True(aluno.Inscricoes.Any());
            Assert.True(turma.Inscricoes.Any());
            Assert.True(aluno.Inscricoes[0].Ativa);

        }


        [Fact]
        public void DeveCancelarInscricaoComSucesso()
        {
            domain.Aluno aluno = new domain.Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Jorge",
                Matricula = "1"
            };

            domain.Professor professor = new domain.Professor()
            {
                Id = Guid.NewGuid(),
                Matricula = "1",
            };

            domain.Disciplina disciplina = new domain.Disciplina()
            {
                Id = Guid.NewGuid(),
                Nome = "Fisica",
            };

            domain.Turma turma = new domain.Turma()
            {
                Id = Guid.NewGuid(),
                Disciplina = disciplina,
                Professor = professor,
            };

            aluno.RealizarInscricao(turma);
            Inscricao inscricao = aluno.Inscricoes[0];

            aluno.CancelarInscricao(inscricao.Id);

            Assert.True(inscricao.Ativa == false);

        }

        
        [Fact]
        public void DeveConsultarNotasComSucesso()
        {
            domain.Aluno aluno = new domain.Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Jorge",
                Matricula = "1"
            };

            domain.Professor professor = new domain.Professor()
            {
                Id = Guid.NewGuid(),
                Matricula = "1",
            };

            domain.Disciplina disciplina = new domain.Disciplina()
            {
                Id = Guid.NewGuid(),
                Nome = "Fisica",
            };

            domain.Turma turma = new domain.Turma()
            {
                Id = Guid.NewGuid(),
                Disciplina = disciplina,
                Professor = professor,
            };

            aluno.RealizarInscricao(turma);
            Inscricao inscricao = aluno.Inscricoes[0];

            List<float> listaNotas = aluno.ConsultarNotasDeDisciplina(inscricao.Id);

            Assert.True(listaNotas[0] == 0);
            Assert.True(listaNotas[1] == 0);
            Assert.True(listaNotas[2] == 0);
        }


        [Fact]
        public void DeveConsultarFrequenciaComSucesso()
        {
            domain.Aluno aluno = new domain.Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Jorge",
                Matricula = "1"
            };

            domain.Professor professor = new domain.Professor()
            {
                Id = Guid.NewGuid(),
                Matricula = "1",
            };

            domain.Disciplina disciplina = new domain.Disciplina()
            {
                Id = Guid.NewGuid(),
                Nome = "Fisica",
                NumeroAulas = 10,
            };

            domain.Turma turma = new domain.Turma()
            {
                Id = Guid.NewGuid(),
                Disciplina = disciplina,
                Professor = professor,
            };

            aluno.RealizarInscricao(turma);
            Inscricao inscricao = aluno.Inscricoes[0];

            float frequencia = aluno.ConsultarFrequenciaEmDisciplina(inscricao.Id);

            Assert.True(frequencia == 0.0f);
        }
        
        
        [Fact]
        public void DeveConsultarHistoricoComSucesso()
        {
            domain.Aluno aluno = new domain.Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Jorge",
                Matricula = "1"
            };

            domain.Professor professor = new domain.Professor()
            {
                Id = Guid.NewGuid(),
                Matricula = "1",
            };

            domain.Disciplina disciplina = new domain.Disciplina()
            {
                Id = Guid.NewGuid(),
                Nome = "Fisica",
            };

            domain.Turma turma = new domain.Turma()
            {
                Id = Guid.NewGuid(),
                Disciplina = disciplina,
                Professor = professor,
            };


            aluno.RealizarInscricao(turma);

            Assert.True(aluno.Inscricoes.Count() == 1);
            Assert.True(aluno.Inscricoes[0].Turma.Disciplina.Nome == "Fisica");

        }
    }
}