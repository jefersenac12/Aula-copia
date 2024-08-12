namespace Aula2407.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string validade_Pro { get; set; }
        public int quatidade { get; set; }
        public decimal valorUnitario { get; set; } 
        public decimal valorTotal { get; set; }

    }
}