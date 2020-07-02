using CodeTest.Domain;

namespace CodeTest.Controllers
{
    public class AddDefenseInputDTO
    {
        public string Type { get; set; }
        public string Protection { get; set; }
        public long CharacterId { get; set; }
    }
}