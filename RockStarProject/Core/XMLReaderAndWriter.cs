using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RockStarProject.Core
{
    public class XMLReaderAndWriter
    {
        public static void WriteXmlFile<T>(T objectToWrite) where T : new()
        {
            var filePath = "C:\\Users\\Anna\\source\\repos\\RockStarProject\\RockStarProject\\Core\\Favorites.xml";
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        public static T ReadXmlFile<T>() where T : new()
        {
            var filePath = "C:\\Users\\Anna\\source\\repos\\RockStarProject\\RockStarProject\\Core\\Favorites.xml";
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
