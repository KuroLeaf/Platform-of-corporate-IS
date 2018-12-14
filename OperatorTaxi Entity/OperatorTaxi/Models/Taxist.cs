namespace OperatorTaxi.Models
{
    using System;
    public class Taxist
    {
        public Taxist() { }

        public Taxist(uint id, string model, string number, bool isBusy)
        {
            this.Id = id;
            this.Model = model;
            this.Number = number;
            this.IsBusy = isBusy;
        }

        public uint Id { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public bool IsBusy { get; set; }
    }
}
