using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public interface ISisContext
    {
        DbSet<Login> Logins { get; set; }
        int SaveChanges();
    }
}
