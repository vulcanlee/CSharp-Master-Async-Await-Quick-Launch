using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AA25_更新UI物件卻會當掉_Windows_Forms
{
    public partial class Form1 : Form
    {
        string baseURI =
            "https://backendhol.azurewebsites.net/api/performance";

        public Form1()
        {
            InitializeComponent();
        }

        #region 這樣的程式碼無法更新 UI 控制項
        //private async void CannotUpdateBtn_ClickAsync(object sender, EventArgs e)
        //{
        //    await Task.Run(async () =>
        //    {
        //        var client = new HttpClient();
        //        var endPoint = $"{baseURI}/add/99/87/2";
        //        var task = client.GetStringAsync(endPoint);
        //        var result = await task;
        //        label1.Text = result;
        //    });
        //}
        #endregion

        #region 解決方案 1 : 使用 Control.Invoke
        //private async void CannotUpdateBtn_ClickAsync(object sender, EventArgs e)
        //{
        //    await Task.Run(async () =>
        //    {
        //        var client = new HttpClient();
        //        var endPoint = $"{baseURI}/add/99/87/2";
        //        var task = client.GetStringAsync(endPoint);
        //        var result = await task;
        //        this.Invoke(new Action(() =>
        //        {
        //            label1.Text = result;
        //        }));
        //    });
        //}
        #endregion

        #region 解決方案 2 : 直接使用 Synchronization
        private async void CannotUpdateBtn_ClickAsync(object sender, EventArgs e)
        {
            var sc = SynchronizationContext.Current;
            await Task.Run(async () =>
            {
                var client = new HttpClient();
                var endPoint = $"{baseURI}/add/99/87/2";
                var task = client.GetStringAsync(endPoint);
                var result = await task;
                sc.Post(_ =>
                {
                    label1.Text = result;
                }, null);
            });
        }
        #endregion
    }
}
