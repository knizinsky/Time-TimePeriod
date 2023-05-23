namespace TimeApp
{
    /// <summary>
    /// Reprezentuje pewien punkt w czasie.
    /// </summary>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        public byte Hours { get; }
        public byte Minutes { get; }
        public byte Seconds { get; }

        /// <summary>
        /// Inicjalizuje nową instancję struktury Time.
        /// </summary>
        public Time(byte hours, byte minutes = 0, byte seconds = 0)
        {
            if (hours > 23 || minutes > 59 || seconds > 59)
            {
                throw new ArgumentException("Nieprawidłowa wartość czasu!");
            }

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        /// <summary>
        /// Inicjalizuje nową instancję struktury Time na podstawie ciągu znaków reprezentującego czas.
        /// </summary>
        public Time(string timeString)
        {
            var parts = timeString.Split(':');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Nieprawidłowy format czasu!");
            }

            if (!byte.TryParse(parts[0], out var hours) || !byte.TryParse(parts[1], out var minutes) || !byte.TryParse(parts[2], out var seconds))
            {
                throw new ArgumentException("Nieprawidłowa wartość czasu!");
            }

            if (hours > 23 || minutes > 59 || seconds > 59)
            {
                throw new ArgumentException("Nieprawidłowa wartość czasu!");
            }

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        /// <summary>
        /// Zwraca tekstową reprezentację bieżącego czasu.
        /// </summary>
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";

        public static bool operator ==(Time a, Time b) => a.Hours == b.Hours && a.Minutes == b.Minutes && a.Seconds == b.Seconds;
        public static bool operator !=(Time a, Time b) => !(a == b);
        public static bool operator <(Time a, Time b) => a.Hours < b.Hours || a.Hours == b.Hours && a.Minutes < b.Minutes || a.Hours == b.Hours && a.Minutes == b.Minutes && a.Seconds < b.Seconds;
        public static bool operator <=(Time a, Time b) => a == b || a < b;
        public static bool operator >(Time a, Time b) => !(a <= b);
        public static bool operator >=(Time a, Time b) => !(a < b);

        public bool Equals(Time other) => this == other;

        public override bool Equals(object obj) => obj is Time other && this == other;

        public override int GetHashCode() => HashCode.Combine(Hours, Minutes, Seconds);

        /// <summary>
        /// Porównuje bieżący czas do innego czasu i zwraca wartość wskazującą ich wzajemne położenie.
        /// </summary>
        public int CompareTo(Time other)
        {
            if (this == other)
                return 0;
            if (this < other)
                return -1;
            return 1;
        }

        /// <summary>
        /// Dodaje do bieżącego czasu określony przedział czasowy.
        /// </summary>
        public static Time operator +(Time time, TimePeriod timePeriod)
        {
            long totalSeconds = time.Hours * 3600 + time.Minutes * 60 + time.Seconds + timePeriod.TotalSeconds;
            totalSeconds %= 86400; // arytmetyka modulo 24
            byte hours = (byte)(totalSeconds / 3600);
            byte minutes = (byte)(totalSeconds / 60 % 60); // arytmetyka modulo 60
            byte seconds = (byte)(totalSeconds % 60); // arytmetyka modulo 60
            return new Time(hours, minutes, seconds);
        }
    }
}
