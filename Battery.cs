namespace MobilePhone
{
    using System;

    public class Battery
    {
        //defaults
        private const string DefaultModel = "Unknown";
        private const uint DefaultHoursIdle = 200;
        private const uint DefaultHoursTalk = 100;
        private const Type DefaultBatteryType = Type.AlienTech;

        //fields
        private string model;
        private uint hoursidle;
        private uint hourstalk;
        private Type batteryType;

        //enum
        public enum Type
        {
            LiIon,
            NiMH,
            NiCD,
            LiPo,
            AlienTech
        }

        //constructor
        public Battery() : this(DefaultModel, DefaultHoursIdle, DefaultHoursTalk, DefaultBatteryType)
        {

        }

        public Battery(string model, uint hoursidle, uint hourstalk, Type batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursidle;
            this.HoursTalk = hourstalk;
            this.BatteryType = batteryType;
        }

        //properties
        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Battery Model must be above 0 characters");
                }
                this.model = value;
            }
        }

        public uint HoursIdle
        {
            get
            {
                return hoursidle;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Battery Hours Idle must be above 0 hours");
                }

                this.hoursidle = value;
            }
        }

        public uint HoursTalk
        {
            get
            {
                return hourstalk;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Battery Hours Talk must be above 0 hours");
                }

                this.hourstalk = value;
            }
        }

        public Type BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                this.batteryType = value;
            }
        }
    }
}