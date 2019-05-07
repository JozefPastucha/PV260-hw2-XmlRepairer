using System.IO;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class XMLRepairerBenchmark
    {
        public string fileContent { get; set; }
        public string path { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            path = "../../../../../../../../XmlRepairer/test.xml";
            fileContent = File.ReadAllText(path);
        }

        [Benchmark]
        public void RemoveInvalidXmlCharsBenchmark()
        {
            XmlRepairer.XmlRepairer.RemoveInvalidXmlChars(fileContent);
            //XmlRepairer.XmlRepairer.RemoveInvalidXmlChars2(fileContent);
            //XmlRepairer.XmlRepairer.RemoveInvalidXmlChars3(fileContent);
        }
    }
}