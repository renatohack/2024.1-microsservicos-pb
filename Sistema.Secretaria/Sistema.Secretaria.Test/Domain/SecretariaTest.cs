//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using domain = Sistema.Secretaria.Domain.Aggregates;

//namespace Sistema.Secretaria.Test.Domain
//{
//    public class SecretariaTest
//    {

//        [Fact]
//        public void DeveCriarAlunoComSucesso()
//        {
//            domain.Aluno aluno = new domain.Aluno()
//            {
//                Nome = "Jorge",
//                Matricula = "1"
//            };


//            Assert.NotNull(aluno);
//            Assert.True(aluno.Id != Guid.Empty);
//            Assert.False(String.IsNullOrEmpty(aluno.Nome));
//            Assert.False(String.IsNullOrEmpty(aluno.Matricula));
//            Assert.NotNull(aluno.Inscricoes);
//            Assert.False(aluno.Inscricoes.Any());

//        }


//        [Fact]
//        public void DeveRealizarInscricaoComSucesso()
//        {
//            domain.Aluno aluno = new domain.Aluno()
//            {
//                Nome = "Jorge",
//                Matricula = "1"
//            };

//            domain.Professor professor = new domain.Professor()
//            {
//                Matricula = "1",
//            };

//            domain.Disciplina disciplina = new domain.Disciplina()
//            {
//                Nome = "Fisica",
//            };

//            domain.Turma turma = new domain.Turma()
//            {
//                Disciplina = disciplina,
//                Professor = professor,
//            };


//            Assert.False(aluno.Inscricoes.Any());
//            Assert.False(turma.Inscricoes.Any());

//            domain.Inscricao inscricao = aluno.RealizarInscricao(turma);

//            Assert.True(aluno.Inscricoes.Any());
//            Assert.True(turma.Inscricoes.Any());
//            Assert.True(inscricao.Ativa);

//        }


//        [Fact]
//        public void DeveConsultarHistoricoComSucesso()
//        {
//            domain.Aluno aluno = new domain.Aluno()
//            {
//                Nome = "Jorge",
//                Matricula = "1"
//            };

//            domain.Professor professor = new domain.Professor()
//            {
//                Matricula = "1",
//            };

//            domain.Disciplina disciplina = new domain.Disciplina()
//            {
//                Nome = "Fisica",
//            };

//            domain.Turma turma = new domain.Turma()
//            {
//                Disciplina = disciplina,
//                Professor = professor,
//            };


//            domain.Inscricao inscricao = aluno.RealizarInscricao(turma);

//            Assert.True(aluno.Inscricoes.Count() == 1);
//            Assert.True(aluno.Inscricoes[0].Turma.Disciplina.Nome == "Fisica");

//        }


//        [Fact]
//        public void DeveCancelarInscricaoComSucesso()
//        {
//            domain.Aluno aluno = new domain.Aluno()
//            {
//                Nome = "Jorge",
//                Matricula = "1"
//            };

//            domain.Professor professor = new domain.Professor()
//            {
//                Matricula = "1",
//            };

//            domain.Disciplina disciplina = new domain.Disciplina()
//            {
//                Nome = "Fisica",
//            };

//            domain.Turma turma = new domain.Turma()
//            {
//                Disciplina = disciplina,
//                Professor = professor,
//            };


//            Assert.False(aluno.Inscricoes.Any());
//            Assert.False(turma.Inscricoes.Any());

//            domain.Inscricao inscricao = aluno.RealizarInscricao(turma);

//            Assert.True(aluno.Inscricoes.Any());
//            Assert.True(turma.Inscricoes.Any());
//            Assert.True(inscricao.Ativa == true);


//            aluno.CancelarInscricao(inscricao.Id);

//            Assert.True(inscricao.Ativa == false);

//        }


//        [Fact]
//        public void DeveAlterarNotasComSucesso()
//        {
//            domain.Aluno aluno = new domain.Aluno()
//            {
//                Nome = "Jorge",
//                Matricula = "1"
//            };

//            domain.Professor professor = new domain.Professor()
//            {
//                Matricula = "1",
//            };

//            domain.Disciplina disciplina = new domain.Disciplina()
//            {
//                Nome = "Fisica",
//            };

//            domain.Turma turma = new domain.Turma()
//            {
//                Disciplina = disciplina,
//                Professor = professor,
//            };

//            domain.Inscricao inscricao = aluno.RealizarInscricao(turma);

//            Assert.True(inscricao.NotaP1 == 0);
//            Assert.True(inscricao.NotaP2 == 0);
//            Assert.True(inscricao.NotaPF == 0);

//            aluno.AlterarNotasDeDisciplina(inscricao.Id, 1, 2, 3);

//            Assert.True(inscricao.NotaP1 == 1);
//            Assert.True(inscricao.NotaP2 == 2);
//            Assert.True(inscricao.NotaPF == 3);
//        }


//        [Fact]
//        public void DeveConsultarNotasComSucesso()
//        {
//            domain.Aluno aluno = new domain.Aluno()
//            {
//                Nome = "Jorge",
//                Matricula = "1"
//            };

//            domain.Professor professor = new domain.Professor()
//            {
//                Matricula = "1",
//            };

//            domain.Disciplina disciplina = new domain.Disciplina()
//            {
//                Nome = "Fisica",
//            };

//            domain.Turma turma = new domain.Turma()
//            {
//                Disciplina = disciplina,
//                Professor = professor,
//            };

//            domain.Inscricao inscricao = aluno.RealizarInscricao(turma);

//            aluno.AlterarNotasDeDisciplina(inscricao.Id, 1, 2, 3);

//            List<float> listaNotas = aluno.ConsultarNotasDeDisciplina(inscricao.Id);

//            Assert.True(listaNotas[0] == 1);
//            Assert.True(listaNotas[1] == 2);
//            Assert.True(listaNotas[2] == 3);
//        }


//        [Fact]
//        public void DeveAlterarFrequenciaComSucesso()
//        {
//            domain.Aluno aluno = new domain.Aluno()
//            {
//                Nome = "Jorge",
//                Matricula = "1"
//            };

//            domain.Professor professor = new domain.Professor()
//            {
//                Matricula = "1",
//            };

//            domain.Disciplina disciplina = new domain.Disciplina()
//            {
//                Nome = "Fisica",
//            };

//            domain.Turma turma = new domain.Turma()
//            {
//                Disciplina = disciplina,
//                Professor = professor,
//                //NumeroAulas = 10,
//            };

//            domain.Inscricao inscricao = aluno.RealizarInscricao(turma);

//            //Assert.True(inscricao.ObterFrequencia() == 0 && inscricao.Presenca == 0);

//            aluno.AlterarPresencaEmDisciplina(inscricao.Id, 2);

//            //Assert.True(inscricao.ObterFrequencia() == 0.2f);
//            Assert.True(inscricao.Presenca == 2);
//        }


//        [Fact]
//        public void DeveConsultarFrequenciaComSucesso()
//        {
//            domain.Aluno aluno = new domain.Aluno()
//            {
//                Nome = "Jorge",
//                Matricula = "1"
//            };

//            domain.Professor professor = new domain.Professor()
//            {
//                Matricula = "1",
//            };

//            domain.Disciplina disciplina = new domain.Disciplina()
//            {
//                Nome = "Fisica",
//            };

//            domain.Turma turma = new domain.Turma()
//            {
//                Disciplina = disciplina,
//                Professor = professor,
//                //NumeroAulas = 10,
//            };

//            domain.Inscricao inscricao = aluno.RealizarInscricao(turma);

//            aluno.AlterarPresencaEmDisciplina(inscricao.Id, 2);
//            //float frequencia = aluno.ConsultarFrequenciaEmDisciplina(inscricao.Id);

//            //Assert.True(frequencia == 0.2f);
//        }
//    }
//}