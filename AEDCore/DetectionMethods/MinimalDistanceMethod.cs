using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AEDCore.Interfaces;

namespace AEDCore.DetectionMethods
{
    public class MinimalDistanceMethod : IDetectionMethod
    {
        private List<EtalonModel> _etalons;

        public MinimalDistanceMethod()
        {
            _etalons = new List<EtalonModel>
            {
                new EtalonModel { EventType = EventType.Agriculture },
                new EtalonModel { EventType = EventType.Crimes },
                new EtalonModel { EventType = EventType.Culture },
                new EtalonModel { EventType = EventType.Industry },
                new EtalonModel { EventType = EventType.None },
                new EtalonModel { EventType = EventType.Other },
                new EtalonModel { EventType = EventType.Politics },
                new EtalonModel { EventType = EventType.Sport },
                new EtalonModel { EventType = EventType.Weather },
            };
        }

        public void Learn(IList<EventModel> models)
        {
            foreach (var eventModel in models)
            {
                switch (eventModel.EventType)
                {
                    case EventType.Agriculture:

                        _etalons.First(e => e.EventType.Equals(EventType.Agriculture)).Symptoms.Add(eventModel.Symptom);

                        break;
                    case EventType.Crimes:

                        _etalons.First(e => e.EventType.Equals(EventType.Crimes)).Symptoms.Add(eventModel.Symptom);

                        break;
                    case EventType.Culture:

                        _etalons.First(e => e.EventType.Equals(EventType.Culture)).Symptoms.Add(eventModel.Symptom);

                        break;
                    case EventType.Industry:

                        _etalons.First(e => e.EventType.Equals(EventType.Industry)).Symptoms.Add(eventModel.Symptom);

                        break;
                    case EventType.None:

                        _etalons.First(e => e.EventType.Equals(EventType.None)).Symptoms.Add(eventModel.Symptom);

                        break;
                    case EventType.Other:

                        _etalons.First(e => e.EventType.Equals(EventType.Other)).Symptoms.Add(eventModel.Symptom);

                        break;
                    case EventType.Politics:

                        _etalons.First(e => e.EventType.Equals(EventType.Politics)).Symptoms.Add(eventModel.Symptom);

                        break;
                    case EventType.Sport:

                        _etalons.First(e => e.EventType.Equals(EventType.Sport)).Symptoms.Add(eventModel.Symptom);

                        break;
                    case EventType.Weather:

                        _etalons.First(e => e.EventType.Equals(EventType.Weather)).Symptoms.Add(eventModel.Symptom);

                        break;
                }
            }
        }

        public IList<EventModel> Detect(IList<int[]> symtoms)
        {
            return null;
        }

        private class EtalonModel
        {
            public EventType EventType;

            public readonly List<int[]> Symptoms;

            public EtalonModel()
            {
                Symptoms = new List<int[]>();
            }

            public int[] GetEtalon()
            {
                var etalon = new int[Symptoms[0].Length];

                foreach (var symptom in Symptoms)
                    for (var index = 0; index < symptom.Length; index++)
                        etalon[index] += symptom[index] / Symptoms.Count;

                return etalon;
            }
        }
    }
}
