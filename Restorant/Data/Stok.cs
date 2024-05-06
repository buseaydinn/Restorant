using System;
using System.Collections.Generic;
using Restorant.Models;

namespace Restorant.Data;

public partial class Stok
{
    public int Id { get; set; }

    public int? Miktar { get; set; }

    public int? MinStok { get; set; }

    public int? MaxStok { get; set; }

    public bool? Gorunurluk { get; set; }

    public int? TedarikciId { get; set; }

    public Tedarikci? Tedarikci { get; set; }

}
