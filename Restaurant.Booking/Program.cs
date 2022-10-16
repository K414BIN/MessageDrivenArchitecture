using System.Diagnostics;

namespace Restaurant.Booking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            var rest = new Restaurant();
            int choice = 20 * 1000;
          do
            {
                rest.BookRemovalTableAsync(20000);
                Console.WriteLine("Привет! Желаете забронировать столик?");
                Console.WriteLine("0 - Я здесь закончил и ухожу");
                Console.WriteLine("1 - Мы уведомим Вас по СМС (асинхронно)");
                Console.WriteLine("2 - Подождите на линии, мы Вас оповестим (синхронно)");
                Console.WriteLine("3 - Я передумал - снимите бронь");

                if (int.TryParse(Console.ReadLine(), out choice) )
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();         
                    
                    switch (choice)
                    {
                        case 1:           rest.BookFreeTableAsync(1);
                             break;
                        case 2:           rest.BookFreeTable(1);
                             break;           
                        case 3:
                                           Console.Write("Введите номер Вашего столика: ");
                                           rest.BookRemovalTable(Convert.ToInt32(System.Console.ReadLine()));
                                break;
                       default:           choice = 0; 
                             break;
                    }
                    
                    Console.WriteLine("Спасибо за Ваше обращение!");
                    stopWatch.Stop();
                    var ts = stopWatch.Elapsed;
                    Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}");
                }
                else choice = 0;

             } while (choice != 0);

            Console.ReadLine();
        }
        
    }
}