using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using CommonSnappableTypes;

namespace CSharpSnapIn
{
    [CompanyInfo(CompanyName = "My Commpany", CompanyUrl = "www.tencent.com")]
    public class CSharpSnapIn : IAppFunctionality
    {
        void  IAppFunctionality.DoIt()
        {
            MessageBox.Show("you have just used the C# snap in!");
        }
    }
}
