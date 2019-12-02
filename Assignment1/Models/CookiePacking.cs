namespace Assignment1.Models
{
    public class CookiePacking : BaseEntity
    {
        public string Name
        {
            get;
            set;
        }
        public bool IsFillingDone
        {
            get;
            set;
        }
        public bool IsCoolingDone
        {
            get;
            set;
        }
        public bool IsFreezingDone
        {
            get;
            set;
        }
        public bool IsPacked
        {
            get;
            set;
        }
        public virtual CookieBaking CookieBaking
        {
            get;
            set;
        }
    }
}
