using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNP2_CardGame_Ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car BMWM305 = new Car("M3'05", "BMW", 297, 3.2, 333, 5.2, 262, 60, 1549);
            Car FerrariFXXK = new Car("FXX K Evo", "Ferrari", 354, 6.3, 1050, 2.5, 950, 26, 1165);
            Car NissanGTR = new Car("GT-R", "Nissan", 315, 3.5, 565, 2.7, 470, 50, 1740);
            Car KoenigseggAgeraRS = new Car("Agera RS", "Koenigsegg", 457, 5.0, 1360, 2.6, 1160, 26, 1395);

            Hand PlayerOne = new Hand();
            Hand PlayerTwo = new Hand();

            PlayerOne.AddCard(BMWM305);
            PlayerOne.AddCard(FerrariFXXK);

            PlayerTwo.AddCard(NissanGTR);
            PlayerTwo.AddCard(KoenigseggAgeraRS);

            for(int i = 0; i <= 1; i++)
            {
                Console.WriteLine("Round " + (i + 1));
                var winner = PlayerOne.DrawCard(i).CompareCar(PlayerTwo.DrawCard(i));
                Console.WriteLine("Winner of this round is: " + winner.ToString());
            }
            
            while (true) ;
        }
    }
}
