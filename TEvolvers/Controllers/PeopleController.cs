using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEvolvers.Data;
using TEvolvers.Models;
using TEvolvers.Models.Dto;
using TEvolvers.Repository;

namespace TEvolvers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        protected ResponseDto _response;

        public PeopleController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _response = new ResponseDto();
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            try
            {
                var lista = await _personRepository.GetPeople();
                _response.Result = lista;
                _response.DisplayMessage = "People list";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }


        [HttpGet("{page}")]
        public async Task<ActionResult<Person>> GetPersonPage(int page)
        {
            int initial = 0;
            

            if (page > 1)
            {
                initial = (page * 10) - 10;
            }

            try
            {
                int registers = 0;

                var list = await _personRepository.GetPeople();

                if (page * 10 < list.Count())
                {
                    registers = 10;
                }
                else
                {
                    registers = list.Count() - ((page - 1) * 10);
                }

                _response.Result = list.GetRange(initial, registers);
                _response.DisplayMessage = "People range list";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        /*
                // GET: api/People/5
                [HttpGet("{id}")]
                public async Task<ActionResult<Person>> GetPerson(int id)
                {
                    var person = await _personRepository.GetPersonById(id);

                    if (person == null)
                    {
                        _response.IsSuccess = false;
                        _response.DisplayMessage = "Person not exist";
                        return NotFound(_response);
                    }
                    _response.Result = person;
                    _response.DisplayMessage = "Person information";
                    return Ok(_response);
                }
        */


        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, PersonDto personDto)
        {
            try
            {
                PersonDto model = await _personRepository.CreateUpdate(personDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error to person update";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(PersonDto personDto)
        {
            try
            {
                PersonDto model = await _personRepository.CreateUpdate(personDto);
                _response.Result = model;
                return CreatedAtAction("GetPerson", new { id = personDto.id }, personDto);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al grabar el registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }

        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                bool isDelete = await _personRepository.DeletePerson(id);
                if (isDelete)
                {
                    _response.Result = isDelete;
                    _response.DisplayMessage = "Delete person";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error to delete person";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
