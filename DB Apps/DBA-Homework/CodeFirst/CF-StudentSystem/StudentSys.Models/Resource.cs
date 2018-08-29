using System.Collections.Generic;

namespace StudentSys.Models
{
    public class Resource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Url { get; set; }

        public virtual ICollection<License> Licenses { get; set; }

        //Resources: id, name, type of resource (video / presentation / document / other), URL 
    }
}