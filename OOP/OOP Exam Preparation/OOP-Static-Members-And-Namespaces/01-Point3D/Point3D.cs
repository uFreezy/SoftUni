using System;

public class Point3D
{
    private int x;
    private int y;
    private int z;
    static readonly Point3D startingPoint = new Point3D(0, 0, 0);

    public Point3D(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public int X
    {
        get { return this.x; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("X cannot be negative.");
            }
            this.x = value;
        }
    }

    public int Y
    {
        get { return this.y; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Y cannot be negative.");
            }
            this.y = value;
        }
    }

    public int Z
    {
        get { return this.z; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Z cannot be negative.");
            }
            this.z = value;
        }
    }

    public static Point3D StartingPoint
    {
        get { return startingPoint; }
    }

    public override string ToString()
    {
        return String.Format("Starting point:\nX: {0}\nY: {1}\nZ: {2}", this.x, this.y, this.z);
    }
}