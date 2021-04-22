using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessSchedule schedule = new BusinessSchedule();
            schedule.SetRangeOfDates(new DateTime(2020, 01, 01), new DateTime(2021, 01, 01));
            schedule.AddBusinessMeeting(new DateTime(2020, 02, 01), new TimeSpan(1, 0, 0, 0));
            schedule.AddBusinessMeeting(new DateTime(2019, 02, 01), new TimeSpan(1, 0, 0, 0));
            schedule.DisplayMeetings();
            schedule.DeleteBusinessMeeting(new DateTime(2020, 02, 01));
            schedule.DisplayMeetings();

            Console.ReadKey();
        }
    }
}
