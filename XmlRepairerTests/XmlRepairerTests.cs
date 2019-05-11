using System.IO;
using System.Xml;
using NUnit.Framework;

namespace XmlRepairerTests
{
    public class Tests
    {
        private string _allCharsInvalid;
        private readonly string _allCharsInvalidResult = "";

        private string _someCharsInvalid;
        private readonly string _someCharsInvalidResult = "testtesttesttest";

        private readonly string _validString3 = "valid string";
        private string _fileContent;
        private string _path;

        [SetUp]
        public void Setup()
        {
            _path = "../../../../XmlRepairer/test.xml";
            _fileContent = File.ReadAllText(_path);
            _allCharsInvalid = File.ReadAllText("../../../allCharsInvalid.txt");
            _someCharsInvalid = File.ReadAllText("../../../someCharsInvalid.txt");

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
        public void ValidXmlAfterRepair_ForAdvanced_allCharsInvalid()
        {
            _fileContent =
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForAdvanced(_allCharsInvalid);
            Assert.AreEqual(_fileContent, _allCharsInvalidResult);
        }

        [Test]
        public void ValidXmlAfterRepair_ForAdvanced_ValidString3()
        {
            _fileContent =
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForAdvanced(_validString3);
            Assert.AreEqual(_fileContent, _validString3);
        }

        [Test]
        public void ValidXmlAfterRepair_ForAdvanced_someCharsInvalid()
        {
            _fileContent =
                XmlRepairer.XmlRepairer.RemoveInvalidXmlCharsForAdvanced(_someCharsInvalid);
            Assert.AreEqual(_fileContent, _someCharsInvalidResult);
        }
    }
}