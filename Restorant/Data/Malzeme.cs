using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restorant.Data;

namespace Restorant.Models;

public partial class Malzeme
{
    public int Id { get; set; }
    [Required(ErrorMessage = "*Zorunlu alan")]

    public string? Ad { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]
    public string? Turu { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]

    public string? Fiyat {  get; set; } 
    public string? StokId {  get; set; }    
    public Stok? Stok { get; set; } 

    public bool? Gorunurluk { get; set; }
   public ICollection<UrunMalzeme> urunMalzemes {  get; set; }=new List<UrunMalzeme>(); 
}
