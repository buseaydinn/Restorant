﻿namespace Restorant.Data
{
    public class Sepet
    {
        public int Id { get; set; }

        public int MenuId { get; set; }
                                
        public int UrunId { get; set; }

        public int? Fiyat { get; set; }

        public int? Miktar { get; set; }
        public int? ToplamFiyat { get; set; }
 
    }
}
