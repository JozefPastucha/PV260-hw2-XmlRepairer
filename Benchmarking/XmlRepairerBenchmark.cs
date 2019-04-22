using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Benchmarking
{
    public class XMLRepairerBenchmark
    {
        public string fileContent { get; set; }
        public string path { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            path = "D:/3.semester/SwQuality/hw2/XmlRepairer/PV260-hw2-XmlRepairer/XmlRepairer/test.xml";
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
