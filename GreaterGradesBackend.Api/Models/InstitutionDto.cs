using System.Collections.Generic;

namespace GreaterGradesBackend.Api.Models
{
    public class InstituitonDto
    {
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public ICollection<UserDto> Users { get; set; }
        public ICollection<ClassDto> Classes { get; set; }
    }
}
