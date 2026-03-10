using AlunoApi.Domain.Entities;

namespace AlunoApi.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<Aluno> Matricular(Aluno aluno);

        Task<List<Aluno>> Listar();

        Task<Aluno?> BuscarPorEmail(string email);
        Task<List<Aluno>> BuscarPorNome(string nome);

    }
}