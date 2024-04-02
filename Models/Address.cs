using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySqlConnectionPOO.Models;

[Table("ADDRESS")]
public class Address
{
    [Display(Name = "Código")]
    [Column("id")]
    public int Id { get; set; }
    [Display(Name = "Número")]
    [Column("number")]
    public string Number { get; set; }
    [Display(Name = "Rua")]
    [Column("street")]
    public string Street { get; set; }
    [Display(Name = "Complemento")]
    [Column("complement")]
    public string Complement { get; set; }
    [Display(Name = "Cidade")]
    [Column("city")]
    public string City { get; set; }
    [Display(Name = "Estado")]
    [Column("state")]
    public string State { get; set; }
    [Display(Name = "Zip Code")]
    [Column("zip_code")]
    public string ZipCode { get; set; }
    [Display(Name = "País")]
    [Column("country")]
    public string Country { get; set; }
    [Display(Name = "País")]
    [Column("country")]
    public ICollection<User?> Users { get; set; } = new List<User?>();

}






