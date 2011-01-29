namespace Website.Models
{
    public class ConstituentName :Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PreferedName { get; set; }
        public virtual int Salutation { get; set; }
    }
}