using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data;
using SistemaEscolar.Models;
using SistemaEscolar.Services.Interfaces;

namespace SistemaEscolar.Services.Implementacoes
{
    public class EscolaService : IEscolaService
    {
        private readonly USJDbContext _context;

        public EscolaService(USJDbContext context)
        {
            _context = context;
        }

        // ================= ALUNOS =================

        public async Task<List<Aluno>> GetStudents()
        {
            var alunos = await _context.Alunos.ToListAsync();
            return alunos ?? new List<Aluno>();
        }

        public async Task AddStudentAsync(Aluno student)
        {
            if (student == null)
                throw new ArgumentException("Estudante inválido.");

            await _context.Alunos.AddAsync(student);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Aluno> GetStudentByIdAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            return aluno ?? new Aluno();
        }

        public async Task<Aluno> UpdateStudentAsync(Aluno alunoDto)
        {
            if (alunoDto == null)
                throw new ArgumentException("Dados do aluno inválidos.");

            var aluno = await _context.Alunos.FindAsync(alunoDto.Id);

            if (aluno == null)
                return new Aluno();

            aluno.Nome = alunoDto.Nome;
            aluno.Matricula = alunoDto.Matricula;
            aluno.CPF = alunoDto.CPF;
            aluno.DataNascimento = alunoDto.DataNascimento;
            aluno.Genero = alunoDto.Genero;
            aluno.Email = alunoDto.Email;
            aluno.Telefone = alunoDto.Telefone;
            aluno.Endereco = alunoDto.Endereco;
            aluno.Cidade = alunoDto.Cidade;
            aluno.Estado = alunoDto.Estado;
            aluno.CEP = alunoDto.CEP;
            aluno.Curso = alunoDto.Curso;
            aluno.Semestre = alunoDto.Semestre;
            aluno.Turma = alunoDto.Turma;
            aluno.DataMatricula = alunoDto.DataMatricula;
            aluno.Status = alunoDto.Status;
            aluno.CoeficienteRendimento = alunoDto.CoeficienteRendimento;
            aluno.BolsaEstudo = alunoDto.BolsaEstudo;
            aluno.ValorMensalidade = alunoDto.ValorMensalidade;
            aluno.UltimaAtualizacao = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<Aluno> DeleteStudentByIdAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                return new Aluno();

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        // ================= FUNCIONARIOS =================

        public async Task<List<Funcionario>> GetFuncionarios()
        {
            var funcionarios = await _context.Funcionarios.ToListAsync();
            return funcionarios ?? new List<Funcionario>(); // Retorna lista vazia.
        }

        public async Task AddFuncionarioAsync(Funcionario funcionario)
        {
            if (funcionario == null)
                throw new ArgumentException("Dados do funcionário inválidos.");

            await _context.Funcionarios.AddAsync(funcionario);
        }

        public async Task<Funcionario> GetFuncionarioByIdAsync(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            return funcionario ?? new Funcionario();
        }

        public async Task<Funcionario> UpdateFuncionarioAsync(Funcionario funcionarioDto)
        {
            if (funcionarioDto == null)
                throw new ArgumentException("Dados do funcionário inválidos.");

            var funcionario = await _context.Funcionarios.FindAsync(funcionarioDto.Id);

            if (funcionario == null)
                return new Funcionario();

            funcionario.Nome = funcionarioDto.Nome;
            funcionario.Matricula = funcionarioDto.Matricula;
            funcionario.CPF = funcionarioDto.CPF;
            funcionario.DataNascimento = funcionarioDto.DataNascimento;
            funcionario.Genero = funcionarioDto.Genero;
            funcionario.Email = funcionarioDto.Email;
            funcionario.Telefone = funcionarioDto.Telefone;
            funcionario.Endereco = funcionarioDto.Endereco;
            funcionario.Cidade = funcionarioDto.Cidade;
            funcionario.Estado = funcionarioDto.Estado;
            funcionario.CEP = funcionarioDto.CEP;
            funcionario.Cargo = funcionarioDto.Cargo;
            funcionario.Departamento = funcionarioDto.Departamento;
            funcionario.Salario = funcionarioDto.Salario;
            funcionario.DataAdmissao = funcionarioDto.DataAdmissao;
            funcionario.Status = funcionarioDto.Status;
            funcionario.PossuiPlanoSaude = funcionarioDto.PossuiPlanoSaude;
            funcionario.PossuiValeTransporte = funcionarioDto.PossuiValeTransporte;
            funcionario.Escolaridade = funcionarioDto.Escolaridade;
            funcionario.UltimaAtualizacao = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return funcionario;
        }

        public async Task<Funcionario> DeleteFuncionarioByIdAsync(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
                return new Funcionario();

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return funcionario;
        }
    }
}
