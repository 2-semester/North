﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using North.Facade.Common;

namespace North.Facade.Event
{
    public sealed class EventView : DefinedView
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Kuupäev")]
        public DateTime EventDate { get; set; }

        [Required]
        [DisplayName("Spordivaldkond")]
        //dropdownlist 5 asjaga
        public string SportCategoryId { get; set; }

        [Required]
        [DisplayName("Spordiala")]
        public string TypeId { get; set; }

        [Required]
        [DisplayName("Korraldaja")]
        public string OrganizationId { get; set; }

        [DisplayName("Ürituste sari")] 
        //dropdown list 5asja
        public string EventListId { get; set; }
        [Required]
        [DisplayName("Registreerimis number")]
        public string SportsmanEventId { get; set; }

        public string GetId()
        {
            return $"{SportCategoryId}.{EventListId}.{OrganizationId}.{TypeId}.{SportCategoryId}";
        }
    }

}
