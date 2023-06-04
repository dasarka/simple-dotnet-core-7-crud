namespace simple_dotnet_core_7_crud.Dtos.Character
{
    public class AddCharacterRequestDto
    {
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public string? Description { get; set; }
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}