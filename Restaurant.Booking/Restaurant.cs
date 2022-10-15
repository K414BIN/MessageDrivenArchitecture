using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Booking
{
    public class Restaurant
    {
        private readonly List<Table> _tables = new ();   
        public Restaurant()
        { 
            for (int i=1;i<=10;i++)
            { 
                _tables.Add(new Table(i));
            }
        }

        internal void BookFreeTable(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу Вашу бронь, оставайтесь на линии..."); 
            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free);
            Thread.Sleep(1000 * 5);
            Console.WriteLine(table is null ? $"К сожалению, сейчас все столики заняты" : $"Готово! Ваш столик номер {table.Id}");
        }

        internal void BookFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу Вашу бронь, а Вам придет уведомление");
            Task.Run( async () => {
                                    var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == State.Free);
                                    await Task.Delay( 5000 );
                                    table?.SetState( State.Booked );
                                    Console.WriteLine(table is null ? $"УВЕДОМЛЕНИЕ: К сожалению, сейчас все столики заняты" : $"УВЕДОМЛЕНИЕ: Готово! Ваш столик номер {table.Id}");
            });
        }
    }
}
