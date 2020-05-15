using System.Collections.Generic;

namespace ppedv.Stocky.Model
{
    public class Stock : Entity
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }

        public virtual ICollection<Section> Sections { get; set; } = new HashSet<Section>();
    }
}
