using NUnit.Framework;
using System.IO;
using System.Xml;
using XmlRepairer;

namespace Tests
{
    public class Tests
    {
        private string fileContent;
        private string path;
        [SetUp]
        public void Setup()
        {
            path = "D:/3.semester/SwQuality/hw2/XmlRepairer/PV260-hw2-XmlRepairer/XmlRepairer/test.xml";
            fileContent = File.ReadAllText(path);
        }

        [Test]
        public void Test1()
        {
            XmlDocument document = new XmlDocument();
            Assert.Throws<XmlException>(() => document.Load(path));
        }

        [Test]
        public void Test2()
        {
            XmlDocument document = new XmlDocument();
            fileContent = XmlRepairer.XmlRepairer.RemoveInvalidXmlChars(fileContent);
            Assert.DoesNotThrow(() => document.LoadXml(fileContent));
        }
    }
}