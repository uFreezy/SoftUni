using System;

public class Computer
{
    private string name;
    private Component[] components;
    private double price;

    public Computer(string name, Component[] components, double price)
    {
        this.name = name;
        this.components = components;
        this.price = price;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value.Trim() == "" || value == null)
            {
                throw new ArgumentException("Name cannot be null.");
            }
            this.name = value;
        }
    }

    public Component[] Components
    {
        get { return this.components; }
        set { this.components = value; }
    }

    public double Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be a negative number.");
            }
        }
    }

    public override string ToString()
    {
        string output = String.Format("Name: {0}\n", this.name);

        foreach (Component comp in components)
        {
            output += comp;
        }

        output += String.Format("Price: {0}", this.price);

        return output;
    }
}