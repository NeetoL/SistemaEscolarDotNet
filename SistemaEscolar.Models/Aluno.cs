namespace SistemaEscolar.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string? Matricula { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Genero { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public string? Curso { get; set; }
        public int Semestre { get; set; }
        public string? Turma { get; set; }
        public DateTime DataMatricula { get; set; }
        public string? Status { get; set; }
        public decimal CoeficienteRendimento { get; set; }
        public bool BolsaEstudo { get; set; }
        public decimal ValorMensalidade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
