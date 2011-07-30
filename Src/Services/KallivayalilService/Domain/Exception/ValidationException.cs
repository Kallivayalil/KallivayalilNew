namespace Kallivayalil.Domain.Exception
{
    public class ValidationException : System.Exception
    {
        public ErrorMessagesEntity ErrorMessages { get; set; }

        public ValidationException()
        {
            ErrorMessages = new ErrorMessagesEntity();
        }

        public ValidationException(ErrorMessageEntity messageEntity)
        {
            ErrorMessages = new ErrorMessagesEntity {messageEntity};
        }

        public ValidationException(ErrorMessagesEntity messagesEntity)
        {
            ErrorMessages = messagesEntity;
        }
    }
}