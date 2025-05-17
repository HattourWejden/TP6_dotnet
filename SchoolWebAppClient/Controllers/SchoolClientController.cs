using Microsoft.AspNetCore.Mvc;
using SchoolWebAppClient.Models;

namespace SchoolWebAppClient.Controllers
{
    public class SchoolClientController : Controller
    {
        private readonly HttpClient _client;

        public SchoolClientController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7123/"); // Remplace avec l’URL de ton API
        }
        public async Task<IActionResult> GetAllSchools()
        {
            HttpResponseMessage response = await _client.GetAsync("api/Schools/get-all-schools");

            if (response.IsSuccessStatusCode)
            {
                var schools = await response.Content.ReadFromJsonAsync<IEnumerable<SchoolClient>>();
                return View(schools);
            }

            return View(new List<SchoolClient>()); // ou afficher un message d'erreur
        }
        public async Task<IActionResult> GetSchoolById(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/Schools/get-school-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var school = await response.Content.ReadFromJsonAsync<SchoolClient>();
                return View("Details", school); // utiliser la vue "Details"
            }

            return NotFound(); // ou View("Error")
        }
        public async Task<IActionResult> GetSchoolByName(string name)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/Schools/get-school-by-name/{name}");

            if (response.IsSuccessStatusCode)
            {
                var schools = await response.Content.ReadFromJsonAsync<IEnumerable<SchoolClient>>();
                return View("List", schools); // utiliser la vue "List"
            }

            return View("List", new List<SchoolClient>()); // vide si non trouvé
        }
        [HttpGet]
        public IActionResult CreateSchool()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchool(SchoolClient school)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/schools/create-school", school);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(GetAllSchools));
            }

            return View(school); // Repasser les données en cas d’erreur
        }
        [HttpGet]
        public async Task<IActionResult> EditSchool(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/schools/get-school-by-id/{id}");
            if (response.IsSuccessStatusCode)
            {
                var school = await response.Content.ReadFromJsonAsync<SchoolClient>();
                return View(school);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditSchool(SchoolClient school)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync("api/schools/edit-school/" + school.Id, school);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(GetAllSchools));
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/schools/get-school-by-id/{id}");

            if (response.IsSuccessStatusCode)
            {
                var school = await response.Content.ReadFromJsonAsync<SchoolClient>();

                if (school != null)
                {
                    return View(school);
                }
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSchool(SchoolClient school)
        {
            HttpResponseMessage response = await _client.DeleteAsync("api/schools/delete_school/" + school.Id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(GetAllSchools));

            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
