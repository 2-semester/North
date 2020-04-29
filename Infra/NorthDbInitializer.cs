using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using North.Data.SportCategory;

namespace North.Infra
{
    public static class NorthDbInitializer
    {
        internal static SportCategoryData jooksmine = new SportCategoryData
        {
            Id = "Jooksmine", Name = "Jooksmine", SportCategoryId = "Jooksmine"
        };

        internal static SportCategoryData ujumine = new SportCategoryData
        {
            Id = "Ujumine", Name = "Ujumine",
            SportCategoryId = "Ujumine"
        };

        internal static SportCategoryData surfamine = new SportCategoryData
        {
            Id = "Surfamine", Name = "Surfamine",
            SportCategoryId = "Surfamine"
        };

        internal static SportCategoryData discgolf = new SportCategoryData
        {
            Id = "Discgolf", Name = "Discgolf",
            SportCategoryId = "Discgolf"
        };

        internal static SportCategoryData jalgrattasõit = new SportCategoryData
        {
            Id = "Jalgrattasõit", Name = "Jalgrattasõit",
            SportCategoryId = "Jalgrattasõit"
        };
        
        internal static List<SportCategoryData> sportCategories => new List<SportCategoryData>
        {
            jooksmine, ujumine, surfamine, jalgrattasõit, discgolf
        };

        private static void InitializeSportCategories(NorthDbContext db)
        {
            if (db.SportCategories.Count() != 0) return;
            db.SportCategories.AddRange(sportCategories);
            db.SaveChanges();
        }

        public static void Initialize(NorthDbContext db) 
        {
            InitializeSportCategories(db);
        }
    }
}

