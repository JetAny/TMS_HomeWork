using Microsoft.EntityFrameworkCore;


namespace MyGarageDB.Interfaces
{
    public interface IDbContext
    {
        DbSet<GarageDB> Garages { get; set; }
        DbSet<TransportDB> Transports { get; set; }
        DbSet<TypeDB> Types { get; set; }

        int SaveChanges();
    }
}
