using Restorant.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorant.Models;

public partial class Menu
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]

    public string? Ad { get; set; }


    [Required(ErrorMessage = "*Zorunlu alan")]
    public string? Aciklama { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]

    public decimal? Fiyat { get; set; }

    public bool? Gorunurluk { get; set; }

    public string? Fotograf { get; set; }


    [Required(ErrorMessage = "*Zorunlu alan")]

    public bool Akitf { get; set; }

    public float? IndirimliFiyat { get; set; }

    public int? IndirimYuzdesi { get; set; }

    public DateOnly? IndirimTarihi { get; set; }

    public int? KategoriId { get; set; }

    public Kategori? Kategori { get; set; }
    public ICollection<MenuUrun> menuurunler { get; set; } = [];

}
