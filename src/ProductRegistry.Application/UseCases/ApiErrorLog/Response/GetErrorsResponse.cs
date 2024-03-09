using ProductRegistry.Domain.Core.Messages;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Enums;
using ProductRegistry.Infrastructure.CrossCutting.Commons.Extensions;

namespace ProductRegistry.Application.UseCases.ApiErrorLog.Response
{
    public class GetErrorsResponse : ResponseBase
    {
        public ReportFormat Format { get; set; }
        public byte[] File { get; private set; }
        public List<ApiErrorLogResponse> Data { get; set; }

        public GetErrorsResponse()
        {
            File = new byte[0];
            Data = new List<ApiErrorLogResponse>();
        }

        public GetErrorsResponse FormaterReport()
        {
            switch (Format)
            {
                case ReportFormat.Json:
                    FormaterJsonReport();
                    break;
                case ReportFormat.Text:
                    FormaterTextReport();
                    break;
                case ReportFormat.Csv:
                    FormaterCsvReport();
                    break;
            }

            return this;
        }

        private void FormaterJsonReport()
        {
            using var ms = new MemoryStream();
            using TextWriter tw = new StreamWriter(ms);
            tw.WriteLine(Data.ToJson());
            tw.Flush();
            ms.Position = 0;
            File = ms.ToArray();
        }

        private void FormaterCsvReport()
        {
            using var ms = new MemoryStream();
            using TextWriter tw = new StreamWriter(ms);
            tw.WriteLine("Timestamp;RootCause;Message;ExceptionStackTrace");
            Data.ForEach(error =>
            {
                tw.WriteLine($"{error.Timestamp:dd-MM-yyyy HH:mm:ss};{error.RootCause};{error.Message};{error.ExceptionStackTrace}");
            });
            tw.Flush();
            ms.Position = 0;
            File = ms.ToArray();
        }

        private void FormaterTextReport()
        {
            using var ms = new MemoryStream();
            using TextWriter tw = new StreamWriter(ms);
            Data.ForEach(error =>
            {
                error.ExceptionStackTrace = string.IsNullOrEmpty(error.ExceptionStackTrace) ? error.ExceptionStackTrace : $"| {error.ExceptionStackTrace}";
                tw.WriteLine($"{error.Timestamp:dd-MM-yyyy HH:mm:ss} - [{error.RootCause}] - {error.Message} {error.ExceptionStackTrace}");

            });
            tw.Flush();
            ms.Position = 0;
            File = ms.ToArray();
        }

    }
}
