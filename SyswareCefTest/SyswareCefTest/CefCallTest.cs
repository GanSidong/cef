using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyswareCefTest
{
    public class CefCallTest
    {
        public string StringProp { get; set; }
        public void ShowHelloCef()
        {
            MessageBox.Show("这是一个MessageBox弹窗!!!!");
        }
        public CefCallTest()
        {
            StringProp = "Hello, Cef";
        }

        
    }
}
