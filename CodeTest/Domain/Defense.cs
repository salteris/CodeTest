using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Defense : Entity
    {
        public string Type { get; }
        public ProtectionType Protection { get; }
        [JsonIgnore]
        public virtual Character Character { get; set; }

        protected Defense()
        {

        }

        public Defense(
            string type,
            ProtectionType protection
            ): this()
        {
            Type = type;
            Protection = protection;
        }
    }

    public enum ProtectionType
    {
        Immune = 0,
        Resistant = 1
    }
}
