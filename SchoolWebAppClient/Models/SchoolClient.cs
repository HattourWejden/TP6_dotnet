namespace SchoolWebAppClient.Models
{
    
        public class SchoolClient
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Sections { get; set; }
            public string Director { get; set; }

            // Suppression de la validation
            public float Rating { get; set; }

            public string? Website { get; set; }
        }
    }
