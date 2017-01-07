using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sparkling.Component.Async.Core;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public int Count { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e1)
        {
            WinFormAsyncComponent.Instance.BeginActionInvoke(
             action: () =>
             {
                 if (Count == 0)
                 {
                     Count++;
                     System.Threading.Thread.Sleep(10000);
                 }
                 else
                 {
                     System.Threading.Thread.Sleep(2000);
                 }
             },
             success: () =>
             {
                 this.label1.Text = "Success.";
             },
             millisecondsTimeout: 100000,
             error: e =>
             {
                 this.label1.Text = "Error: " + e.Message;
             });
        }

        private void button2_Click(object sender, EventArgs e1)
        {
            WinFormAsyncComponent.Instance.BeginFuncInvoke<Model, Model>(
            action: param =>
            {
                Thread.Sleep(3000);
                return new Model() { Message = param.Message };
            },
            param1: new Model() { Message = "Hello world!" },
            success: m =>
            {
                this.label2.Text = "Success: " + m.Message;
            },
            millisecondsTimeout: 5000,
            error: e =>
            {
                this.label2.Text = "Error: " + e.Message;
            });
        }
    }

    public class Model
    {
        public string Message { get; set; }
    }
}
