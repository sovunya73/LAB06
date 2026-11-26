using System;

namespace LAB06
{
    public class CustomTime
    {
        private const int MinutesPerDay = 1440;

        private int hour;
        private int minute;
        private int second;

        public int Hour
        {
            get { return hour; }
            set
            {
                if (value < 0 || value > 23)
                    throw new ArgumentOutOfRangeException(nameof(Hour), "Часы должны быть от 0 до 23");
                hour = value;
            }
        }

        public int Minute
        {
            get { return minute; }
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentOutOfRangeException(nameof(Minute), "Минуты должны быть от 0 до 59");
                minute = value;
            }
        }

        public int Second
        {
            get { return second; }
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentOutOfRangeException(nameof(Second), "Секунды должны быть от 0 до 59");
                second = value;
            }
        }

        public CustomTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public CustomTime(int hour) : this(hour, 0, 0)
        {
        }

        private int ToTotalMinutes()
        {
            return Hour * 60 + Minute;
        }

        private static CustomTime FromTotalMinutes(int totalMinutes, int second)
        {
            int normalized = (totalMinutes % MinutesPerDay + MinutesPerDay) % MinutesPerDay;

            return new CustomTime(normalized / 60, normalized % 60, second);
        }

        public static CustomTime operator +(CustomTime time, int minutes)
        {
            int total = time.ToTotalMinutes() + minutes % MinutesPerDay;
            return FromTotalMinutes(total, time.Second);
        }

        public static CustomTime operator -(CustomTime time, int minutes)
        {
            int total = time.ToTotalMinutes() - minutes % MinutesPerDay;
            return FromTotalMinutes(total, time.Second);
        }

        public static int operator -(CustomTime first, CustomTime second)
        {
            return Math.Abs(first.ToTotalMinutes() - second.ToTotalMinutes());
        }

        public override string ToString()
        {
            return $"[ {Hour:D2} : {Minute:D2} : {Second:D2} ]";
        }
    }
}
