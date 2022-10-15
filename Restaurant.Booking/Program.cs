using System.Diagnostics;

namespace Restaurant.Booking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            var rest = new Restaurant();
            int choice= 3;
          do
            { 
                Console.WriteLine("Привет! Желаете забронировать столик?\n1 - мы уведомим Вас по СМС (асинхронно)");
                Console.WriteLine("2 - подождите на линии, мы Вас оповести (синхронно)");
                Console.WriteLine("3 - Я здесь закончил и ухожу");

                if (int.TryParse(Console.ReadLine(), out choice) )
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();         
                    
                    switch (choice)
                    {
                        case 1:           rest.BookFreeTableAsync(1);
                            break;
                        case 2:           rest.BookFreeTable(1);
                             break ;           
                            default:      choice = 3; 
                                break;
                    }
                    
                    Console.WriteLine("Спасибо за Ваше обращение!");
                    stopWatch.Stop();
                    var ts = stopWatch.Elapsed;
                    Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}");
                }
                else choice = 3;

             } while (choice != 3);
        
        }  
    }
}