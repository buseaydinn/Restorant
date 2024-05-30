using Restorant.Models;
using Restorant.Data;

namespace Restorant.Areas.Garson.Models
{
    public class SiparislerModelView
    {
        public List<Siparis>? OnaysizSiparisler { get; set; }

        public List<Siparis>? GecmisSiparisler { get; set; }

        public List<SiparisUrun>? SiparisUrunler { get; set; }

        public List<SiparisMenu>? SiparisMenuler { get; set; }

        public List<SiparisDurum>? SiparisDurumlar { get; set; }
    }
}

