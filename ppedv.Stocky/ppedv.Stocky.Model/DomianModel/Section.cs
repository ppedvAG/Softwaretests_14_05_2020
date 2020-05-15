using System.Collections.Generic;

namespace ppedv.Stocky.Model
{
    public class Section : Entity
    {
        public string Nummer { get; set; }
        public string Position { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual ICollection<Storage> Storages { get; set; } = new HashSet<Storage>();
    }
}
