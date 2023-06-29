using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_dotnet_core_7_crud.DTOs.Weapon
{
    public class GetWeaponResponseDto
    {
        public string Name { get; set; } = String.Empty;
        public int Damage { get; set; }
    }
}