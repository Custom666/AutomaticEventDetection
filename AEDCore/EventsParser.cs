using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AEDCore
{
    public class EventsParser
    {
        public IList<EventModel> ParseCSV(string filename)
        {
            try
            {
                return File.ReadAllLines(filename).Select(line => EventModelFactory.CreateEventModel(line.Split(";"))).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return null;
            }
        }
    }
}
