using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorant.Models;

public partial class Masa
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]

    public string? Kod { get; set; }

    public bool? Durum { get; set; }

    public int? Kapasite { get; set; }

    public string? Qr { get; set; }

    public int? Tutar { get; set; }

    public int? KategoriId { get; set; }

    public bool? Gorunurluk { get; set; }

    public int? PersonelId { get; set; }

    public  ICollection<MasaOzellik> masaOzelliks { get; set; } = new List<MasaOzellik>();

    public  Personel? Personel { get; set; }

    public  Kategori? Kategori { get; set; }
}
