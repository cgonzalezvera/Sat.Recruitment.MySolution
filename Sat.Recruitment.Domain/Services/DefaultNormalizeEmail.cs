using System;
using Sat.Recruitment.Domain.Services.Contracts;

namespace Sat.Recruitment.Domain.Services
{
    public sealed class DefaultNormalizeEmail:IEmailNormalize
    {
        private const string TokenDot = ".";
        private const string TokenPlus = "+";
        private const char TokenAt = '@';
        public string Normalize(string email)
        {
            var aux = email.Split(new char[] {TokenAt}, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf(TokenPlus, StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(TokenDot, string.Empty) : aux[0].Replace(TokenDot, string.Empty).Remove(atIndex);

            return string.Join(TokenAt.ToString(), aux[0], aux[1]);
        }
    }
}