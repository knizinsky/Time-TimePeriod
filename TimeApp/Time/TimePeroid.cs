namespace TimeApp
{
    /// <summary>
    /// Reprezentuje okres czasu.
    /// </summary>
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private readonly long totalSeconds;

        public long TotalSeconds => totalSeconds;

        public TimePeriod(byte hours, byte minutes, byte seconds)
        {
            totalSeconds = hours * 3600 + minutes * 60 + seconds;
        }

        public TimePeriod(byte hours, byte minutes) : this(hours, minutes, 0)
        {
        }

        public TimePeriod(byte seconds) : this(0, 0, seconds)
        {
        }

        /// <summary>
        /// Inicjalizuje nową instancję struktury TimePeriod na podstawie czasu początkowego i końcowego.
        /// </summary>
        public TimePeriod(Time startTime, Time endTime)
        {
            long startSeconds = startTime.Hours * 3600 + startTime.Minutes * 60 + startTime.Seconds;
            long endSeconds = endTime.Hours * 3600 + endTime.Minutes * 60 + endTime.Seconds;
            if (endSeconds < startSeconds)
            {
                throw new ArgumentException("Końcowy przedział czasu nie może być wcześniejszy niż początkowy!");
            }
            totalSeconds = endSeconds - startSeconds;
        }

        /// <summary>
        /// Inicjalizuje nową instancję struktury TimePeriod na podstawie ciągu znaków reprezentującego okres czasu.
        /// </summary>
        public TimePeriod(string timePeriodString)
        {
            var parts = timePeriodString.Split(':');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Nieprawidłowy format!");
            }

            if (!byte.TryParse(parts[0], out var hours) || !byte.TryParse(parts[1], out var minutes) || !byte.TryParse(parts[2], out var seconds))
            {
                throw new ArgumentException("Nieprawidłowe wartości przedziałów czasowych!");
            }

            totalSeconds = hours * 3600 + minutes * 60 + seconds;
        }

        /// <summary>
        /// Zwraca tekstową reprezentację bieżącego okresu czasu.
        /// </summary>
        public override string ToString()
        {
            long remainingSeconds = totalSeconds;
            byte hours = (byte)(remainingSeconds / 3600);
            remainingSeconds %= 3600;
            byte minutes = (byte)(remainingSeconds / 60);
            byte seconds = (byte)(remainingSeconds % 60);
            return $"{hours}:{minutes:D2}:{seconds:D2}";
        }

        public static bool operator ==(TimePeriod a, TimePeriod b) => a.totalSeconds == b.totalSeconds;
        public static bool operator !=(TimePeriod a, TimePeriod b) => !(a == b);
        public static bool operator <(TimePeriod a, TimePeriod b) => a.totalSeconds < b.totalSeconds;
        public static bool operator <=(TimePeriod a, TimePeriod b) => a.totalSeconds <= b.totalSeconds;
        public static bool operator >(TimePeriod a, TimePeriod b) => a.totalSeconds > b.totalSeconds;
        public static bool operator >=(TimePeriod a, TimePeriod b) => a.totalSeconds >= b.totalSeconds;

        public bool Equals(TimePeriod other) => this == other;

        public override bool Equals(object obj) => obj is TimePeriod other && this == other;

        public override int GetHashCode() => totalSeconds.GetHashCode();

        public int CompareTo(TimePeriod other) => totalSeconds.CompareTo(other.totalSeconds);

        /// <summary>
        /// Dodaje dwa okresy czasu.
        /// </summary>
        public static TimePeriod operator +(TimePeriod a, TimePeriod b)
        {
            long totalSeconds = a.totalSeconds + b.totalSeconds;
            checked
            {
                byte hours = (byte)(totalSeconds / 3600);
                totalSeconds %= 3600;
                byte minutes = (byte)(totalSeconds / 60);
                byte seconds = (byte)(totalSeconds % 60);
                return new TimePeriod(hours, minutes, seconds);
            }
        }

        /// <summary>
        /// Odejmuje drugi okres czasu od pierwszego okresu czasu.
        /// </summary>
        public static TimePeriod operator -(TimePeriod a, TimePeriod b)
        {
            long totalSeconds = a.totalSeconds - b.totalSeconds;
            checked
            {
                byte hours = (byte)(totalSeconds / 3600);
                totalSeconds %= 3600;
                byte minutes = (byte)(totalSeconds / 60);
                byte seconds = (byte)(totalSeconds % 60);
                return new TimePeriod(hours, minutes, seconds);
            }
        }
    }
}
