namespace MobilePhone
{
    using System;

    public class Display
    {
        //defaults
        private const decimal DefaultSize = 5;
        private const uint DefaultColors = 16000000;

        //fields
        private decimal size;
        private uint colors;

        //constructor
        public Display() : this(DefaultSize,DefaultColors)
        {

        }

        public Display(decimal size, uint colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        //properties
        public decimal Size
        {
            get
            {
                return size;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Display size must be above 0 inch");
                }
                this.size = value;
            }
        }

        public uint Colors
        {
            get
            {
                return colors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Display colors must be above 0");
                }
                this.colors = value;
            }
        }
    }
}