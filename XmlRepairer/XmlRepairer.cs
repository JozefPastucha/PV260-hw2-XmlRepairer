using System.Linq;
using System.Text;
using System.Xml;

namespace XmlRepairer
{
    public static class XmlRepairer
    {
        public static string RemoveInvalidXmlCharsLinq(string text)
        {
            var validXmlChars = text.Where(XmlConvert.IsXmlChar).ToArray();
            return new string(validXmlChars);
        }

        public static string RemoveInvalidXmlCharsFor(string text)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < text.Length; i++)
            {
                if (XmlConvert.IsXmlChar(text[i]))
                {
                    builder.Append(text[i]);
                }
            }

            return builder.ToString();
        }

        public static string RemoveInvalidXmlCharsForEach(string text)
        {
            var builder = new StringBuilder();
            foreach (var c in text)
            {
                if (XmlConvert.IsXmlChar(c))
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }

        public static string RemoveInvalidXmlCharsForAdvanced(string text)
        {
            var builder = new StringBuilder();
            var index = 0;
            for (var i = 0; i < text.Length; i++)
            {
                if (XmlConvert.IsXmlChar(text[i])) continue;
                builder.Append(text.Substring(index, i - index));
                index = i + 1;
            }

            builder.Append(text.Substring(index, text.Length - index));


            return builder.ToString();
        }
    }
}