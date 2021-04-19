using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********Fun with object serialize *******\n");

            FileStream fStream = File.Create("CarData.dat");
           
            fStream.Close();
           
            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubMerge = false;
            jbc.theRadio.stationPresets = new double[] { 89.3, 105.3, 97.1 };
            jbc.theRadio.hasTweeters = true;

            SaveAsBinaryFormat(jbc, "CarData.dat");
            LoadFromBinaryFile("CarData.dat");

            SaveAsSoapFormat(jbc, "CarData.soap");
            LoadFromSoapFile("CarData.soap");

            SaveAsXmlFormat(jbc, "CarData.xml");

            SaveListOfCars();
            Console.ReadLine();
        
        }
        /// <summary>
        /// 序列化JamsBondCar对象
        /// </summary>
        /// <param name="objGraph"></param>
        /// <param name="fileName"></param>
        static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (FileStream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Save car in binary format");
        }

        /// <summary>
        /// 反序列化JamsBondCar对象
        /// </summary>
        /// <param name="fileName"></param>
        static void LoadFromBinaryFile(string fileName) 
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (FileStream fStream = File.OpenRead(fileName))
            {
                JamesBondCar jbc = (JamesBondCar)binFormat.Deserialize(fStream);
                Console.WriteLine("Can this car fly:{0}", jbc.canFly);
            }
        }
        /// <summary>
        /// 序列化JamsBondCar对象
        /// </summary>
        /// <param name="objGraph"></param>
        /// <param name="fileName"></param>
        static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            SoapFormatter soapFormat = new SoapFormatter();

            using (FileStream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Save car in binary format");
        }
        /// <summary>
        /// 反序列化JamsBondCar对象
        /// </summary>
        /// <param name="fileName"></param>
        static void LoadFromSoapFile(string fileName)
        {
            SoapFormatter soapFormat = new SoapFormatter();
            using (FileStream fStream = File.OpenRead(fileName))
            {
                JamesBondCar jbc = (JamesBondCar)soapFormat.Deserialize(fStream);
                Console.WriteLine("Can this car fly:{0}", jbc.canFly);
            }
        }

        static void SaveAsXmlFormat(object objGraph, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));

            using (Stream fStream = new FileStream( fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in XML format!");
        }

        static void SaveListOfCars()
        {
            List<JamesBondCar> myCars = new List<JamesBondCar>() {
                new JamesBondCar(true, false),
                new JamesBondCar(true, true),
                new JamesBondCar(false, false),
                new JamesBondCar(false, true)
            };
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
            using (Stream fStream = new FileStream("CarCollection.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("=> Save list of Cars");
        }
    }

}
