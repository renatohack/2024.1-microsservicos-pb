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

            aluno.RealizarInscricao(turma);
            Inscricao inscricao = aluno.Inscricoes[0];
            inscricao.NotaP1 = 1;
            inscricao.NotaP2 = 2;
            inscricao.NotaPF = 3;

            List<float> listaNotas = aluno.ConsultarNotasDeDisciplina(inscricao.Id);

            Assert.True(listaNotas[0] == 1);
            Assert.True(listaNotas[1] == 2);
            Assert.True(listaNotas[2] == 3);
        }


        [Fact]
        public void DeveConsultarFrequenciaComSucesso()
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
                NumeroAulas = 10,
            };

            domain.Turma turma = new domain.Turma()
            {
                Disciplina = disciplina,
                Professor = professor,
            };

            aluno.RealizarInscricao(turma);
            Inscricao inscricao = aluno.Inscricoes[0];
            inscricao.Presenca = 2;

            float frequencia = aluno.ConsultarFrequenciaEmDisciplina(inscricao.Id);

            Assert.True(frequencia == 0.2f);
        }
        
        
        [Fact]
        public void DeveConsultarHistoricoComSucesso()
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


            aluno.RealizarInscricao(turma);

            Assert.True(aluno.Inscricoes.Count() == 1);
            Assert.True(aluno.Inscricoes[0].Turma.Disciplina.Nome == "Fisica");

        }
    }
}