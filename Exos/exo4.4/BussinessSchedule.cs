using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo4._4
{
    class BusinessSchedule
    {
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }
        private SortedDictionary<DateTime, DateTime> _schedule;

        public BusinessSchedule()
        {
            _schedule = new SortedDictionary<DateTime, DateTime>();
            startDate = new DateTime(2020, 01, 01);
            endDate = new DateTime(2030, 12, 31);
        }

        public bool IsEmpty()
        {
            return _schedule.Count == 0 ? true : false;
        }
        public void SetRangeOfDates(DateTime begin, DateTime end)
        {
            if (!IsEmpty())
                throw new AggregateException("L'emploi de temps n'est pas vide");
            if (DateTime.Compare(begin, end) > 0)
                throw new AggregateException("La période invalide");
            else
            {
                startDate = begin;
                endDate = end;
            }
        }
        public void AddBusinessMeeting(DateTime date, TimeSpan duration)
        {
            if (IsInPeriod(date) && IsInPeriod(date + duration))
            {
                KeyValuePair<DateTime, DateTime> closest = ClosestElements(date);
                if (closest.Key < date && closest.Value > date + duration)
                {
                    _schedule.Add(date, date + duration);
                }
                else
                   
                throw new ArgumentException("La date est en dehors de schedule");
            }
            else
                throw new ArgumentException("La date est en dehors de schedule");
        }
        public bool DeleteBusinessMeeting(DateTime date)
        {
            if (_schedule.ContainsKey(date))
            {
                _schedule.Remove(date);
                return true;
            }
            else
                return false;
        }

        public KeyValuePair<DateTime, DateTime> ClosestElements(DateTime beginMeeting)
        {
            if (IsEmpty())
            {
                return new KeyValuePair<DateTime, DateTime>(DateTime.MinValue, DateTime.MaxValue);
            }
            if (IsInPeriod(beginMeeting))
            {
                KeyValuePair<DateTime, DateTime> first = _schedule.Last(s => DateTime.Compare(beginMeeting, s.Key) >= 0);
                KeyValuePair<DateTime, DateTime> last = _schedule.First(s => DateTime.Compare(beginMeeting, s.Key) <= 0);
                return new KeyValuePair<DateTime, DateTime>(first.Value, last.Key);
            }
            else
                throw new ArgumentException("La date n'est pas valide");
        }

        public int ClearMeetingPeriod(DateTime begin, DateTime end)
        {
            int count = 0;
            KeyValuePair<DateTime, DateTime> firstClosest = ClosestElements(begin);
            KeyValuePair<DateTime, DateTime> lastClosest = ClosestElements(end);
            foreach (var s in _schedule)
            {
                if ((s.Value >= firstClosest.Key) || (s.Key <= lastClosest.Value))
                {
                    _schedule.Remove(s.Key);
                    count++;
                }
            }
            return count;

        }

        private bool IsInPeriod(DateTime date)
        {
            if (DateTime.Compare(startDate, date) < 0 && DateTime.Compare(endDate, date) > 0)
                return true;
            return false;
        }
        public void DisplayMeetings()
        {
            int i = 0;
            Console.WriteLine($"Emploi du temps : {startDate} - {endDate}");
            Console.WriteLine($"------------------------------------------------------------");
            if (_schedule.Count == 0)
                Console.WriteLine($"Pas de réunions programmées");
            else
            {
                foreach (var s in _schedule)
                {
                    i++;
                    Console.WriteLine($"Réunion {i} : {s.Key} - {s.Value}");
                }
            }
            Console.WriteLine($"------------------------------------------------------------");

        }

    }
}
