using System;
using System.Collections.Generic;

namespace Restorant.Models;

public partial class Kategori
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public string? Tür {  get; set; } 
    
    public bool? Gorunurluk { get; set; }
}
