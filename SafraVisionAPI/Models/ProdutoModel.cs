namespace SafraVisionAPI.Models
{
    public class ProdutoModel
    {
        public int idProduto { get; set; }
        public String? nomeProduto { get; set; }
        public String? descricao { get; set; }
        public double preco { get; set; }
        public double qtdEstoque { get; set; }
    }
}
    