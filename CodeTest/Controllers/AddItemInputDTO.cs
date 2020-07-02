using CodeTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Controllers
{
    public class AddItemInputDTO
    {
        public long CharacterId { get; set; }
        public string ItemName { get; set; }
        public AffectedObject AffectedObject { get; set; }
        public string AffectedValue { get; set; }
        public int Value { get; set; }
    }
}
