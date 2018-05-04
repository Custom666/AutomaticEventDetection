using System;
using System.Collections;

namespace AEDCore.Models
{
    /// <summary>
    /// Plain-old CLR object represents event.
    /// </summary>
    public class EventModel : ICloneable
    {
        public bool IsEvent { get; set; }

        public EventType EventType { get; set; }

        public string ID { get; set; }

        public string Culture { get; set; }

        public DateTime DateTime { get; set; }

        public string Message { get; set; }

        public SymptomModel SymptomModel { get; set; }

        public object Clone()
        {
            return new EventModel()
            {
                IsEvent = IsEvent,
                EventType = EventType,
                ID = ID,
                Culture = Culture,
                DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, DateTime.Hour, DateTime.Minute, DateTime.Second),
                Message = Message,
                SymptomModel = SymptomModel.Clone() as SymptomModel
            };
        }
    }
}
