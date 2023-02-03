using TEvolvers.Models.Dto;

namespace TEvolvers.Repository
{
    public interface IPersonRepository
    {
        Task<List<PersonDto>> GetPeople();
        Task<List<PersonDto>> GetPeoplePage(int page);

        //Task<PersonDto> GetPersonById(int id);
        Task<PersonDto> CreateUpdate(PersonDto personDto);
        Task<bool> DeletePerson(int id);
    }
}
