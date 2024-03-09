using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Domain.Validations.Resources
{
    public static class ValidationMessages
    {
        private static readonly Dictionary<string, string> Messages = new()
        {
            {"IdentifierDocument", "ONB-001"},
            {"Name", "ONB-002"},
            {"PhoneNumber", "ONB-003"},
            {"BirthDate", "ONB-004"},
            {"Email", "ONB-005"},
            {"ZipCode", "ONB-006"},
            {"Step", "ONB-007"},
            {"State", "ONB-008"},
            {"City", "ONB-009"},
            {"District", "ONB-010"},
            {"Street", "ONB-011"},
            {"Number", "ONB-012"},
            {"Complement", "ONB-013"},
            {"CompanyName", "ONB-014"},
            {"TradingName", "ONB-015"},
            {"InvalidCode", "ONB-016"},
            {"OnboardIncomplete", "ONB-017"},
            {"OnboardEvaluated", "ONB-018"},
            {"OnboardNotFound", "ONB-019"},
            {"DocumentFound", "DOC-001"},
            {"ClientNotFound", "CLI-001"},
            {"ClientFoundDocument", "CLI-002"}
        };

        public static string GetMessage(string key)
            => Messages.FirstOrDefault(x => x.Key.Equals(key)).Value ?? key;
    }
}
