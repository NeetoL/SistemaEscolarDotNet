using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Models;
using SistemaEscolar.Services.Interfaces;

namespace UniSaoJose.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IEscolaService _service;

        public AlunoController(IEscolaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _service.GetStudents();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> SaveStudent([FromBody] Aluno student)
        {
            if (student == null || string.IsNullOrEmpty(student.Nome))
            {
                return BadRequest("Dados inválidos.");
            }

            await _service.AddStudentAsync(student);

            await _service.SaveChangesAsync();

            // Retorna uma resposta de sucesso com o recurso criado
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Aluno alunoDto)
        {
            if (alunoDto == null || id != alunoDto.Id)
            {
                return BadRequest(new { message = "Dados inválidos para atualização." });
            }

            var alunoAtualizado = await _service.UpdateStudentAsync(alunoDto);

            if (alunoAtualizado == null)
            {
                return NotFound(new { message = "Aluno não encontrado." });
            }

            return Ok(new
            {
                message = "Aluno atualizado com sucesso.",
                aluno = alunoAtualizado
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            var student = await _service.DeleteStudentByIdAsync(id);

            return Ok(student);
        }
    }
}
