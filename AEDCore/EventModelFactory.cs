using AEDCore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace AEDCore
{
    /// <summary>
    /// Factory managing creating <see cref="EventModel"/> class
    /// </summary>
    public class EventModelFactory
    {
        /// <summary>
        /// Create <see cref="EventModel"/> class from given parameters as string values.
        /// Possible errors during parse values into fields of <see cref="EventModel"/> will throw <see cref="Exception"/>
        /// </summary>
        /// <param name="model">EventModel class fields in order defined in <see cref="EventModel"/> class</param>
        /// <returns><see cref="EventModel"/> class</returns>
        public static EventModel CreateEventModel(string[] model)
        {
            // TODO throw reasonable exception
            if (model.Length != 6)
                throw new Exception();

            // TODO throw reasonable exception
            if (!EventTypeExtension.TryParseEventType(model[1], out var eventType))
                throw new Exception();

            // TODO throw reasonable exception
            if (!DateTime.TryParseExact(model[4],
                                        "ddd MMM dd HH:mm:ss CET yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.AllowWhiteSpaces,
                                        out var datetime)
             && !DateTime.TryParseExact(model[4],
                                        "ddd MMM dd HH:mm:ss CEST yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.AllowWhiteSpaces,
                                        out datetime))
                throw new Exception();

            return new EventModel
            {
                IsEvent = string.Compare(model[0], "1", StringComparison.Ordinal) == 0,
                EventType = (EventType)eventType,
                ID = model[2],
                Culture = model[3],
                DateTime = datetime,
                Message = model[5]
            };
        }
    }
}
