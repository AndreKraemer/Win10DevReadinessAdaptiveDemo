using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveDemo.Data
{
    public class SessionData
    {
        private static List<Session> _sessions = new List<Session>()
        {
            new Session()
            {
                Id  = 1,
                Title = "Windows 10 Überblick",
                Speaker = "Christian Nagel",
                Duration = 45
            },
            new Session()
            {
                Id  = 2,
                Title = "XAML Controls",
                Speaker = "Thomas Mutzl",
                Duration = 45
            },
            new Session()
            {
                Id  = 3,
                Title = "Adaptive UI",
                Speaker = "André Krämer",
                Duration = 45
            }
        };

        public static IList<Session> GetAll()
        {
            return _sessions;
        }

        public static Session GetById(int id)
        {
            return _sessions.SingleOrDefault(s => s.Id == id);
        }
    }
}
