using CodeTest.Domain;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CodeTest.Controllers
{
    public class AddClassInputDTO
    {
        public long CharacterId { get; set; }
        public string Name { get; set; }
        public int ClassLevel { get; set; }
    }
}
