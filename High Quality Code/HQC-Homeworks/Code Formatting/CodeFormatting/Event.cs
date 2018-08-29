namespace CodeFormatting
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;

    internal class Event : IComparable
    {
        public DateTime Date;
        public string Location;
        public string Title;

        public Event (DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public int CompareTo(object obj)
        {
            var other = obj as Event;
            var byDate = this.Date.CompareTo(other.Date);
            var byTitle = string.Compare(this.Title, other.Title, StringComparison.Ordinal);
            var byLocation = string.Compare(this.Location, other.Location, StringComparison.Ordinal);

            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                   
                return byTitle;
            }

            return byDate;
        }

        public override string ToString()
        {
            var toString = new StringBuilder();

            toString.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.Title);

            if (!string.IsNullOrEmpty(this.Location))
            {
                toString.Append(" | " + this.Location);
            }

            return toString.ToString();
        }
    }

    internal class Program
    {
        private static readonly StringBuilder Output = new StringBuilder();
        private static readonly EventHolder Events = new EventHolder();

        private static void Main()
        {
            while (ExecuteNextCommand())
            {
            }

            Console.WriteLine(Output);
        }

        private static bool ExecuteNextCommand()
        {
            var command = Console.ReadLine();

            switch (command[0])
            {
                case 'A':
                    AddEvent(command);
                    return true;
                case 'D':
                    DeleteEvents(command);
                    return true;
                case 'L':
                    ListEvents(command);
                    return true;
                case 'E':
                    return false;
            }

            return false;
        }

        private static void ListEvents(string command)
        {
            var pipeIndex = command.IndexOf('|');
            var date = GetDate(command, "ListEvents");
            var countString = command.Substring(pipeIndex + 1);
            var count = int.Parse(countString);

            Events.ListEvents(date,count);
        }

        private static void DeleteEvents(string command)
        {
            var title = command.Substring("DeleteEvents".Length + 1);

            Events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;

            GetParameters(command, "AddEvent",out date, out title, out location);
            Events.AddEvent(date, title, location);
        }

        private static void GetParameters(string commandForExecution, 
            string commandType, 
            out DateTime dateAndTime,
            out string eventTitle, 
            out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);

            var firstPipeIndex = commandForExecution.IndexOf('|');
            var lastPipeIndex = commandForExecution.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution
                    .Substring(firstPipeIndex + 1).Trim();

                eventLocation = "";
            }
            else
            {
                eventTitle = commandForExecution.Substring(
                    firstPipeIndex + 1,
                    lastPipeIndex - firstPipeIndex - 1)
                    .Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            var date = DateTime.Parse(command
                .Substring(commandType.Length + 1, 20));

            return date;
        }

        private static class Messages
        {
            public static void EventAdded()
            {
                Output.Append("Event added\n");
            }

            public static void EventDeleted(int x)
            {
                if (x == 0)
                {
                    NoEventsFound();
                }
                else
                {
                    Output.AppendFormat("{0} events deleted\n", x);
                }
            }

            public static void NoEventsFound()
            {
                Output.Append("No events found\n");
            }

            public static void PrintEvent(Event eventToPrint)
            {
                if (eventToPrint != null)
                {
                    Output.Append(eventToPrint + "\n");
                }
            }
        }

        private class EventHolder
        {
            private readonly OrderedBag<Event> _byDate = 
                new OrderedBag<Event>();
            private readonly MultiDictionary<string, Event> _byTitle = 
                new MultiDictionary<string, Event>(true);

            public void AddEvent(DateTime date, string title, string location)
            {
                var newEvent = new Event(date, title, location);

                this._byTitle.Add(title.ToLower(), newEvent);
                this._byDate.Add(newEvent);

                Messages.EventAdded();
            }

            public void DeleteEvents(string titleToDelete)
            {
                var title = titleToDelete.ToLower();
                var removed = 0;

                foreach (var eventToRemove in this._byTitle[title])
                {
                    removed++;
                    this._byDate.Remove(eventToRemove);
                }

                this._byTitle.Remove(title);
                Messages.EventDeleted(removed);
            }

            public void ListEvents(DateTime date, int count)
            {
                var eventsToShow = this._byDate
                    .RangeFrom(new Event(date, "", ""), true);
                var showed = 0;

                foreach (var eventToShow in eventsToShow)
                {
                    if (showed == count)
                    {
                        break;
                    }

                    Messages.PrintEvent(eventToShow);
                    showed++;
                }

                if (showed == 0)
                {
                    Messages.NoEventsFound();
                }
            }
        }
    }
}