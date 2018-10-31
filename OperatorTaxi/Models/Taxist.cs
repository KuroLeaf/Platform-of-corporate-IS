using System;

namespace Models
{
    public class Taxist
    {
        public Taxist() { }


        public Taxist(string model, string number, bool isBusy)
        {
            this.Model = model;
            this.Number = number;
            this.IsBusy = isBusy;
        }

        public string Model { get; set; }
        public string Number { get; set; }
        public bool IsBusy { get; set; }
    }
}
