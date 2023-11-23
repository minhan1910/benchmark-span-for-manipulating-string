using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanExamples
{
    public class DateParser
    {
        public int GetYearFromDateTime(string dateTimeAsString)
        {
            var dateTime = DateTime.Parse(dateTimeAsString);
            return dateTime.Year;
        }

        public int GetYearFromSplit(string dateTimeAsString)
        {
            var splitOnHyphen = dateTimeAsString.Split('-');
            return int.Parse(splitOnHyphen[0]);
        }

        public int GetYearFromSubString(string dateTimeAsString)
        {
            var indexOfHyphen = dateTimeAsString.IndexOf("-");
            return int.Parse(dateTimeAsString.Substring(0, indexOfHyphen));
        }

        public int GetYearFromSpan(string dateTimeAsString)
        {
            //Span<char> span = stackalloc char[dateTimeAsString.Length];
            //dateTimeAsString.AsSpan().CopyTo(span);
            ReadOnlySpan<char> span = dateTimeAsString.AsSpan();
            var indexOfHypen = span.IndexOf('-');
            return int.Parse(span.Slice(0, indexOfHypen));
        }

        public int GetYearFromSpan_v2(ReadOnlySpan<char> dateTimeAsSpan)
        {                        
            var indexOfHypen = dateTimeAsSpan.IndexOf('-');
            return int.Parse(dateTimeAsSpan.Slice(0, indexOfHypen));
        }

        public int GetYearFromSpanWithManualConversion(ReadOnlySpan<char> dateTimeAsSpan)
        {
            var indexOfHypen = dateTimeAsSpan.IndexOf('-');
            var yearSpan = dateTimeAsSpan.Slice(0, indexOfHypen);
            int res = 0;
            for (int i = 0; i < yearSpan.Length; ++i) 
                res = res * 10 + (yearSpan[i] - '0');
            return res;
        }

        // To run benchmark
        // dotnet build -c Release
        // dotnet "paste link from bin released"
    }
}
