using Microsoft.AspNetCore.Mvc;
namespace Restorant.Data { 
using Restorant.Models;

    public class SiparisDurum
    {
        public int Id { get; set; }

        public int SiparisId { get; set; }

        public int DurumId { get; set; }

        public DateTime Tarih { get; set; }

        public Siparis Siparis { get; set; }

        public Durum Durum { get; set; }
}
}

