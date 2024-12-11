namespace SistemaEscolar.Models
{
    public class Funcionario
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
        public string? Cargo { get; set; }
        public string? Departamento { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string? Status { get; set; }
        public bool PossuiPlanoSaude { get; set; }
        public bool PossuiValeTransporte { get; set; }
        public string? Escolaridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
