using AlunoApi.Domain.Entities;
using AlunoApi.Domain.Interfaces;

namespace AlunoApi.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private static List<Aluno> alunos = new List<Aluno>();

        public Task<Aluno> Matricular(Aluno aluno)
        {
            alunos.Add(aluno);
            return Task.FromResult(aluno);
        }

        public Task<List<Aluno>> Listar()
        {
            return Task.FromResult(alunos);
        }

        public Task<Aluno?> BuscarPorEmail(string email)
        {
            var aluno = alunos.FirstOrDefault(a => a.Email == email);

            return Task.FromResult(aluno);
        }

        public Task<List<Aluno>> BuscarPorNome(string nome)
        {
            var resultado = alunos
                .Where(a => a.FirstName.ToLower().Contains(nome.ToLower()))
                .ToList();

            return Task.FromResult(resultado);
        }

    }
}