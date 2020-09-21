using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNP2_CardGame_Ass1
{
    class Hand
    {
        private List<Car> Cars { get; set; }

        public Hand()
        {
            this.Cars = new List<Car>();
        }

        public Car DrawCard(int position)
        {
            return Cars.ElementAt(position);
        }

        public void AddCard(Car car)
        {
            Cars.Add(car);
        }
    }
}
