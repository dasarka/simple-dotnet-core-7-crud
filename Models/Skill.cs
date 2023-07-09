using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_dotnet_core_7_crud.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        public List<Character>? Characters { get; set; }
    }
}