namespace Kallivayalil.Domain.inteernal
{
    public class ConstituentInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool BornInto { get; set; }
        private string parentName;
        public string Parents
        {
            get { return string.IsNullOrEmpty(parentName)? "Unknown" : parentName; }
            set { parentName = value; }
        }
    }
}