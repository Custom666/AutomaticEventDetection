using System;
using System.Collections;

namespace AEDCore
{
    /// <summary>
    /// Plain-old CLR object represents event.
    /// </summary>
    public class EventModel
    {
        public bool IsEvent { get; set; }

        public EventType EventType { get; set; }

        public string ID { get; set; }

        public string Culture { get; set; }

        public DateTime DateTime { get; set; }

        public string Message { get; set; }

        public int[] Symptom { get; set; }
    }
}
