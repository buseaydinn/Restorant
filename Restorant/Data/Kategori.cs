using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restorant.Data;

namespace Restorant.Models;

public partial class Kategori
{
    public int Id { get; set; }

    //[Required(ErrorMessage = "*Zorunlu alan")]
    public string? Ad { get; set; }

    public string? Tur {  get; set; } 
    
    public bool? Gorunurluk { get; set; }
}
