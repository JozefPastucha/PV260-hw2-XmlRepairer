using System.IO;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class XmlRepairerBenchmark
    {
        private const int IterationCount = 100;
        private string _fileContent;
        private string _path;

        [GlobalSetup]
        public void Setup()
        {
            _path = "../../../../../../../../XmlRepairer/test.xml";
            _fileContent = File.ReadAllText(_path);
        }

        [Benchmark]
        public void RemoveInvalidXmlCharsBenchmarkLinq()
        {
            for (var i = 0; i < IterationCount; i++)
            {
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsLinq(_fileContent);
            }
        }

        [Benchmark]
        public void RemoveInvalidXmlCharsBenchmarkForEach()
        {
            for (var i = 0; i < IterationCount; i++)
            {
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForEach(_fileContent);
            }
        }

        [Benchmark]
        public void RemoveInvalidXmlCharsBenchmarkFor()
        {
            for (var i = 0; i < IterationCount; i++)
            {
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsFor(_fileContent);
            }
        }


        [Benchmark]
        public void RemoveInvalidXmlCharsBenchmarkForEachAdvanced()
        {
            for (var i = 0; i < IterationCount; i++)
            {
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForAdvanced(_fileContent);
            }
        }
    }
}