using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Context
{
    public class FinalAssignmentContextFactory : IDesignTimeDbContextFactory<FinalAssignmentContext>
    {
        public FinalAssignmentContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("FinalAssignment");
            var optionBuilder = new DbContextOptionsBuilder<FinalAssignmentContext>().UseSqlServer(connectionString);
            return new FinalAssignmentContext(optionBuilder.Options);
        }
    }
}
