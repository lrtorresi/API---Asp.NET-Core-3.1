using Microsoft.EntityFrameworkCore;
using SmartSchollAPI.Data;
using SmartSchollAPI.Models;
using SmartSchollAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchollAPI.Repository
{
    public class BaseRepository : IBaseRepository
    {
        //Injetando o Context
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }


        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDiciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int id, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDiciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno GetAlunoById(int id, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDiciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(aluno => aluno.Id == id);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(d => d.AlunosDiciplinas)
                             .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int id, bool includeAlunos = false)
        {

            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(d => d.AlunosDiciplinas)
                             .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.Disciplinas.Any(
                             d => d.AlunosDiciplinas.Any(ad => ad.DisciplinaId == id)));

            return query.ToArray();
        }

        public Professor GetProfessorById(int id, bool includeAlunos = false)
        {

            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(d => d.AlunosDiciplinas)
                             .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(professor => professor.Id == id);

            return query.FirstOrDefault();
        }
    }
}
