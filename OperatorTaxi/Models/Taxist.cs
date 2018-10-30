using System;

namespace Models
{
    public enum Color
    {
        RED,
        BLUE,
        YELLOW,
        BLACK,
        GREEN,
        GREY,
        PINK,
        BROWN,
        ORANGE,
        WHITE
    }
    public class Taxist
    {
        public Taxist() { }

        private Color color;

        public Taxist(string model, string number, Color color, bool isBusy)
        {
            this.Model = model;
            this.Number = number;
            this.Color = color;
            this.IsBusy = isBusy;
        }

        public string Model { get; set; }
        public string Number { get; set; }
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                Color colorToParse;
                if (!Color.TryParse(value.ToString().ToUpper(), out colorToParse))
                {
                    throw new Exception("Unknown color");
                }
                color = colorToParse;
            }

        }
        public bool IsBusy { get; set; }
    }
}
