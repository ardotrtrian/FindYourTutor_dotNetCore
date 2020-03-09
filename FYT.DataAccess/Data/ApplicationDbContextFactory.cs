using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = @"server=(LocalDb)\MSSQLLocalDB;database=FYT;
                                integrated security=True; MultipleActiveResultSets=True;App=EntityFramework;";
            optionsBuilder
                .UseSqlServer(connectionString, options => options
                .EnableRetryOnFailure())
                .ConfigureWarnings(warnings => warnings.
                Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
