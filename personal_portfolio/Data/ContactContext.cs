
using Microsoft.EntityFrameworkCore;
using Personal_Portfolio.Models;


namespace Personal_Portfolio.Data;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {

    }

    // increment the id of the model
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }

    public DbSet<ContactMeModel> ContactDb { get; set; }

}
