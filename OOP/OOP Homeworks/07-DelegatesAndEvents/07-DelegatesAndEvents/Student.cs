namespace _07_DelegatesAndEvents
{
    using System;

    public class Student
    {
        private ushort _age;
        private bool _ageSet;

        private string _name;
        private bool _nameSet;

        public Student(string name, ushort age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (this._nameSet)
                {
                    this.OnPropertiesChanged("Name", this._name, value);
                }

                this._name = value;
                this._nameSet = true;
            }
        }

        public ushort Age
        {
            get { return this._age; }
            set
            {
                if (this._ageSet)
                {
                    this.OnPropertiesChanged("Age", this._age, value);
                }

                this._age = value;
                this._ageSet = true;
            }
        }

        public event EventHandler PropertiesChanged;

        protected virtual void OnPropertiesChanged<T>(string propName, T oldValue, T newValue)
        {
            Console.WriteLine("Property changed: {0} (from {1} to {2}). ", propName, oldValue, newValue);
        }
    }
}