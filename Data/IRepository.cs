using api.net.Models;

namespace AlunosApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();


        Aluno[] GetAllAlunos(bool includeProfessor);
        Aluno[] GetAllAlunosByDisciplinaId(int disiplinaId, bool includeProfessor = false);
        Aluno GetAlunoId(int alunoId, bool includeProfessor = false);

        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int diciplianaId, bool includeProfessor = false);
        Professor GetProfessorId(int alunoId, bool includeProfessor = false);

    }
}
