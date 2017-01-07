using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sparkling.Component.Async.Interface;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class ImageProgress : IProgress
    {
        private ProgressForm progress = new ProgressForm("Wait..." + new Random().Next(0, 100), ProgressForm.ProgressType.Bar);

        public void Show()
        {
            this.progress.Show();
        }

        public void Close()
        {
            if (this.progress != null)
            {
                this.progress.Close();
                this.progress.Dispose();
            }
        }
    }
}
