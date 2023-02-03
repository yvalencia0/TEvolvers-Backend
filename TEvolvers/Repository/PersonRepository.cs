using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TEvolvers.Data;
using TEvolvers.Models;
using TEvolvers.Models.Dto;

namespace TEvolvers.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public PersonRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<PersonDto> CreateUpdate(PersonDto personDto)
        {
            Person person = _mapper.Map<PersonDto, Person>(personDto);
            if (person.id > 0)
            {
                _db.People.Update(person);
            }
            else
            {
                await _db.People.AddAsync(person);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Person, PersonDto>(person);
        }

        public async Task<bool> DeletePerson(int id)
        {
            try
            {
                Person person = await _db.People.FindAsync(id);
                if (person == null)
                {
                    return false;
                }
                _db.People.Remove(person);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<PersonDto>> GetPeople()
        {
            List<Person> lista = await _db.People.ToListAsync();

            return _mapper.Map<List<PersonDto>>(lista);
        }

        public async Task<List<PersonDto>> GetPeoplePage(int page)
        {
            List<Person> lista = await _db.People.ToListAsync();

            return _mapper.Map<List<PersonDto>>(lista);
        }
        /*
                public async Task<PersonDto> GetPersonById(int id)
                {
                    Person person = await _db.People.FindAsync(id);

                    return _mapper.Map<PersonDto>(person);
                }
        */
    }
}
