using System.Security.Cryptography.X509Certificates;

namespace _03_CompanyHierarchy
{
    public interface IPerson
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}