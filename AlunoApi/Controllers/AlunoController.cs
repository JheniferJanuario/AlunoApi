using Microsoft.AspNetCore.Mvc;
using AlunoApi.Application.Services;
using AlunoApi.Domain.Entities;

namespace AlunoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _service;

        public AlunoController(AlunoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Matricular(Aluno aluno)
        {
            var result = await _service.Matricular(aluno);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var alunos = await _service.Listar();

            return Ok(alunos);
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> BuscarPorNome(string nome)
        {
            var alunos = await _service.BuscarPorNome(nome);

            if (alunos == null || !alunos.Any())
                return NotFound("Aluno não está matriculado");

            return Ok(alunos);
        }
    }
}