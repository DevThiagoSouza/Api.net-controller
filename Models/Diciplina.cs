using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.net.Models
{
    public class Diciplina
    {
        public Diciplina() {}

        public Diciplina(int id, string nome, int professorId)
        {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }

        public Professor professor { get; set; } //chave primaria da tabela professores

        public IEnumerable<AlunoDiciplina> alunoDiciplinas { get; set; }
    }
}
