namespace ppedv.Stocky.Model
{
    public class Storage : Entity
    {
        public virtual Section Section { get; set; }
        public virtual Bulk Bulk { get; set; }
        public int Menge { get; set; }

    }
}
