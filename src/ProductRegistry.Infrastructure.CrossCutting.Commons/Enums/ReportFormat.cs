using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Infrastructure.CrossCutting.Commons.Enums
{
    public enum ReportFormat
    {
        [Description("application/json")]
        Json,
        [Description("text/plain")]
        Text,
        [Description("text/csv")]
        Csv
    }
}
