using SmartSchollAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchollAPI.Repository.Contracts
{
     public interface IBaseRepository 
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();


        //Alunos
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int id, bool includeProfessor = false);
        Aluno GetAlunoById(int id, bool includeProfessor = false);

        //Professores
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int id, bool includeAlunos = false);
        Professor GetProfessorById(int id, bool includeAlunos = false);
    }
}
