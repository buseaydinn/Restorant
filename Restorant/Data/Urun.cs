using Restorant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorant.Data;

public partial class Urun
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]

    public string? Ad { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]

    public string? Acıklama { get; set; }

    public string? Detay { get; set; }

    public int? Fiyat { get; set; }

    public string? Fotograf { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]

    public string? Aktif { get; set; }

    public decimal? IndirimliFiyat { get; set; }

    public int? IndirimYuzdesi{ get; set; }

    public DateOnly? IndirimTarihi{ get; set; }

    public bool? Gorunurluk{ get; set; }

    public Kategori? Kategori{ get; set; }

    public int? KategoriId { get; set; }
}
    