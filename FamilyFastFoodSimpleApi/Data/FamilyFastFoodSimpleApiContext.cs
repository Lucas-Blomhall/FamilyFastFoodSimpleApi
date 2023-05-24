using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FamilyFastFoodSimpleApi.DataModels;

namespace FamilyFastFoodSimpleApi.Data
{
    public class FamilyFastFoodSimpleApiContext : DbContext
    {
        public FamilyFastFoodSimpleApiContext (DbContextOptions<FamilyFastFoodSimpleApiContext> options)
            : base(options)
        {
        }

        public DbSet<FamilyFastFoodSimpleApi.DataModels.Recipes> Recipes { get; set; } = default!;

        public DbSet<FamilyFastFoodSimpleApi.DataModels.Cuisines> Cuisines { get; set; } = default!;

        public DbSet<FamilyFastFoodSimpleApi.DataModels.Ingredients> Ingredients { get; set; } = default!;

        public DbSet<FamilyFastFoodSimpleApi.DataModels.Tags> Tags { get; set; } = default!;

        public DbSet<FamilyFastFoodSimpleApi.DataModels.Categories> Categories { get; set; } = default!;

    }
}
