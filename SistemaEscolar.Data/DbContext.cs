using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Models;

namespace SistemaEscolar.Data
{
    public class USJDbContext : DbContext
    {
        public USJDbContext(DbContextOptions<USJDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
