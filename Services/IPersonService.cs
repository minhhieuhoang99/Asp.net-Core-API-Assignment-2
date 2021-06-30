using System.Collections.Generic;
using System.Text;
using Web_API_2.Services;
using Web_API_2.Models;
namespace Web_API_2.Services
{
    public interface IPersonService 
    {
        List<PersonModel> GetAll();
        PersonModel Get(int id);
        void Add(PersonModel person);
        bool Delete(int id);
        void Update(PersonModel person);
        // List<PersonModel> FilterByGender(string gender);
        // List<PersonModel> FilterByBirthPlace(string birthPlace);
        // List<PersonModel> FilterByName(string name);
        List<PersonModel> Filters(FilterPersonModel model);
    }
}