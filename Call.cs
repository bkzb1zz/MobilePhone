namespace MobilePhone
{
    using System;
    using System.Text;

    public class Call
    {
        //fields
        private DateTime dateTime;
        private string phoneNumber;
        private ulong duration;

        //constructor
        public Call(string phoneNumber,ulong duration)
        {
            this.DateTime = DateTime.Now;
            this.PhoneNumber = phoneNumber;
            this.Duration = duration;
        }

        //properties
        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }
            set
            {
                this.dateTime = DateTime.Now;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phone number must be above 0 numbers");
                }
                if ((value.Length != 10 && value.Length != 13) || (value[0] != '0' && value[0] != '+'))
                {
                    throw new ArgumentException("Phone number must be in format +359********* or 0*********");
                }
                this.phoneNumber = value;
            }
        }

        public ulong Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Duration must not be a negative number");
                }
                this.duration = value;
            }
        }

        //.ToString() override
        public override string ToString()
        {
            StringBuilder stringCreator = new StringBuilder();
            stringCreator.AppendFormat("{0} : Duration - {1} , made on {2}", this.phoneNumber, this.duration, this.dateTime);
            stringCreator.AppendLine();
            return stringCreator.ToString();
        }
    }
}
