using AEDCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AEDCore
{
    public class EventsParser
    {
        public IList<EventModel> ParseFromCSV(string filename)
        {
            try
            {
                return File.ReadAllLines(filename)
                    .Select(line => EventModelFactory.CreateEventModel(line.Split(";").ToArray()))
                    .ToList();
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ParseIntoCSV(string filename, IList<EventModel> events)
        {
            try
            {
                using (var writer = new StreamWriter(filename))
                {
                    foreach (var e in events)
                    {
                        var parts = new string[]
                        {
                            e.IsEvent ? "1" : "0",
                            EventTypeExtension.ToString(e.EventType),
                            e.ID,
                            e.Culture,
                            e.DateTime.ToString(),
                            e.Message
                        };

                        writer.WriteLine(string.Join(';', parts));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
