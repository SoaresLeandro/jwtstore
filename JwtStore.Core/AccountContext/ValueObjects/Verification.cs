using JwtStore.Core.SharedContext.Exceptions;
using JwtStore.Core.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.ValueObjects
{
    public class Verification : ValueObject
    {
        public string Code { get; } = Guid.NewGuid().ToString("N")[0..6].ToUpper();
        public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
        public DateTime? VerifiedAt { get; private set; } = null;
        public bool IsActive => VerifiedAt is not null && ExpiresAt is null;

        public void Verify(string code)
        {
            if(IsActive)
                throw new InvalidVerificationExcecption("Este código já foi ativado");

            if(ExpiresAt < DateTime.UtcNow)
                throw new InvalidVerificationExcecption("Este código expirou");

            if(!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new InvalidVerificationExcecption("Código de verificação inválido");

            ExpiresAt = null;
            VerifiedAt = DateTime.UtcNow;
        }
    }
}
