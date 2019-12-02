namespace Assignment1.Models
{
    public class CookieBaking : BaseEntity
    {
        public string Name
        {
            get;
            set;
        }
        public bool IsMixed
        {
            get;
            set;
        }
        public bool IsLaminated
        {
            get;
            set;
        }
        public bool IsFormmingDone
        {
            get;
            set;
        }
        public bool IsBaked
        {
            get;
            set;
        }
        public virtual Order Order
        {
            get;
            set;
        }
    }
}
