using Web_API_2.Models;
using System.Collections.Generic;
using System;
using System.Linq;
namespace Web_API_2.Services
{
    public class PersonService : IPersonService
    {
        static List<PersonModel> persons { get; }
        static int nextId = 13;
        static PersonService()
        {
            persons = new List<PersonModel>
            {
                new PersonModel{Id = 1, FirstName ="hieu1" ,LastName ="hoang1" ,DateOfBirth =new DateTime(1999,2,2),Gender ="Nam",BirthPlace ="Ha Noi", },
                new PersonModel{Id = 2, FirstName ="hieu2" ,LastName ="hoang2" ,DateOfBirth =new DateTime(2000,2,2),Gender ="Nu" ,BirthPlace ="Thai Binh",},
                new PersonModel{Id = 3, FirstName ="hieu3" ,LastName ="hoang3" ,DateOfBirth =new DateTime(2001,2,2),Gender ="Nam",BirthPlace ="Bac Ninh",},
                new PersonModel{Id = 4, FirstName ="hieu4" ,LastName ="hoang4" ,DateOfBirth =new DateTime(1998,2,2),Gender ="Nam",BirthPlace ="Quang Nam",},
                new PersonModel{Id = 5, FirstName ="hieu5" ,LastName ="hoang5" ,DateOfBirth =new DateTime(2003,2,2),Gender ="Nu" ,BirthPlace ="Quang Binh",},
                new PersonModel{Id = 6, FirstName ="hieu6" ,LastName ="hoang6" ,DateOfBirth =new DateTime(2002,2,2),Gender ="Nu" ,BirthPlace ="Quang Ngai",},
                new PersonModel{Id = 7, FirstName ="hieu7" ,LastName ="hoang7" ,DateOfBirth =new DateTime(1999,2,2),Gender ="Nam",BirthPlace ="Ha Noi", },
                new PersonModel{Id = 8, FirstName ="hieu8" ,LastName ="hoang8" ,DateOfBirth =new DateTime(2000,2,2),Gender ="Nu" ,BirthPlace ="Thai Binh",},
                new PersonModel{Id = 9, FirstName ="hieu9" ,LastName ="hoang9" ,DateOfBirth =new DateTime(2001,2,2),Gender ="Nam",BirthPlace ="Bac Ninh",},
                new PersonModel{Id = 10,FirstName ="hieu10",LastName ="hoang10",DateOfBirth =new DateTime(1998,2,2),Gender ="Nam",BirthPlace ="Quang Nam",},
                new PersonModel{Id = 11,FirstName ="hieu11",LastName ="hoang11",DateOfBirth =new DateTime(2003,2,2),Gender ="Nu" ,BirthPlace ="Quang Binh",},
                new PersonModel{Id = 12,FirstName ="hieu12",LastName ="hoang12",DateOfBirth =new DateTime(2002,2,2),Gender ="Nu" ,BirthPlace ="Quang Ngai",},
            };
        }
        public List<PersonModel> GetAll() => persons;
        public PersonModel Get(int id) => persons.FirstOrDefault(p => p.Id == id);
        public void Add(PersonModel person)
        {
            person.Id = nextId++;
            persons.Add(person);
        }
        public bool Delete(int id)
        {
            var person = Get(id);
            if (person != null)
                return persons.Remove(person);
            return false;
        }
        public void Update(PersonModel person)
        {
            var index = persons.FindIndex(p => p.Id == person.Id);
            if (index == -1)
                return;
            persons[index] = person;
        }
        public List<PersonModel> Filters(FilterPersonModel model)
        {
            return persons.Where(x => (!string.IsNullOrEmpty(model.LastName) && x.LastName.ToLower() == model.LastName.ToLower()) ||
                                      (!string.IsNullOrEmpty(model.FirstName) && x.FirstName.ToLower() == model.FirstName.ToLower()) ||
                                      (!string.IsNullOrEmpty(model.BirthPlace) && x.FirstName.ToLower() == model.BirthPlace.ToLower()) ||
                                      (!string.IsNullOrEmpty(model.Gender) && x.Gender.ToLower() == model.Gender.ToLower())).ToList();
        }
    }
}