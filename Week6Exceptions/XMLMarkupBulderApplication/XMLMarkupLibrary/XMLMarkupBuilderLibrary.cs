using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLMarkupLibrary
{
    public class XMLMarkupBuilder
    {
        private Stack<string> tagHolder = new Stack<string>();
        private StringBuilder xmlBuilder = new StringBuilder();

        public XMLMarkupBuilder()
        {
            //tagHolder.Clear();
            //xmlBuilder.Clear();
        }


        public XMLMarkupBuilder openTag(string tagName)
        {
            string openHelper = "<" + tagName + ">";
            string closeHelper = "</" + tagName + ">";

            xmlBuilder.Append(openHelper);
            tagHolder.Push(closeHelper);

            return this;
        }



        public XMLMarkupBuilder addAttribute(string attributeName,string attributeValue)
        {
            string attribute = string.Format(" " + attributeName + "={0}", attributeValue);

            if (tagHolder.Count != 0)
            {
                if (xmlBuilder[xmlBuilder.Length - 1] == '>')
                {
                    xmlBuilder.Insert(xmlBuilder.Length - 1, attribute);
                }
                else
                {
                    throw new ArgumentException("Does not contain a closing tag '>'.");
                }
            } else
            {
                throw new ArgumentException("There are no open tags.");
            }
            return this;
        }


        public XMLMarkupBuilder addText(string text)
        {

            xmlBuilder.Append(text);
            return this;
        }


        public XMLMarkupBuilder closeTag()
        {
            string helperTag = tagHolder.Pop();
            xmlBuilder.Append(helperTag);
            return this;
        }


        public XMLMarkupBuilder finish()
        {
            List<string> finishHelper = new List<string>();
            while(tagHolder.Count != 0)
            {
                finishHelper.Add(tagHolder.Pop());
            }

            foreach (var item in finishHelper)
            {
                xmlBuilder.Append(item);
            }

            return this;
        }

        public String getResult()
        {
            return xmlBuilder.ToString();
        }

    }
}
