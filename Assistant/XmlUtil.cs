using System;
using System.Linq;
using System.Xml;
using System.Globalization;
using System.IO;

namespace Assistant
{
    public class XmlUtil
    {
        public XmlDocument Doc { get; set; }
        public XmlElement AddNode(string name, string value, XmlElement parent, bool valueIsNull = true)
        {
            if (!valueIsNull && value == "")
                return null;

            XmlElement newNode = Doc.CreateElement(name);
            if (value != "")
                newNode.AppendChild(Doc.CreateTextNode(value));
            if (parent != null)
            {
                parent.AppendChild(newNode);
                return newNode;
            }
            else
                return newNode;
        }
        public void AddAttribute(string name, string value, XmlElement parent)
        {
            XmlAttribute newAttr = Doc.CreateAttribute(name);
            newAttr.Value = value;
            parent.SetAttributeNode(newAttr);
        }
        public XmlNode GetNode(XmlNode node, string nodeName)
        {
            if (node == null)
                return null;
            foreach (XmlNode nd in node.ChildNodes)
                if (nd.Name == nodeName)
                    return nd;
            return null;
        }
        public string GetValue(XmlDocument doc, string nodeName)
        {
            if (doc?.GetElementsByTagName(nodeName).Count > 0)
                if (doc.GetElementsByTagName(nodeName).Item(0)?.ChildNodes.Count > 0)
                    return doc.GetElementsByTagName(nodeName).Item(0)?.ChildNodes[0]?.Value;
            return "";
        }
        public string GetValue(XmlNode node, string nodeName)
        {
            if (node == null)
                return "";
            foreach (XmlNode nd in node.ChildNodes)
                if (nd.Name == nodeName)
                    if (nd.ChildNodes.Count > 0)
                        return nd.ChildNodes[0].Value;
            return "";
        }
        public DateTime GetDateValue(XmlDocument doc, string nodeName, string dateFormat = "yyyy-MM-dd", string dateSeparator = "-")
        {
            return Convert.ToDateTime(GetValue(doc, nodeName), new DateTimeFormatInfo { ShortDatePattern = dateFormat, DateSeparator = dateSeparator });
        }
        public string GetValueAttr(XmlNode node, string nodeName, string attrName)
        {
            foreach (XmlNode nd in node.ChildNodes)
                if (nd.Name == nodeName)
                    if (nd.Attributes?[attrName] != null)
                        return nd.Attributes[attrName].Value;
            return "";
        }
        public static string GetValueFromSpecAttribute(string xmlFrag, string attrName, string attrValue)
        {
            var reader = new XmlTextReader(new StringReader(xmlFrag));
            reader.WhitespaceHandling = WhitespaceHandling.None;
            while (reader.Read())
                if (reader.NodeType == XmlNodeType.Element)
                    if (reader.GetAttribute(attrName) == attrValue)
                        break;
            return reader.ReadString();
        }
    }
}