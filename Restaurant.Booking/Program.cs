using System.Diagnostics;

namespace Restaurant.Booking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            var rest = new Restaurant();
            while (true)
            {
                Console.WriteLine("Привет! Желаете забронировать столик?\n1 - мы уведомим Вас по СМС (асинхронно)");
                Console.WriteLine("2 - подождите на линии, мы Вас оповести (синхронно)");
                if (!int.TryParse(Console.ReadLine(), out var choice) && choice is not (1 or 2))
                { 
                    Console.WriteLine("Введите, пожалуйста 1 или 2");
                    continue;
                }
            
            var stopWatch = new Stopwatch();
            stopWatch.Start();
                if (1 == choice)
                {
                    rest.BookFreeTableAsync(1);
                }
                else
                { 
                    rest.BookFreeTable(1);
                }
                Console.WriteLine("Спасибо за Ваше обращение!");
                stopWatch.Stop();
                var ts = stopWatch.Elapsed;
                Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}"  );
        }   }
    }
}