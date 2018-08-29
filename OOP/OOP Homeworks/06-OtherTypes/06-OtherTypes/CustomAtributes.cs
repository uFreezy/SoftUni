namespace _06_OtherTypes
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface,
        AllowMultiple = true)]
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(double version)
        {
            this.Version = version;
        }

        public double Version { get; private set; }
    }
}