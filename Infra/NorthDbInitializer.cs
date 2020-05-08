﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using North.Data.SportCategory;
using North.Data.Event;
using North.Data.EventList;
using North.Data.Location;
using North.Data.Organization;

namespace North.Infra
{
    public static class NorthDbInitializer
    {
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
            TypeId="rahvajooks",
            EventListId = "puudub",
            OrganizationId = "Sportland",
            Definition="Heategevusjooksu eesmärgiks on koguda raha Vähiliidule. Raja pikkus on 5 km, tule osale kogu perega!"
        };

        internal static EventData parnuOpen = new EventData
        {
            Id = "ITB Pärnu Open 2020",
            Name = "ITB Pärnu Open 2020",
            EventDate = Convert.ToDateTime("12/08/20"),
            SportCategoryId = "Discgolf",
            TypeId = "karikasari",
            EventListId = "puudub",
            OrganizationId = "puudub",
            Definition="Karikasarja avalöök 2020"
        };
        internal static EventData ristnaSoit = new EventData
        {
            Id = "Ristna öösõit",
            Name = "Ristna öösõit",
            EventDate = Convert.ToDateTime("06/06/21"),
            SportCategoryId = "Jalgrattasõit",
            TypeId = "maastikusõit",
            EventListId="puudub",
           OrganizationId = "SEB",
           Definition = "Rada kulgeb sarnases kohas, kus eelmisel aastal toimus Kaugeima neeme sõit," +
                        "kuid piiratud nähtavuse tõttu on sealt välja jäetud tehnilised singlid ja" +
                        "suurt tähelepanu nõudvad laskumised. Mägirattakrossi raja valgustamiseks " +
                        "pannakse tee äärde 500 õueküünalt. Ringi pikkuseks on 4,2 km ning valida" +
                        " saab võistlus- (start kell 20) ja matkadistantsi (start kell 21) vahel."
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

        internal static OrganizationData puudub = new OrganizationData
        {
            Id = "Puudub",
            Name = "Puudub",
            Definition = ""
        };
        internal static LocationData Harju = new LocationData()
        {
            Id = "Harju maakond",
            Name = "Harju maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        };
        internal static LocationData Lääne = new LocationData()
        {
            Id = "Lääne maakond",
            Name = "Lääne maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        }; internal static LocationData Põlva = new LocationData()
        {
            Id = "Põlva maakond",
            Name = "Põlva maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        }; internal static LocationData Hiiu = new LocationData()
        {
            Id = "Hiiu maakond",
            Name = "Hiiu maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        }; internal static LocationData Saare = new LocationData()
        {
            Id = "Saare maakond",
            Name = "Saare maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        }; internal static LocationData Pärnu = new LocationData()
        {
            Id = "Pärnu maakond",
            Name = "Pärnu maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        }; internal static LocationData LääneViru = new LocationData()
        {
            Id = "Lääne-Viru maakond",
            Name = "Lääne-Viru maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        }; internal static LocationData IdaViru = new LocationData()
        {
            Id = "Ida-Viru maakond",
            Name = "Ida-Viru maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        }; internal static LocationData Rapla = new LocationData()
        {
            Id = "Rapla maakond",
            Name = "Rapla maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        };
        internal static LocationData Järva = new LocationData()
        {
            Id = "Järva maakond",
            Name = "Järva maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        };
        internal static LocationData Jõgeva = new LocationData()
        {
            Id = "Jõgeva maakond",
            Name = "Jõgeva maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        };
        internal static LocationData Viljandi = new LocationData()
        {
            Id = "Viljandi maakond",
            Name = "Viljandi maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        };
        internal static LocationData Tartu = new LocationData()
        {
            Id = "Tartu maakond",
            Name = "Tartu maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        };
        internal static LocationData Valga = new LocationData()
        {
            Id = "Valga maakond",
            Name = "Valga maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        };
        internal static LocationData Võru = new LocationData()
        {
            Id = "Võru maakond",
            Name = "Võru maakond",
            EventId = "",
            EventListId = "",
            County = "",
            City = ""
        };
        internal static EventListData rattamaraton = new EventListData
        {
            Id = "Hawaii Express Estonian Cup",
            Name = "Hawaii Express Estonian Cup",
            EventId = "Ristna öösõit",
          
        };
        internal static EventListData surfisari = new EventListData
        {
            Id = "Fun sari",
            Name = "Fun sari",
            EventId = "",

        };
        internal static List<EventListData> eventLists => new List<EventListData>
        {
         rattamaraton, surfisari
        };
        internal static List<LocationData> counties => new List<LocationData>
        {
            Harju, IdaViru, LääneViru, Lääne, Rapla, Jõgeva, Järva, Hiiu, Saare, Pärnu, Viljandi, Tartu, Põlva, Võru
        };
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
            SEB, sportland, puudub
        };
        private static void InitializeEventLists(NorthDbContext db)
        {
            if (db.EventLists.Count() != 0) return;
            db.EventLists.AddRange(eventLists);
            db.SaveChanges();
        }
        private static void InitializeLocations(NorthDbContext db)
        {
            if (db.Locations.Count() != 0) return;
            db.Locations.AddRange(counties);
            db.SaveChanges();
        }
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
            InitializeLocations(db);
            InitializeEventLists(db);
        }

    

    }
}

