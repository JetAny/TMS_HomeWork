using Microsoft.EntityFrameworkCore;


namespace DBmyGarage.Interfaces
{
    public interface IDbContext
    {
        DbSet<Garage> Garage { get; set; }
        DbSet<Transport> Transport { get; set; }
        DbSet<Type> Type { get; set; }
    }
}
