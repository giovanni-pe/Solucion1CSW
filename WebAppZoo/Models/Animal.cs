namespace WebAppZoo.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public required string Nombre { get; set; }
        public required string Especie { get; set; }
        public int Edad { get; set; }
        public required string Genero { get; set; }
        public DateTime FechaLlegada { get; set; }
        public string? Habitat { get; set; }
    }
}