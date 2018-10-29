using System;

namespace OperatorTaxi
{
    public enum status
    {
        NotAppointed,
        Appointed
    }

    public class Order
    {
        private int passengersAmount;

        public Order() { }

        public Order(string Where, string Destination, int PassengersAmount, status Status, string CarNumber)
        {
            this.Where = Where;
            this.Destination = Destination;
            this.PassengersAmount = PassengersAmount;
            this.Status = Status;
            this.CarNumber = CarNumber;
        }

        public string Where { get; set; }
        public string Destination { get; set; }
        public int PassengersAmount
        {
            get
            {
                return passengersAmount;
            }
            set
            {
                if (passengersAmount < 0 && passengersAmount > 7)
                {
                    throw new Exception("Too many passengers");
                }
                else
                {
                    passengersAmount = value;
                }
            }
        }
        public status Status { get; set; }
        public string CarNumber { get; set; }
    }
}
