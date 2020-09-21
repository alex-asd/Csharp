using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNP2_CardGame_Ass1
{
    class Car
    {
        private string Model { get; set; }
        private string Make { get; set; }
        private int MaxSpeed { get; set; }
        private double EngineSize { get; set; }
        private int HorsePower { get; set; }
        private double Launch { get; set; }
        // Time to reach max speed
        private double Time { get; set; }
        private double Torque { get; set; }
        private int Weight { get; set; }

        public Car(string model, string make, int maxSpeed, double engineSize, int horsePower, double launch, double torque, double time, int weight)
        {
            this.Make = make;
            this.Model = model;
            this.MaxSpeed = maxSpeed;
            this.EngineSize = engineSize;
            this.HorsePower = horsePower;
            this.Launch = launch;
            this.Time = time;
            this.Torque = torque;
            this.Weight = weight;
        }

        public Car CompareCar(Car other)
        {
            if (this.GetCarScore() > other.GetCarScore())
                return this;
            else
                return other;
        }
        
        private double GetCarScore()
        {
            var speedMS = MaxSpeed / 3.6;
            // acceleration = Speed in M/S / Time
            // force
            var power = (Weight * (speedMS / Time)) * (speedMS / 2);
            var carScore = power / 746;

            Console.WriteLine(String.Format("{0} {1}, HP = {2} and estimated car score: {3}",
                Make, Model, HorsePower, carScore));
            return carScore;
        }
        override
        public string ToString()
        {
            return String.Format("{0} {1}, with max speed: {2}KM/H, HP: {3}, Torque: {4}n-m, weight: {5}Kg\n",
                Make, Model, MaxSpeed, HorsePower, Torque, Weight);
        }
    }
}
