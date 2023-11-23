
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanExamples
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenmarkTest
    {
        private const string DateTime = "2019-12-13T16:33:06Z";
        private static readonly DateParser dateParser = new DateParser();

        [Benchmark(Baseline = true)]
        public void GetYearFromDateTime()
        {
            dateParser.GetYearFromDateTime(DateTime);
        }

        [Benchmark]
        public void GetYearFromSplit()
        {
            dateParser.GetYearFromSplit(DateTime);
        }

        [Benchmark]
        public void GetYearFromSubstring()
        {
            dateParser.GetYearFromSubString(DateTime);
        }

        [Benchmark]
        public void GetYearFromSpan()
        {
            dateParser.GetYearFromSpan(DateTime);
        }

        [Benchmark]
        public void GetYearFromSpan_v2()
        {
            dateParser.GetYearFromSpan_v2(DateTime);
        }

        [Benchmark]
        public void GetYearFromSpanWithManualConversion()
        {
            dateParser.GetYearFromSpanWithManualConversion(DateTime);
        }
    }
}
