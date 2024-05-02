using api.net.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AlunosApi.Data
{
    public class Repository : IRepository
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }


        public Aluno[] GetAllAlunos(bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.alunoDiciplinas) //ele faz um select com join igual ao banco de dados
                                     .ThenInclude(ad => ad.diciplina) //then significa entao
                                     .ThenInclude(d => d.professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disiplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.alunoDiciplinas)
                                     .ThenInclude(ad => ad.diciplina)
                                     .ThenInclude(d => d.professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                                        .Where(aluno => aluno.alunoDiciplinas.Any(ad => ad.DisiplinaId == disiplinaId));
            return query.ToArray();
        }

        public Aluno GetAlunoId(int alunoId, bool includeProfessor = false) //trazendo com falso ele não é obrigatorio passar ele 
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.alunoDiciplinas)
                                     .ThenInclude(ad => ad.diciplina)
                                     .ThenInclude(d => d.professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                                        .Where(aluno => aluno.Id == alunoId);
            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.diciplinas) //ele faz um select com join igual ao banco de dados
                                     .ThenInclude(d => d.alunoDiciplinas) //then significa entao
                                     .ThenInclude(ad => ad.aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int diciplianaId, bool includeProfessor = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeProfessor)
            {
                query = query.Include(p => p.diciplinas) //ele faz um select com join igual ao banco de dados
                                     .ThenInclude(d => d.alunoDiciplinas) //then significa entao
                                     .ThenInclude(ad => ad.aluno);
            }

            query = query.AsNoTracking().OrderBy(aluno => aluno.Id)
                                        .Where(aluno => aluno.diciplinas.Any(
                                            d => d.alunoDiciplinas.Any(ad => ad.DisiplinaId == diciplianaId)
                                        ));
            return query.ToArray();
        }

        public Professor GetProfessorId(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeProfessor)
            {
                query = query.Include(prof => prof.diciplinas)
                                     .ThenInclude(p => p.alunoDiciplinas)
                                     .ThenInclude(ad => ad.aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                                        .Where(professor => professor.Id == alunoId);
            return query.FirstOrDefault();
        }

    }
}
