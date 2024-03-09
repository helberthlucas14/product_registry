namespace ProductRegistry.Domain.Validations.Resources
{
    public static class ValidationMessages
    {
        private static readonly Dictionary<string, string> Messages = new()
        {
            {"OwnerId", "PR-001"},
            {"CategoryNotFound", "PR-002"}
        };

        public static string GetMessage(string key)
            => Messages.FirstOrDefault(x => x.Key.Equals(key)).Value ?? key;
    }
}
