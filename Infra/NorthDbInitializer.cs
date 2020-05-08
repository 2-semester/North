using System;
using System.Collections.Generic;
using System.Linq;
using North.Data.SportCategory;
using North.Data.Event;
using North.Data.EventList;
using North.Data.Location;
using North.Data.Organization;
using North.Data.Sportsman;

namespace North.Infra
{
    public static class NorthDbInitializer
    {
        internal static SportCategoryData jooksmine = new SportCategoryData
        {
            Id = "Jooksmine", Name = "Jooksmine"
        };

        internal static SportCategoryData ujumine = new SportCategoryData
        {
            Id = "Ujumine", Name = "Ujumine"
            
        };

        internal static SportCategoryData surfamine = new SportCategoryData
        {
            Id = "Surfamine", Name = "Surfamine"
        };

        internal static SportCategoryData discgolf = new SportCategoryData
        {
            Id = "Discgolf", Name = "Discgolf"
            
        };

        internal static SportCategoryData jalgrattasõit = new SportCategoryData
        {
            Id = "Jalgrattasõit", Name = "Jalgrattasõit"
        };


        internal static EventData heaTeoJooks = new EventData
        {
            Id = "Heateo Jooks",
            Name = "Heateo Jooks",
            EventDate = Convert.ToDateTime("07/05/20"),
            SportCategoryId="Jooksmine",
            TypeId="Rahvajooks",
            EventListId = "Puudub",
            OrganizationId = "Sportland",
            LocationId = "Jõgeva maakond",
            Definition="Heategevusjooksu eesmärgiks on koguda raha Vähiliidule. Raja pikkus on 5 km, tule osale kogu perega!"
        };

        internal static EventData parnuOpen = new EventData
        {
            Id = "ITB Pärnu Open 2020",
            Name = "ITB Pärnu Open 2020",
            EventDate = Convert.ToDateTime("12/08/20"),
            SportCategoryId = "Discgolf",
            TypeId = "Karikasari",
            EventListId = "Puudub",
            OrganizationId = "Puudub",
            LocationId = "Pärnu maakond",
            Definition="Karikasarja avalöök 2020"
        };
        internal static EventData ristnaSoit = new EventData
        {
            Id = "Ristna öösõit",
            Name = "Ristna öösõit",
            EventDate = Convert.ToDateTime("06/06/21"),
            SportCategoryId = "Jalgrattasõit",
            TypeId = "Maastikusõit",
            EventListId="Puudub",
           OrganizationId = "SEB",
           LocationId = "Hiiu maakond",
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
            Name= "Harju maakond"
        };
        internal static LocationData Lääne = new LocationData()
        {
            Id = "Lääne maakond",
            Name = "Lääne maakond"
        }; internal static LocationData Põlva = new LocationData()
        {
            Id = "Põlva maakond",
            Name = "Põlva maakond"
        }; internal static LocationData Hiiu = new LocationData()
        {
            Id = "Hiiu maakond",
            Name = "Hiiu maakond"
        }; internal static LocationData Saare = new LocationData()
        {
            Id = "Saare maakond",
            Name = "Saare maakond"
        }; internal static LocationData Pärnu = new LocationData()
        {
            Id = "Pärnu maakond",
            Name = "Pärnu maakond"
        }; internal static LocationData LääneViru = new LocationData()
        {
            Id = "Lääne-Viru maakond",
            Name = "Lääne-Viru maakond"
        }; internal static LocationData IdaViru = new LocationData()
        {
            Id = "Ida-Viru maakond",
            Name = "Ida-Viru maakond"
        }; internal static LocationData Rapla = new LocationData()
        {
            Id = "Rapla maakond",
            Name = "Rapla maakond"
        };
        internal static LocationData Järva = new LocationData()
        {
            Id = "Järva maakond",
            Name = "Järva maakond"
        };
        internal static LocationData Jõgeva = new LocationData()
        {
            Id = "Jõgeva maakond",
            Name = "Jõgeva maakond"
        };
        internal static LocationData Viljandi = new LocationData()
        {
            Id = "Viljandi maakond",
            Name = "Viljandi maakond"
        };
        internal static LocationData Tartu = new LocationData()
        {
            Id = "Tartu maakond",
            Name = "Tartu maakond"
        };
        internal static LocationData Valga = new LocationData()
        {
            Id = "Valga maakond",
            Name = "Valga maakond"
        };
        internal static LocationData Võru = new LocationData()
        {
            Id = "Võru maakond",
            Name = "Võru maakond"
        };
        internal static EventListData rattamaraton = new EventListData
        {
            Id = "Hawaii Express Estonian Cup",
            Name = "Hawaii Express Estonian Cup",
            EventId="Ristna öösõit"
        };
        internal static EventListData surfsari = new EventListData
        {
            Id = "Fun Surf",
            Name = "Fun Surf",
            EventId =""
        };
        internal static SportsmanData kalle = new SportsmanData()
        {
            Id = "37903041234",
            Name = "Kalle Karu",
            DateOfBirth =Convert.ToDateTime("04.03.1979") 
        };
        internal static SportsmanData liisa = new SportsmanData()
        {
            Id = "49512122034",
            Name = "Liisa Kivi",
            DateOfBirth = Convert.ToDateTime("12.12.1995")
        };

        internal static List<LocationData>locations => new List<LocationData>
        {
            Harju,IdaViru, LääneViru, Lääne, Rapla, Jõgeva, Järva, Hiiu, Saare, Pärnu, Viljandi, Tartu, Põlva, Võru, Valga
        };
        internal static List<SportCategoryData> sportCategories => new List<SportCategoryData>
        {
            jooksmine, ujumine, surfamine, jalgrattasõit, discgolf
        };
        internal static List<EventData> events => new List<EventData>
        {
            heaTeoJooks, parnuOpen, ristnaSoit
        };
        internal static List<OrganizationData> organizations => new List<OrganizationData>
        {
            SEB, sportland, puudub
        }; 
        internal static List<EventListData> eventLists => new List<EventListData>
        {
            surfsari, rattamaraton
        }; 
        internal static List<SportsmanData> sportsmen => new List<SportsmanData>
        {
            
        };
        private static void InitializeSportsmen(NorthDbContext db)
        {
            if (db.Sportsmen.Count() != 0) return;
            db.Sportsmen.AddRange(sportsmen);
            db.SaveChanges();
        }
        private static void InitializeEventLists(NorthDbContext db)
        {
            if (db.EventLists.Count() != 0) return;
            db.EventLists.AddRange(eventLists);
            db.SaveChanges();
        }
        private static void InitializeLocations(NorthDbContext db)
        {
            if (db.Locations.Count() != 0) return;
            db.Locations.AddRange(locations);
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
            db.Events.AddRange(events);
            db.SaveChanges();
        }
        public static void Initialize(NorthDbContext db)
        {
            InitializeSportCategories(db);
            InitializeEvents(db);
            InitializeOrganizations(db);
            InitializeLocations(db);
            InitializeEventLists(db);
            InitializeSportsmen(db);
        }
    }
}

