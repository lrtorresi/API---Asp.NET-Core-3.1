using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchollAPI.Models
{
    public class Disciplina
    {
        public Disciplina()
        {

        }

        public Disciplina(int id, string nome, int professorId, int cursoId)
        {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
            CursoId = cursoId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int? PreRequisitoId { get; set; } = null;
        public Disciplina PreRequisito { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDiciplinas { get; set; }
    }
}
