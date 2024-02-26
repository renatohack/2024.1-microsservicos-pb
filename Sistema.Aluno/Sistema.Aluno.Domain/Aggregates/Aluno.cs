using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Aluno.Domain.Aggregates
{
    public class Aluno
    {

        // properties
        public Guid Id { get; init; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public List<Inscricao> Inscricoes { get; init; } = new List<Inscricao>();
               

        // public methods
        public void RealizarInscricao(Turma turma)
        {
            Inscricao inscricao = new Inscricao()
            {
                Aluno = this,
                Turma = turma,
            };

            this.Inscricoes.Add(inscricao);
            turma.AdicionarInscricao(inscricao);
        }

        public void CancelarInscricao(Guid idInscricao)
        {
            this.Inscricoes.FirstOrDefault(inscricao => inscricao.Id == idInscricao).CancelarInscricao();
        }

        public List<float> ConsultarNotasDeDisciplina(Guid idInscricao)
        {
            return this.Inscricoes.FirstOrDefault(inscricao => inscricao.Id == idInscricao).ObterNotas();
        }

        public float ConsultarFrequenciaEmDisciplina(Guid idInscricao)
        {
            return this.Inscricoes.FirstOrDefault(inscricao => inscricao.Id == idInscricao).ObterFrequencia();
        }

        public List<Inscricao> ConsultarHistorico()
        {
            return this.Inscricoes;
        }

    }
}
