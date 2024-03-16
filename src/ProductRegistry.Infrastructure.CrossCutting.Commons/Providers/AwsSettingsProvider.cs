namespace ProductRegistry.Infrastructure.CrossCutting.Commons.Providers
{
    public class AwsSettingsProvider
    {
        public string Region { get; set; } = string.Empty;
        public string AccessKeyId { get; set; } = string.Empty;
        public string SecretAccessKey { get; set; } = string.Empty;
        public SnsSettings SNS { get; set; } = new SnsSettings();

        public class SnsSettings
        {
            public string Url { get; set; } = string.Empty;
            public string Region { get; set; } = string.Empty;
            public string TopicArn { get; set; } = string.Empty;
        }
    }
}
