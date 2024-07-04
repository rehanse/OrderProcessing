using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderProcessing.DataAccess.Domain;
using OrderProcessing.DataAccess.Domain.Identity;
using System.Reflection.Emit;

namespace OrderProcess.DataAccess.Persistence.DatabaseContext
{
    public class OrderProcessDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public OrderProcessDatabaseContext(DbContextOptions<OrderProcessDatabaseContext> options) : base(options)
        {

        }
        public DbSet<TORDERS> TORDERs { get; set; }
    }
}
