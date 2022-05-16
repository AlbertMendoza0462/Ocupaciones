using Microsoft.EntityFrameworkCore;
public class Contexto:DbContext
{
    public DbSet<Ocupacion>? Ocupaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"data source=Database/Ocupaciones.db");
    }
}