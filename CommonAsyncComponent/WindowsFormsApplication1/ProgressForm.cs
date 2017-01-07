using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        public ProgressForm(string head, ProgressType type)
            : this()
        {
            this.labelTitle.Text = head;
            switch (type)
            {
                case ProgressType.Spin:
                    this.labelTitle.Image = Resources.NewProcessBar;
                    break;
                case ProgressType.Bar:
                    this.labelTitle.Image = Resources.ProcessBar;
                    break;
                default:
                    break;
            }
        }

        public enum ProgressType
        {
            Spin,
            Bar
        }
    }
}