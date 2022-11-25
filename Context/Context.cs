using dotnet_agenda_de_contatos_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_agenda_de_contatos_mvc.Context
{
    public class ContactBookContext : DbContext
    {
      public ContactBookContext(DbContextOptions<ContactBookContext> options) : base(options)
      {
        
      }  

      public DbSet<Contact> Contacts { get; set; }
    }
}