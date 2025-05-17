using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.DTOs;
using SchoolApi.Models;



namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public SchoolsController(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("get-all-schoolsDTO")]
        public async Task<ActionResult<IEnumerable<SchoolDto>>> GetSchoolsDTO()
        {
            List<SchoolDto> listDto = new List<SchoolDto>();

            var t = await _context.Schools.ToListAsync();
            foreach (var item in t)
            {
                SchoolDto schoolDto = new SchoolDto();
                schoolDto.Name = item.Name;
                schoolDto.City = item.City;
                schoolDto.Rating = item.Rating;
                listDto.Add(schoolDto);
            }
            return listDto;
        }


        [HttpGet("list_schools")]
        public ActionResult<IEnumerable<SchoolDto>> ListSchools()
        {

            return Ok(_context.Schools.Select(school => _mapper.Map<SchoolDto>(school)));
        }


        [HttpPost("add-new-school")]
        public async Task<ActionResult<School>> AddSchool(SchoolDto newschool)
        {
            var school = _mapper.Map<School>(newschool);
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return Ok();
        }
        // GET: api/Schools
        [HttpGet("get-all-schools")]
        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            return await _context.Schools.ToListAsync();
        }

        // GET: api/Schools/5
        [HttpGet("get-school-by-id/{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return school;
        }

        // PUT: api/Schools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit-school/{id}")]
        public async Task<IActionResult> PutSchool(int id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }
            if (!SchoolExists(id))
            {
                return NotFound();
            }

            _context.Schools.Update(school);


            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create-school")]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchool", new { id = school.Id }, school);
        }

        // DELETE: api/Schools/5
        [HttpDelete("delete-school/{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolExists(int id)
        {
            return _context.Schools.Any(e => e.Id == id);
        }


        [HttpGet("get-school-by-name/{name}")]
        public async Task<ActionResult<IEnumerable<School>>> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Le paramètre 'name' est requis.");
            }

            var schools = await _context.Schools
                .Where(s => EF.Functions.Like(s.Name, $"%{name}%"))
                .ToListAsync();

            return Ok(schools);
        }


    }
}