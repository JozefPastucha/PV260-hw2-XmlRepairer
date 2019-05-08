using System.IO;
using System.Xml;
using NUnit.Framework;

namespace XmlRepairerTests
{
    public class Tests
    {
        private readonly string _fullInvalidString1 = "";
        private readonly string _fullInvalidString1Result = "";

        private readonly string _invalidString2 = "testtesttesttest";
        private readonly string _invalidString2Result = "testtesttesttest";

        private readonly string _validString3 = "valid string";
        private string _fileContent;
        private string _path;

        [SetUp]
        public void Setup()
        {
            _path = "../../../../XmlRepairer/test.xml";
            _fileContent = File.ReadAllText(_path);
        }

        [Test]
        public void TestIfXmlFileIsInvalid()
        {
            var document = new XmlDocument();
            Assert.Throws<XmlException>(() => document.Load(_path));
        }

        [Test]
        public void ValidXmlAfterRepair_Linq()
        {
            var document = new XmlDocument();
            _fileContent = XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsLinq(_fileContent);
            Assert.DoesNotThrow(() => document.LoadXml(_fileContent));
        }

        [Test]
        public void ValidXmlAfterRepair_ForAdvanced()
        {
            var document = new XmlDocument();
            _fileContent = XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForAdvanced(_fileContent);
            Assert.DoesNotThrow(() => document.LoadXml(_fileContent));
        }

        [Test]
        public void ValidXmlAfterRepair_For()
        {
            var document = new XmlDocument();
            _fileContent = XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsFor(_fileContent);
            Assert.DoesNotThrow(() => document.LoadXml(_fileContent));
        }

        [Test]
        public void ValidXmlAfterRepair_ForEach()
        {
            var document = new XmlDocument();
            _fileContent = XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForEach(_fileContent);
            Assert.DoesNotThrow(() => document.LoadXml(_fileContent));
        }

        [Test]
        public void ValidXmlAfterRepair_ForAdvanced_FullInvalidString1()
        {
            _fileContent =
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForAdvanced(_fullInvalidString1);
            Assert.AreEqual(_fileContent, _fullInvalidString1Result);
        }

        [Test]
        public void ValidXmlAfterRepair_ForAdvanced_ValidString3()
        {
            _fileContent =
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForAdvanced(_validString3);
            Assert.AreEqual(_fileContent, _validString3);
        }

        [Test]
        public void ValidXmlAfterRepair_ForAdvanced_InvalidString2()
        {
            _fileContent =
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForAdvanced(_invalidString2);
            Assert.AreEqual(_fileContent, _invalidString2Result);
        }
    }
}