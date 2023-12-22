using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Territories.Any()) return;
            
            var territories = new List<Territory>
{
    new Territory
    {
        Name = "Northland",
        Governor = "Governor North",
        Population = 50000,
        Resource = "Gold"
    },
    new Territory
    {
        Name = "Southville",
        Governor = "Governor South",
        Population = 30000,
        Resource = "Silver"
    },
    new Territory
    {
        Name = "Easton",
        Governor = "Governor East",
        Population = 45000,
        Resource = "Iron"
    },
    new Territory
    {
        Name = "Westwood",
        Governor = "Governor West",
        Population = 40000,
        Resource = "Wood"
    }
};

            await context.Territories.AddRangeAsync(territories);
            await context.SaveChangesAsync();
        }
    }
}