using Restorant.Models;

namespace Restorant.Data
{
    public class Odeme
    {public string  Id { get; set; }
    public int  Tur { get; set; }
    public decimal Tutar   { get; set; }
    public int SiparisId{ get; set; }
    public Siparis?  Siparis { get; set; }
    }
}
