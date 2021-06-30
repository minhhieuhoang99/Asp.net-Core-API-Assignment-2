using System;
namespace Web_API_2.Models
{
    public class PersonModel
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string Gender { set; get; }
        public string BirthPlace { set; get; }
    }
}