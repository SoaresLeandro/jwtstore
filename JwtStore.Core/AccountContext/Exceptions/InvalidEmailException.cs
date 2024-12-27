namespace JwtStore.Core.AccountContext.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message = "E-mail inválido") : base(message)
        {            
        }
    }
}
