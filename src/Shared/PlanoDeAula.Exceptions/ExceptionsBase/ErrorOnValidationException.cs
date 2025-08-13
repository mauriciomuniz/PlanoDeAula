namespace PlanoDeAula.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : PlanoDeAulaException
    {
        public IList<String> ErrorsMessages { get; set; }
        public ErrorOnValidationException(IList<string> errorsMessages)
        {
            ErrorsMessages = errorsMessages;
        }

    }
}
