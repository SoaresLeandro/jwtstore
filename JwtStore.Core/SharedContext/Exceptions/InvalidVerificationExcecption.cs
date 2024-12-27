namespace JwtStore.Core.SharedContext.Exceptions
{
    public class InvalidVerificationExcecption : Exception
    {
        public InvalidVerificationExcecption(string message = "Verificação inválida") : base(message) { }
    }
}