using System;
using System.Xml;

public class Component
{
    private string name;
    private string details;
    private double price;

    public Component(string name, double price, string details = null)
    {
        this.name = name;
        this.price = price;
        this.details = details;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value.Trim() == "")
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            this.name = value;
        }
    }

    public double Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
            this.price = value;
        }
    }

    public string Details
    {
        get { return this.details; }
        set
        {
            if (value.Trim() == "")
            {
                throw new ArgumentException("Details cannot be empty.");
            }
            this.details = value;
        }
    }

    public override string ToString()
    {
        string output = String.Format("    Component name: {0}\n", this.name);

        if (this.details != null)
        {
            output += String.Format("      Details about the component: {0}\n", this.details);
        }

        output += String.Format("      Component price: {0}\n", this.price);
        return output;
    }
}
