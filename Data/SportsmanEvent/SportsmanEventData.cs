﻿using North.Data.Common;

namespace North.Data.SportsmanEvent
{
    public sealed class SportsmanEventData :UniqueEntityData
    {
        public string SportsmanId { get; set; }
        public string EventId { get; set; }
    }
}