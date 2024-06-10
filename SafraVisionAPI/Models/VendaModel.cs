namespace SafraVisionAPI.Models
{
    public class VendaModel
    {
        public int idVenda { get; set; }
        public double qtdVendida { get; set; }
        public DateTime dataVenda { get; set; }
        public int? idComprador { get; set; }
        public virtual CompradorModel? Comprador { get; set; }

    }
}
