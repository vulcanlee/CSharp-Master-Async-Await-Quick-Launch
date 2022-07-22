using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AA26_UI會停頓與不順暢_Windows_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBySleep_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
        }

        private async void btnByDelay_Click(object sender, EventArgs e)
        {
            await Task.Delay(3000);
        }
    }
}
