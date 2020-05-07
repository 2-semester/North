using System;
using System.Collections.Generic;
using System.Linq;
using North.Data.SportCategory;
using North.Data.Event;
using North.Data.Organization;

namespace North.Infra
{
    public static class NorthDbInitializer
    {
        internal static List<SportCategoryData> sportCategories => new List<SportCategoryData>
        {
            jooksmine, ujumine, surfamine, jalgrattasõit, discgolf
        };
        internal static List<EventData> eventsList => new List<EventData>
        {
            heaTeoJooks, parnuOpen, ristnaSoit
        };
        internal static List<OrganizationData> organizations => new List<OrganizationData>
        {
            
        };
        private static void InitializeOrganizations(NorthDbContext db)
        {
            if (db.Organizations.Count() != 0) return;
            db.Organizations.AddRange(organizations);
            db.SaveChanges();
        }
        private static void InitializeSportCategories(NorthDbContext db)
        {
            if (db.SportCategories.Count() != 0) return;
            db.SportCategories.AddRange(sportCategories);
            db.SaveChanges();
        }
        private static void InitializeEvents(NorthDbContext db)
        {
            if (db.Events.Count() != 0) return;
            db.Events.AddRange(eventsList);
            db.SaveChanges();
        }

        public static void Initialize(NorthDbContext db)
        {
            InitializeSportCategories(db);
            InitializeEvents(db);
            InitializeOrganizations(db);
        }

        internal static SportCategoryData jooksmine = new SportCategoryData
        {
            Id = "Jooksmine", Name = "Jooksmine", 
        };

        internal static SportCategoryData ujumine = new SportCategoryData
        {
            Id = "Ujumine", Name = "Ujumine",
            
        };

        internal static SportCategoryData surfamine = new SportCategoryData
        {
            Id = "Surfamine", Name = "Surfamine",
        };

        internal static SportCategoryData discgolf = new SportCategoryData
        {
            Id = "Discgolf", Name = "Discgolf",
            
        };

        internal static SportCategoryData jalgrattasõit = new SportCategoryData
        {
            Id = "Jalgrattasõit", Name = "Jalgrattasõit",
        };


        internal static EventData heaTeoJooks = new EventData
        {
            Id = "Heateo Jooks",
            Name = "Heateo Jooks",
            EventDate = Convert.ToDateTime("07/05/20"),
            SportCategoryId="Jooksmine",
            TypeId="rahvajooks"
        };

        internal static EventData parnuOpen = new EventData
        {
            Id = "ITB Pärnu Open 2020",
            Name = "ITB Pärnu Open 2020",
            EventDate = Convert.ToDateTime("12/08/20"),
            SportCategoryId = "Discgolf",
            TypeId = "karikasari"
        };
        internal static EventData ristnaSoit = new EventData
        {
            Id = "Ristna öösõit",
            Name = "Ristna öösõit",
            EventDate = Convert.ToDateTime("06/06/21"),
            SportCategoryId = "Jalgrattasõit",
            TypeId = "maastikusõit"
        };

        internal static OrganizationData SEB = new OrganizationData
        {
            Id = "SEB",
            Name = "SEB",
            Definition = "Eesti innovatiivseim pank"
        };
        internal static OrganizationData sportland = new OrganizationData
        {
            Id = "Sportland",
            Name = "Sportland",
            Definition = "Muuta noorte inimeste elu huvitavamaks, paremaks ja emotsionaalsemaks läbi pakutavate toodete ning teenuste."
        };

    }
}

