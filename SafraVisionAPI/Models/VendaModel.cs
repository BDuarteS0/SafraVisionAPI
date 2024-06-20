namespace SafraVisionAPI.Models
{
    public class VendaModel
    {
        public int idVenda { get; set; }
        public string? clienteVenda { get; set; }
        public string? produtoVenda { get; set; }
        public string? descricaoVenda { get; set; }
        public double qtdVendida { get; set; }
        public DateTime dataVenda { get; set; }
     

    }
}
