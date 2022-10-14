using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Booking
{
    public class Table
    {
        private readonly Random random = new Random();
        public int Id { get;  } 
        public State State { get; private set; }    
        public int SeatsCount { get;}    

    public Table(int id)
    {         
        Id = id;
        State = State.Free;
        SeatsCount = random.Next(2,5);
    }

    public bool SetState(State state)
    { 
        if (State == state) return false;
        State = state;
        return true;
    }

    }
}
