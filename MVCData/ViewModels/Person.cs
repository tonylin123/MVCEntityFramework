using MVCData.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCData.ViewModels
{
    public class Person
    {

        public Person() 
        {

        }

        

        public Person(string name, string phone, City city, List<Language> languages)
        {

            Name = name;
            Phone = phone;
            City = city;
            Languages = languages;

        }

        [Key]
       
        public int ID { get; set; }
        public string Name { get; set; } 

        public string Phone { get; set; }

        public City City { get; set; } = new City();
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
