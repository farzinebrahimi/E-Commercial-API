using Microsoft.EntityFrameworkCore;

namespace Eshop.Data.Context
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
  {
    
  }
}