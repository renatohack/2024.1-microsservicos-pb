﻿namespace Sistema.Secretaria.Domain.Aggregates
{
    public class Disciplina
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public int NumeroAulas { get; set; } = 1;

    }
}
