using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateUserRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public bool IsValid() => Id > 0 && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email);
    }
}
