using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorant.Models;

public partial class Rol
{
    public int Id { get; set; }

    public bool? Gorunurluk { get; set; }


    [Required(ErrorMessage = "*Zorunlu alan")]

    public string? Ad { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]

    public DateTime? EklenmeTarihi { get; set; }

    public  ICollection<Personel> Personellers { get; set; } = new List<Personel>();
}
