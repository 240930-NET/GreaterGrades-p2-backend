using GreaterGradesBackend.Domain.Enums;

namespace GreaterGradesBackend.Api.Models
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public Role Role { get; set; }
        public int InstitutionId { get; set; }
    }
}
