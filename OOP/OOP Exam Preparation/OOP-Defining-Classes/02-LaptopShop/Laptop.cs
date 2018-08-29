using System;

public class Laptop
{
    private string model;
    private double price;
    private string processor;
    private Battery battery;
    private string manufactuer;
    private string RAM;
    private string gCard;
    private string hdd;
    private string screen;
   
    

    public Laptop(string model, double price,string processor = null, string batteryName = null, double batteryLife = 0,
                  string manufactuer = null, string ram = null, string gCard = null, string hdd = null, string screen = null)
    {
        this.model = model;
        this.manufactuer = manufactuer;
        this.processor = processor;
        this.RAM = ram;
        this.gCard = gCard;
        this.hdd = hdd;
        this.screen = screen;
        this.battery = new Battery(batteryName,batteryLife);
        this.price = price;
    }

    public string Model
    {
        get { return this.Model; }
        set
        {
            if (value == "")
            {
                throw new ArgumentException("Model cannot be empty");
            }
            this.model = value;
        }
    }

    public double Price
    {
        get { return this.price; }
        set
        {
            if (value.ToString() == "" || value < 0)
            {
                throw new ArgumentException("Price must be a positive number.");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        string result = String.Format(" Model: {0} \n Price: {1} \n ", this.model , this.price);

        if (this.manufactuer != null)
        {
            result += String.Format("Manufactuer: {0} \n ",this.manufactuer);
        }

        if (this.processor != null)
        {
            result += String.Format("Processor: {0} \n ",this.processor);
        }

        if (this.battery.BatteryName != null && this.battery.BatteryLife != 0)
        {
            result += String.Format("Battery name: {0} \n Battery life: {1} \n ",
                                    this.battery.BatteryName,this.battery.BatteryLife);
        }

        if (this.RAM != null)
        {
            result += String.Format("RAM: {0} \n ",this.RAM);
        }

        if (this.gCard != null)
        {
            result += String.Format("Graphics card: {0} \n ",this.gCard);
        }

        if (this.hdd != null)
        {
            result += String.Format("HDD: {0} \n ", this.hdd);
        }

        if (this.screen != null)
        {
            result += String.Format("Screen: {0} \n ",this.screen);
        }

        return result;
    }

}