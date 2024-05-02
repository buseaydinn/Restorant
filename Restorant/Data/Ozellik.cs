using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restorant.Models;

public partial class Ozellik
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu alan")]

    public int Ad { get; set; }

    public bool? Gorunurluk { get; set; }
  
}
