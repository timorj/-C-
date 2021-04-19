using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleSerialize
{
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioID = "XF-552RR6";
    }
    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }
    [Serializable, XmlRoot(Namespace = "http://MyCompany.com")]
    public class JamesBondCar : Car
    {
        [XmlAttribute]
        public bool canFly;
        public bool canSubMerge;
        //序列化Xml数据需要默认构造函数
        public JamesBondCar()
        {

        }
        public JamesBondCar(bool canFly, bool canSubMerge)
        {
            this.canFly = canFly;
            this.canSubMerge = canSubMerge;
        }
    }
}
