public class VendaModel
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataVenda { get; set; }

    public ProdutoModel Produto { get; set; }
}