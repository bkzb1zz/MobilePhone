namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        //static field for iPhone4S
        private static readonly GSM iPhone4S = new GSM("4S", "Apple", 800.00m, "Me",
            new Battery("Apple", 8, 120, Battery.Type.LiPo),
            new Display(4.5m, 16000000));

        //defaults
        private const decimal defaultPrice = 1800;
        private const string defaultOwner = "Gosho";
        private const decimal callPricePerSecond = 0.37m;

        //fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> CallHistory;

        //constructor
        public GSM(string model, string manufacturer) : this(model, manufacturer, defaultPrice, defaultOwner, new Battery(), new Display())
        {

        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.CallHistory = new List<Call>();

        }

        //properties
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("GSM Model must be above 0 characters");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("GSM Manufacturer must be above 0 characters");
                }

                this.manufacturer = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("GSM Price must be above 0 $");
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("GSM Owner must be above 0 characters");
                }
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value; // ArgumentException is added in Battery.cs
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value; //ArgumentException is added in Display.cs
            }
        }

        //iPhone 4S property
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        //.ToString() override
        public override string ToString()
        {
            StringBuilder stringCreator = new StringBuilder();
            stringCreator.Append("GSM Specifications:");
            stringCreator.Append(" ");
            stringCreator.AppendLine(new string('#', 90));
            stringCreator.AppendFormat("GSM Model - {0}", this.model);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Manufacturer - {0}", this.manufacturer);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Price - {0}", this.price);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Owner - {0}", this.owner);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Battery Specifications : Model - {1} , Type - {0} , Talk time - {2} , Idle time - {3}"
                          , this.Battery.BatteryType, this.Battery.Model, this.Battery.HoursTalk, this.Battery.HoursIdle);
            stringCreator.AppendLine();
            stringCreator.AppendFormat("GSM Display Specifications : Display Size - {0} , Number of Colors - {1}",
                            this.Display.Size, this.Display.Colors);
            stringCreator.AppendLine();
            stringCreator.AppendLine(new string('#', 110));

            return stringCreator.ToString();
        }

        //adding a call method
        public void AddCall(string currPhoneNumber,ulong currDuration)
        {
            this.CallHistory.Add(new Call(currPhoneNumber, currDuration));
        }

        //removing a call
        public void DeleteCall(int position)
        {
            if ((this.CallHistory.Count <= position - 1) || (position - 1 < 0))
            {
                throw new ArgumentException("GSM Call History does not exist");
            }
            this.CallHistory.RemoveAt(position - 1);
        }

        //show call history
        public void ShowCallHistory()
        {
            Console.WriteLine("Current call history: ");
            int index = 1;
            foreach (var call in this.CallHistory)
            {
                Console.Write(index++);
                Console.Write(" -> ");
                Console.WriteLine(call.ToString());
            }
        }

        //clear call history
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        //call price sum
        public decimal TotalCallPrice()
        {
            ulong allDuration = 0;
            foreach (var call in this.CallHistory)
            {
                allDuration += call.Duration;
            }
            return allDuration * callPricePerSecond;
        }
    }
}
