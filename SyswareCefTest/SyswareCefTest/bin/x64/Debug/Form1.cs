using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;

namespace SyswareCefTest
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser _browser;
        public Form1()
        {
            InitializeComponent();
            initView();
        }

        private void initView()
        {
            //获取文件的物理路径
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\HTMLPage1.html";
            //转换为File协议路径
            path = "file://" + path.Replace("\\", "/");

            //path = "www.baidu.com";
            _browser = new ChromiumWebBrowser(path);
            if (_browser.IsBrowserInitialized)
            {
                _browser.ShowDevTools();
            }

            // 注册对象，必须在 browser 一创建后就注册
            _browser.RegisterJsObject("cef", new CefCallTest());
            _browser.RegisterJsObject("form", this);
            browserPanel.Controls.Add(_browser);

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _browser.Reload(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_browser != null && _browser.IsBrowserInitialized)
            {
                var task = _browser.EvaluateScriptAsync(@"getText1Value()");

                object result;
                task.ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        var response = t.Result;
                        result = response.Success ? (response.Result ?? "null") : response.Message;
                        textBox1.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("出错了");
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        public string getInputStr()
        {
            return textBox2.Text;
        }

    }
}
