using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.net.Models
{
    public class AlunoDiciplina
    {
        public AlunoDiciplina() { }
        public AlunoDiciplina(int alunoId, int disiplinaId)
        {
            AlunoId = alunoId;
            DisiplinaId = disiplinaId;
        }

        public int AlunoId { get; set; }
        public  Aluno aluno { get; set; }
        public int DisiplinaId { get; set; }
        public Diciplina diciplina { get; set; }
    }
}
