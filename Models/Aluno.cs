using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchollAPI.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool isAtivo { get; set; } = true;


        public IEnumerable<AlunoDisciplina> AlunosDiciplinas { get; set; }

        public Aluno()
        {

        }

        public Aluno(int id, int matricula, string nome, string sobrenome, string telefone,  DateTime dataNascimento)
        {
            Id = id;
            Matricula = matricula;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
        }


    }
}
