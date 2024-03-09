namespace ProductRegistry.Infrastructure.CrossCutting.Commons.Providers
{
    public class AwsSettingsProvider
    {
        public SnsSettings SNS { get; set; } = new SnsSettings();

        public class SnsSettings
        {
            public string Region { get; set; } = string.Empty;
            public string TopicArn { get; set; } = string.Empty;
        }
    }
}
