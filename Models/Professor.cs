using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchollAPI.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string telefone { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool isAtivo { get; set; } = true;

        public IEnumerable<Disciplina> Disciplinas { get; set; }

        public Professor()
        {

        }

        public Professor(int id, int registro, string nome, string sobreNome)
        {
            Id = id;
            Registro = registro;
            Nome = nome;
            Sobrenome = sobreNome;
        }
    }
}
