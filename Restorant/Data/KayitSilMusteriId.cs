using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restorant.Data;

namespace Restorant.Models;
public class KayitSilMusteriId
    {
    public int Id { get; set; }
    //[Required(ErrorMessage = "*Zorunlu alan")]
    public string? Ad { get; set; }

    //[Required(ErrorMessage = "*Zorunlu alan")]

    //[RegularExpression(@"^5\d{2} \d{3} \d{4}$", ErrorMessage = "*Geçerli bir telefon numarası giriniz (5xx xxx xxxx)")]
    public string? Telefon { get; set; }

    public int RezervasyonId { get; set; }

    public bool? Gorunurluk { get; set; }

}

