using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Models;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionariosController : Controller
    {
        private readonly IEscolaService _service;

        public FuncionariosController(IEscolaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetFuncionarios()
        {
            var funcionarios = await _service.GetFuncionarios();
            return Ok(funcionarios);
        }

        [HttpPost]
        public async Task<IActionResult> SaveFuncionario([FromBody] Funcionario funcionario)
        {
            if (funcionario == null || string.IsNullOrEmpty(funcionario.Nome))
            {
                return BadRequest("Dados inválidos.");
            }

            await _service.AddFuncionarioAsync(funcionario);
            await _service.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFuncionarioById), new { id = funcionario.Id }, funcionario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionarioById(int id)
        {
            var funcionario = await _service.GetFuncionarioByIdAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFuncionario(int id, [FromBody] Funcionario funcionarioDto)
        {
            if (funcionarioDto == null || id != funcionarioDto.Id)
            {
                return BadRequest(new { message = "Dados inválidos para atualização." });
            }

            var funcionarioAtualizado = await _service.UpdateFuncionarioAsync(funcionarioDto);

            if (funcionarioAtualizado == null)
            {
                return NotFound(new { message = "Funcionário não encontrado." });
            }

            return Ok(new
            {
                message = "Funcionário atualizado com sucesso.",
                funcionario = funcionarioAtualizado
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionarioById(int id)
        {
            var funcionario = await _service.DeleteFuncionarioByIdAsync(id);

            if (funcionario == null)
            {
                return NotFound(new { message = "Funcionário não encontrado." });
            }

            return Ok(new { message = "Funcionário removido com sucesso.", funcionario });
        }
    }
}
