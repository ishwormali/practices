using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestApp
{
    class XmlPractice
    {
        public void Test()
        {
            var path=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"XMLFile1.xml");

            using (var reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Whitespace)
                    {
                        Console.WriteLine(string.Format("{0} Tag: {1}, ........Value={2}",reader.IsStartElement()?"Opening":"Closing", reader.Name, reader.Value));
                    }
                }

            } 

        }
    }
}
