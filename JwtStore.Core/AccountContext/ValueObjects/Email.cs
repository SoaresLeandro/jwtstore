using JwtStore.Core.SharedContext.Exceptions;
using JwtStore.Core.SharedContext.Extensions;
using JwtStore.Core.SharedContext.ValueObjects;
using System.Text.RegularExpressions;

namespace JwtStore.Core.AccountContext.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$";
        public string Address { get; }
        public string Hash => Address.ToBase64();

        public Email(string address)
        {
            if(string.IsNullOrEmpty(address))
                throw new InvalidEmailException("E-mail inválido");

            Address = address.Trim().ToLower();

            if(Address.Length < 5)
                throw new InvalidEmailException("E-mail inválido");

            if(!EmailRegex().IsMatch(Address))
                throw new InvalidEmailException("E-mail inválido");
        }

        public static implicit operator string(Email email) => email.ToString();

        public static implicit operator Email(string address) => new(address);

        public override string ToString() => Address.Trim().ToLower();

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}
