using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restorant.Data;

namespace Restorant.Models;

public partial class Personel
{
    public int Id { get; set; }

    public string? Ad { get; set; }


    //[Required(ErrorMessage = "*Zorunlu alan")]

    public string? Soyad { get; set; }

   [Required(ErrorMessage = "*Zorunlu alan")]

    [EmailAddress(ErrorMessage = "*Geçerli bir e-posta adresi giriniz")]
    public string? Eposta { get; set; }


    //[Required(ErrorMessage = "*Zorunlu alan")]

    //[RegularExpression(@"^5\d{2} \d{3} \d{4}$", ErrorMessage = "*Geçerli bir telefon numarası giriniz (5xx xxx xxxx)")]
    public string? Telefon { get; set; }



    //[Required(ErrorMessage = "*Zorunlu alan")]

    public float? Maas { get; set; }


    //[Required(ErrorMessage = "*Zorunlu alan")]

    public DateOnly? DogumTarihi { get; set; }


    //[Required(ErrorMessage = "*Zorunlu alan")]

    public DateOnly? BaslamaTarihi { get; set; }


    //[Required(ErrorMessage = "*Zorunlu alan")]
    public string? Cinsiyet { get; set; }

    public bool? Gorunurluk { get; set; }

    public int? RolId { get; set; }


    //[Required(ErrorMessage = "*Zorunlu alan")]

     public string? Adres {  get; set; }  
    
    public string? Fotograf {  get; set; }


    [Required(ErrorMessage = "*Zorunlu alan")]
    ////[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "*Şifre en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
    public string? Sifre { get; set; }


    public ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();

    public  ICollection<Masa> Masalars { get; set; } = new List<Masa>();

    public  Rol? Rol { get; set; }

    public  ICollection<Teslimat> Teslimatlars { get; set; } = new List<Teslimat>();
}
