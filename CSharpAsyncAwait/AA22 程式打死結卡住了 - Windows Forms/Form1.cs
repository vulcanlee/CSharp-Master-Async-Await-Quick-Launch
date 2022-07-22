using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AA22_程式打死結卡住了___Windows_Forms
{
    public partial class Form1 : Form
    {
        string baseURI =
       "https://backendhol.azurewebsites.net/api/performance";
        public Form1()
        {
            InitializeComponent();
        }

        #region 這裡程式碼 會 打死結
        //private void DoDeadlock_Click(object sender, EventArgs e)
        //{
        //    var sumTask = SumAsync(168, 89);
        //    var result = sumTask.Result;
        //    label1.Text = result;
        //}
        #endregion

        #region (這裡程式碼不會打死結) 全部都使用 async await 就可以解決囉
        private async void DoDeadlock_ClickAsync(object sender, EventArgs e)
        {
            var result = await SumAsync(168, 89);
            label1.Text = result;
        }
        #endregion

        async Task<string> SumAsync(int a, int b)
        {
            var client = new HttpClient();
            var endPoint = $"{baseURI}/add/{a}/{b}/2";
            var task = client.GetStringAsync(endPoint);
            var result = await task;
            return result;
        }
    }
}
