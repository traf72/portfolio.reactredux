using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ReactRedux.DAL
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ReactReduxContext>
    {
        public ReactReduxContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReactReduxContext>();
            optionsBuilder.UseSqlite(@"Data Source=test.db");
            return new ReactReduxContext(optionsBuilder.Options);
        }
    }
}