namespace OperatorTaxi.Models
{
    using System;
    public enum status
    {
        NOTAPPOINTED,
        APPOINTED
    }

    public class Order
    {
        private int passengersAmount;

        public Order() { }

        public Order(uint id, string Where, string Destination, int PassengersAmount, status Status, string CarNumber)
        {
            this.Id = id;
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
                if (value < 0 || value > 8)
                {
                    throw new ArgumentOutOfRangeException("Wrong amount of passengers");
                }
                else
                {
                    passengersAmount = value;
                }
            }
        }

        public uint Id { get; set; }
        public status Status { get; set; }
        public string CarNumber { get; set; }
    }
}
