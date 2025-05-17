using SchoolApi.Models;


namespace SchoolApi.Repositories
{
    public interface IUniversityRepository
    {
        IEnumerable<School> GetSchools();
        School GetSchoolById(int id);
        void AddSchool(School school);
        void UpdateSchool(School school);
        void DeleteSchool(int id);
        IEnumerable<School> SearchSchoolsByName(string name);

    }
}
