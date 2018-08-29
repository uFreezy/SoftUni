using System;

public class Battery
{
    private string batteryName;
    private double batteryLife;

    public Battery(string battery, double batteryLife)
    {
        this.batteryName = battery;
        this.batteryLife = batteryLife;
    }

    public string BatteryName
    {
        get { return this.batteryName; }
        set
        {
            bool IsDigitsOnly = true;

            foreach (char c in value)
            {
            if (c < '0' || c > '9')
                IsDigitsOnly = false;
            }
          
            if (value == "" || IsDigitsOnly)
            {
                throw new ArgumentException("Battery name cannot contain only digits or be empty.");
            }
            this.BatteryName = value;
        }
    }

    public double BatteryLife
    {
        get { return this.batteryLife; }
        set
        {
            if (value.ToString() == "" || value < 0)
            {
                throw new ArgumentException("Battery life cannot be empty or negative.");
            }
            this.batteryLife = value;
        }
    }
}