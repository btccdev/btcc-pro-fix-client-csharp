using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BTCCProFix.FixClientRelated
{
	class FIX44XMLParser
	{
		public string getFieldName(string tag)
		{
			string field_name = "";
			XmlDocument doc = new XmlDocument();
			doc.Load(Constants.FIX_XML_PATH);
			XmlElement rootElem = doc.DocumentElement;
			XmlNodeList field = rootElem.GetElementsByTagName("field");
			foreach (XmlNode node in field)
			{
				string field_number = ((XmlElement)node).GetAttribute("number");
				field_name = ((XmlElement)node).GetAttribute("name");
				//				string field_type = ((XmlElement)node).GetAttribute("type");
				//				Console.WriteLine("field number is: "+ field_number);  
				//				Console.WriteLine("field name is: "+ field_name);  
				//				Console.WriteLine("field type is: "+ field_type);  
				if (tag.Equals(field_number))
				{
					return field_name;
				}
			}
			return field_name;
		}

		public string getFieldName(string group, string tag)
		{
			string field_name = "";
			XmlDocument doc = new XmlDocument();
			doc.Load(Constants.FIX_XML_PATH);
			XmlElement rootElem = doc.DocumentElement;
			XmlNodeList field = rootElem.GetElementsByTagName("field");
			foreach (XmlNode node in field)
			{
				string field_number = ((XmlElement)node).GetAttribute("number");
				field_name = ((XmlElement)node).GetAttribute("name");
				//				string field_type = ((XmlElement)node).GetAttribute("type");
				//				Console.WriteLine("field number is: "+ field_number);  
				//				Console.WriteLine("field name is: "+ field_name);  
				//				Console.WriteLine("field type is: "+ field_type);  
				if (group.Equals(field_number))
				{
					XmlNodeList value = ((XmlElement)node).GetElementsByTagName("value");
					foreach (XmlNode subnode in value)
					{
						string num = ((XmlElement)subnode).GetAttribute("enum");
						field_name = ((XmlElement)subnode).GetAttribute("description");
						if (tag.Equals(num))
						{
							return field_name;
						}
					}
					return field_name;
				}
			}
			return field_name;
		}
	}
}
