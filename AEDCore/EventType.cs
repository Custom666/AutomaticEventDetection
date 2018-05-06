using System;

namespace AEDCore
{
    /// <summary>
    /// Type of event
    /// </summary>
    public enum EventType
    {
        None,
        Politics,
        Industry,
        Agriculture,
        Sport,
        Culture,
        Crimes,
        Weather,
        Other
    }

    public static class EventTypeExtension
    {
        public static bool TryParseEventType(string value, out object result)
        {
            result = null;

            switch (value)
            {
                case "-":

                    result = EventType.None;

                    break;
                case "po":

                    result = EventType.Politics;

                    break;
                case "pr":

                    result = EventType.Industry;

                    break;
                case "ze":

                    result = EventType.Agriculture;

                    break;
                case "sp":

                    result = EventType.Sport;

                    break;
                case "ku":

                    result = EventType.Culture;

                    break;
                case "kr":

                    result = EventType.Crimes;

                    break;
                case "pc":

                    result = EventType.Weather;

                    break;
                case "ji":

                    result = EventType.Other;

                    break;

                default:

                    return false;
            }

            return result != null;
        }

        public static string ToString(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.None: return "-";

                case EventType.Politics: return "po";

                case EventType.Industry: return "pr";

                case EventType.Agriculture: return "ze";
                    
                case EventType.Sport: return "sp";
                    
                case EventType.Culture: return "ku";
                    
                case EventType.Crimes: return "kr";
                    
                case EventType.Weather: return "pc";
                
                case EventType.Other: return "ji";

                default:  return string.Empty;
            }
        }
    }
}