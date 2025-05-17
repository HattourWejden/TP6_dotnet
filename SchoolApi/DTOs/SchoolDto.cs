using System.ComponentModel.DataAnnotations;

namespace SchoolApi.DTOs
{
    public class SchoolDto
    {
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        [Range(0, 5)]
        public double Rating { get; set; }
    }
}
