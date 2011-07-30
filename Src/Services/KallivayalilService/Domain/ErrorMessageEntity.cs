namespace Kallivayalil.Domain
{
    public class ErrorMessageEntity
    {
        public string Code { get; set; }
        public string ErrorPath { get; set; }
        public string Description { get; set; }

        public bool Equals(ErrorMessageEntity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Code, Code) && Equals(other.ErrorPath, ErrorPath) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof (ErrorMessageEntity))
            {
                return false;
            }
            return Equals((ErrorMessageEntity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Code != null ? Code.GetHashCode() : 0);
                result = (result*397) ^ (ErrorPath != null ? ErrorPath.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}