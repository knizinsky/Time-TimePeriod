using TimeApp;

namespace TimeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie obiektu Time
            Time time1 = new Time(10, 30, 45);
            Console.WriteLine($"Czas 1: {time1}");

            // Tworzenie obiektu Time na podstawie ciągu znaków
            string timeString = "08:15:30";
            Time time2 = new Time(timeString);
            Console.WriteLine($"Czas 2: {time2}");

            // Porównywanie czasów
            Console.WriteLine($"Czas 1 == Czas 2: {time1 == time2}");
            Console.WriteLine($"Czas 1 > Czas 2: {time1 > time2}");

            // Dodawanie okresu czasu do czasu
            TimePeriod timePeriod = new TimePeriod(1, 30);
            Time time3 = time1 + timePeriod;
            Console.WriteLine($"Czas 3 (po dodaniu 1,5h do Czasu 1): {time3}");

            // Tworzenie obiektu TimePeriod
            TimePeriod period1 = new TimePeriod(2, 30, 0);
            Console.WriteLine($"Okres czasu 1: {period1}");

            // Tworzenie obiektu TimePeriod na podstawie ciągu znaków
            string periodString = "01:45:30";
            TimePeriod period2 = new TimePeriod(periodString);
            Console.WriteLine($"Okres czasu 2: {period2}");

            // Dodawanie i odejmowanie okresów czasu
            TimePeriod sum = period1 + period2;
            Console.WriteLine($"Suma okresów czasu: {sum}");

            TimePeriod difference = period1 - period2;
            Console.WriteLine($"Różnica okresów czasu: {difference}");
        }
    }
}
