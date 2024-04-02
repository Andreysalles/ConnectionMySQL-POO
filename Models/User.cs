using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace MySqlConnectionPOO.Models;

[Table("USER")]
public class User
{
    [Display(Name = "Código")]
    [Column("id")]
    public int Id { get; set; }
    [Display(Name = "Código do endereço")]
    [ForeignKey("address_id")]
    [Column("address_id")]
    public int AddressId { get; set; }
    [Display(Name = "Nome")]
    [Column("name")]
    public string Name { get; set; }
    [Display(Name = "Email")]
    [Column("email")]
    public string Email { get; set; }
    [Display(Name = "Telefone")]
    [Column("phone")]
    public string Phone { get; set; }
    [Display(Name = "Documento")]
    [Column("document")]
    public string Document { get; set; }
    [Display(Name = "Status")]
    [Column("status")]
    public string Status { get; set; }

    public Address? Address { get; set; }
}





