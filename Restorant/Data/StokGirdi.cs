using Restorant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorant.Data;

public partial class StokGirdi
{
    public int Id { get; set; }

    //[Required(ErrorMessage = "*Zorunlu alan")]

    public int Miktar { get; set; }


    //[Required(ErrorMessage = "*Zorunlu alan")]

    public DateTime? Tarih { get; set; }

    public int? SonStok { get; set; }

    public bool? Gorunurluk { get; set; }

    public int? TedarikciId { get; set; }

    public int? MalzemeId { get; set; }

    public Malzeme? Malzeme { get; set; }

    public  Tedarikci? Tedarikci { get; set; }
}
