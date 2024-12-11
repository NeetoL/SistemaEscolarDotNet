using SistemaEscolar.Models;

namespace SistemaEscolar.Services.Interfaces
{
    public interface IEscolaService
    {
        // ================= ALUNOS =================
        Task<List<Aluno>> GetStudents();
        Task AddStudentAsync(Aluno student);
        Task SaveChangesAsync();
        Task<Aluno> GetStudentByIdAsync(int id);
        Task<Aluno> UpdateStudentAsync(Aluno alunoDto);
        Task<Aluno> DeleteStudentByIdAsync(int id);

        // ================= FUNCIONARIOS =================
        Task<List<Funcionario>> GetFuncionarios();
        Task AddFuncionarioAsync(Funcionario funcionario);
        Task<Funcionario> GetFuncionarioByIdAsync(int id);
        Task<Funcionario> UpdateFuncionarioAsync(Funcionario funcionarioDto);
        Task<Funcionario> DeleteFuncionarioByIdAsync(int id);

    }
}
