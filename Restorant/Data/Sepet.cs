namespace Restorant.Data
{
    public class Sepet
    {
        public int Id { get; set; }
        public string Menu { get; set; }
                                
        public string? Urun { get; set; }

        public decimal? Fiyat { get; set; }

        public int? Miktar { get; set; }

        public int? ToplamFiyat { get; set; }

    }
}
