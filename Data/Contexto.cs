using Microsoft.EntityFrameworkCore;
using MySqlConnectionPOO.Models;

namespace MySqlConnectionPOO.Data;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }
   public DbSet<User> Users { get; set; }
   public DbSet<Address> Addresses { get; set; }
}
