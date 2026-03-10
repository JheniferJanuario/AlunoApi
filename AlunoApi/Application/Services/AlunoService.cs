using AlunoApi.Domain.Entities;
using AlunoApi.Domain.Interfaces;

namespace AlunoApi.Application.Services
{
    public class AlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Aluno> Matricular(Aluno aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.FirstName))
                throw new Exception("FirstName é obrigatório");

            if (aluno.FirstName.Length > 50)
                throw new Exception("FirstName deve ter no máximo 50 caracteres");

            if (string.IsNullOrWhiteSpace(aluno.Email) ||
                !aluno.Email.EndsWith("@faculdade.edu"))
                throw new Exception("Email deve terminar com @faculdade.edu");

            var existente = await _repository.BuscarPorEmail(aluno.Email);

            if (existente != null)
                throw new Exception("Email já cadastrado");

            aluno.Id = Guid.NewGuid();

            return await _repository.Matricular(aluno);
        }

        public async Task<List<Aluno>> Listar()
        {
            return await _repository.Listar();
        }

        public async Task<List<Aluno>> BuscarPorNome(string nome)
        {
            return await _repository.BuscarPorNome(nome);
        }
    }
}
