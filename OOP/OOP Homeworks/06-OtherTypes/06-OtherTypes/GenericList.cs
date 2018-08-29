namespace _06_OtherTypes
{
    using System;
    using System.Linq;

    [Version(1.01)]
    public class GenericList<T>
    {
        private const int DefaultCapacity = 16;
        private int _count;

        private T[] _elements;

        public GenericList(int capacity = DefaultCapacity)
        {
            this._elements = new T[capacity];
        }

        //Gets element by id 
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this._elements.Length)
                {
                    throw new ArgumentOutOfRangeException($"Index {index} is invalid");
                }

                var result = this._elements[index];

                return result;
            }
        }

        //Adds element
        public void Add(T element)
        {
            if (this._count >= this._elements.Length)
            {
                this.Resize();
            }
            this._elements[this._count] = element;
            this._count++;
        }

        //Removes element
        public void Remove(int id)
        {
            if (id < 0 || id >= this._count)
            {
                throw new ArgumentOutOfRangeException("Not a valid index.");
            }

            var copy = this._elements.ToList();
            copy.RemoveAt(id);

            this._elements = copy.Count < DefaultCapacity ? new T[DefaultCapacity] : new T[copy.Count];

            this._count--;

            for (var i = 0; i < copy.Count; i++)
            {
                this._elements[i] = copy[i];
            }
        }

        //Insert element at given position
        public void InsertAt(int id, T element)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException($"Cant insert at position: {id}");
            }
            if (id >= this._elements.Length)
            {
                this.Resize();
            }

            this._elements[id] = element;

            this._count++;
        }

        // List size = size * 2
        private void Resize()
        {
            var copy = this._elements;

            this._elements = new T[this._elements.Length*2];

            for (var i = 0; i < copy.Length; i++)
            {
                this._elements[i] = copy[i];
            }
        }

        //Clear the list
        public void Clear()
        {
            this._elements = new T[this._elements.Length];
        }

        public int FindIndex(T element)
        {
            for (var i = 0; i < this._elements.Length; i++)
            {
                if (this._elements[i].ToString() == element.ToString())
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            return this._elements.Aggregate("", (current, element) => current + (element + "\n"));
        }

        public void GetAttribute()
        {
            var t = typeof (GenericList<>);

            var myAttribute =
                (VersionAttribute) Attribute.GetCustomAttribute(t, typeof (VersionAttribute));

            if (myAttribute == null)
            {
                Console.WriteLine("The attribute was not found.");
            }
            else
            {
                Console.WriteLine("The Version of this class is is: {0}.", myAttribute.Version);
            }
        }
    }
}