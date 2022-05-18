using Microsoft.EntityFrameworkCore;
using MysqlProba.Model;

namespace MysqlProba.Data
{
    public class MySqlDataContext : DbContext
    {
        public DbSet<Diak> Diakok { get; set; }

        public MySqlDataContext(DbContextOptions<MySqlDataContext> options) : base(options)
        {

        }
    }
}
