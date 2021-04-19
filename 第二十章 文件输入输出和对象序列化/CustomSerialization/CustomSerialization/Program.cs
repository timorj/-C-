using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********Fun with Custom Serialization ***********");

            StringData data = new StringData();

            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fStream = new FileStream("StringData.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormatter.Serialize(fStream, data);
            }

            //序列化
            MoreData data1 = new MoreData();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fStream = new FileStream("MoreData.txt", FileMode.Create, FileAccess.Write, FileShare.None)) 
            {
                binaryFormatter.Serialize(fStream, data1);
            }
            //反序列化
            using (FileStream fStream = File.OpenRead("MoreData.txt")) 
            {
                 MoreData data2 = (MoreData)binaryFormatter.Deserialize(fStream);
                Console.WriteLine(data2.ToString());
            }
                Console.ReadLine();
             

        }
    }
    
    /// <summary>
    /// 自定义序列化类
    /// </summary>
    [Serializable]
    class StringData : ISerializable
    {
        private string dataItemOne = "First data bolck.";
        private string dataItemTwo = "More data";
        public StringData()
        {

        }
        protected StringData(SerializationInfo si, StreamingContext ctx) 
        {
            dataItemOne = si.GetString("First_Item").ToLower();
            dataItemTwo = si.GetString("dataItemTwo").ToLower();

        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("First_Item", dataItemOne.ToUpper());
            info.AddValue("dataItemTwo", dataItemTwo.ToUpper());
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        
    }
    //使用特性自定义序列化类
    [Serializable]
    class MoreData
    {
        private string dataItemOne = "First data bock";
        private string dataItemTwo = "More data";

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            dataItemOne = dataItemOne.ToUpper();
            dataItemTwo = dataItemTwo.ToUpper();
        }
        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            dataItemOne = dataItemOne.ToLower();
            dataItemTwo = dataItemTwo.ToLower();
        }

    }
}
