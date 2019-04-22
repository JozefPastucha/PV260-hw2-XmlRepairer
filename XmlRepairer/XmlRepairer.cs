using System;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlRepairer
{
    public class XmlRepairer
    {
        public static string RemoveInvalidXmlChars(string text)
        {
            var validXmlChars = text.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray();
            return new string(validXmlChars);

        }
        public static string RemoveInvalidXmlChars2(string text)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (XmlConvert.IsXmlChar(text[i]))
                {
                    builder.Append(text[i]);
                }
            }

            return builder.ToString();

        }
    }
}
