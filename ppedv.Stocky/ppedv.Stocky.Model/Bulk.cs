using System.Collections.Generic;

namespace ppedv.Stocky.Model
{
    public class Bulk : Entity
    {
        public string Type { get; set; }
        public string Densitiy { get; set; }
        public virtual ICollection<Storage> Storage { get; set; } = new HashSet<Storage>();
    }
}
