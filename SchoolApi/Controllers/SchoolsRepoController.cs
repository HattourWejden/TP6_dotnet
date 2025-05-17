using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.DTOs;
using SchoolApi.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsRepoController : ControllerBase
    {
        private readonly IUniversityRepository _repository;
        private readonly IMapper _mapper;

        public SchoolsRepoController(IUniversityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpGet("list_schools")]
        public ActionResult<IEnumerable<SchoolDto>> ListSchools()
        {
            var schools = _repository.GetSchools();
            return Ok(schools.Select(school => _mapper.Map<SchoolDto>(school)));
        }


        [HttpPost("add-new-school")]
        public async Task<ActionResult<School>> AddSchool(SchoolDto newschool)
        {
            var school = _mapper.Map<School>(newschool);
            _repository.AddSchool(school);


            return Ok();
        }
        // GET: api/Schools
        [HttpGet("get-all-schools")]
        public ActionResult<IEnumerable<School>> GetSchools()
        {
            return Ok(_repository.GetSchools());
        }

        // GET: api/Schools/5
        [HttpGet("get-school-by-id/{id}")]
        public ActionResult<School> GetSchool(int id)
        {
            var school = _repository.GetSchoolById(id);
            if (school == null)
            {
                return NotFound();
            }

            return Ok(school); ;
        }

        // PUT: api/Schools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit-school/{id}")]
        public IActionResult PutSchool(int id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }
            if (!SchoolExists(id))
            {
                return NotFound();
            }

            _repository.UpdateSchool(school);

            return NoContent();
        }

        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create-school")]
        public ActionResult<School> PostSchool(School school)
        {
            _repository.AddSchool(school);

            return CreatedAtAction("GetSchool", new { id = school.Id }, school);
        }

        // DELETE: api/Schools/5
        [HttpDelete("delete-school/{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            _repository.DeleteSchool(id);
            return NoContent();
        }

        private bool SchoolExists(int id)
        {
            return _repository.GetSchoolById(id) != null;
        }


        [HttpGet("get-school-by-name/{name}")]
        public ActionResult<IEnumerable<School>> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Le paramètre 'name' est requis.");
            }

            var schools = _repository.SearchSchoolsByName(name);


            return Ok(schools);
        }


    }
}
