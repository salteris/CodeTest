using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Item : Entity
    { 
        public string Name { get; }
        public virtual Modifier Modifier { get; private set; }
        [JsonIgnore]
        public virtual Character Character { get; }

        protected Item()
        {

        }

        public Item(
            string name,
            AffectedObject affectedObject,
            string affectedValue,
            int value
            ) : this()
        {
            Name = name;
            Modifier = Modifier.AddModifier(affectedObject, affectedValue, value).Value;
        }

    }
}
