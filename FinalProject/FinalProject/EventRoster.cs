using EventData;

namespace FinalProject
{
    public static class EventRoster
    {
        static EventRoster()
        {
            allEvents = new List<Event>();
            
        }
        
        public static IList<Event> allEvents { get; set; }
    }
}
