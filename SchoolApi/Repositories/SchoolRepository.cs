using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;


namespace SchoolApi.Repositories
{
    public class SchoolRepository : IUniversityRepository
    {
        private readonly SchoolDbContext _context;
        public SchoolRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public void AddSchool(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
        }

        public void DeleteSchool(int id)
        {
            var school = _context.Schools.Find(id);
            if (school != null)
            {
                _context.Schools.Remove(school);
                _context.SaveChanges();
            }
        }

        public School GetSchoolById(int id)
        {
            return _context.Schools.Find(id);

        }

        public IEnumerable<School> GetSchools()
        {
            return _context.Schools.ToList();
        }

        public IEnumerable<School> SearchSchoolsByName(string name)
        {
            return _context.Schools
          .Where(s => EF.Functions.Like(s.Name, $"%{name}%"))
          .ToList();
        }

        public void UpdateSchool(School school)
        {
            var existingSchool = _context.Schools.Find(school.Id);
            if (existingSchool == null) throw new Exception("School not found");

            _context.Entry(existingSchool).CurrentValues.SetValues(school);
            _context.SaveChanges();
        }

    }
}