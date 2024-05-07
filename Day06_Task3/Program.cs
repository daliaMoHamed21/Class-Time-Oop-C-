namespace Day06_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Time time1 = new Time { Houres = 5, Minutes = 25, Seconds = 55 };
            Time time2 = new Time { Houres = 6, Minutes = 16, Seconds = 26 };

            // Add two times
            Time times = Time.addTime(time1, time2);
            Console.WriteLine("Addition Result: ");
            times.printTime();

            // Reset time
            times.resetTime();
            Console.WriteLine("\n Reset Time: ");
            times.printTime();

            // Add 30 minutes
            times.addMinutes();
            Console.WriteLine("\n Add 30 Minutes: ");
            times.printTime();

            // Convert to total seconds
            int totalSeconds = times.ToTotalSeconds();
            Console.WriteLine($"\n Total Seconds: {totalSeconds} ");
        }
    }

    class Time
    {
        private int houres;
        private int minutes;
        private int seconds;

        //Properties for all the attributes OR Properties
        public int Houres { get { return houres; } set { houres = value; } }
        public int Minutes { get { return minutes; } set { minutes = value; } } 
        public int Seconds { get { return seconds; } set { seconds = value; } }

        //Adding two times together and returning a new time object correctly 
        public static Time addTime(Time T1,Time T2)
        {
            Time times = new Time();
            times.Houres = T1.Houres + T2.Houres;
            times.Minutes = T1.Minutes + T2.Minutes;    
            times.Seconds = T1.Seconds + T2.Seconds;

            // Adjust Time
            times.Houres += times.Minutes / 60;
            times.Minutes += times.Seconds / 60;
            times.Seconds %= 60;
            times.Minutes %= 60;

            return times;

        }

        //Resetting a time object by making the hours, minutes and seconds equal 0

        public void resetTime()
        {
            houres = 0;
            minutes = 0;
            seconds = 0;
        }

        //Adding a time by 30 minutes and adjusting the hours subsequently
        public void addMinutes()
        {
            minutes += 30;
            houres += minutes / 60;
            minutes %= 60;
        }

        //Printing the values of a certain time object.
        public void printTime()
        {
            Console.WriteLine($"Time : {Houres:D2}:{Minutes:D2}:{Seconds:D2} ");
        }

        //Convert a given time to a total number of seconds.
        public int ToTotalSeconds()
        {
            return houres * 3600 + minutes * 60 + seconds;
        }

    }
}