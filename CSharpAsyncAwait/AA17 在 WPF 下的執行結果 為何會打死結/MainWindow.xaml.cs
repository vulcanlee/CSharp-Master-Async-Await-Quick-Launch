using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AA17_在_WPF_下的執行結果_為何會打死結
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void ShowThreadId(string message)
        {
            if (string.IsNullOrEmpty(message))
                Debug.WriteLine("");
            else
                Debug.WriteLine($"{message} Thread Id=" +
                    $"{Thread.CurrentThread.ManagedThreadId}");
        }

        async Task MyAsyncMethod()
        {
            ShowThreadId("await MyMethod Before");
            await Task.Delay(3000);
            ShowThreadId("await MyMethod After");
            return;
        }
        Task MyPureTask()
        {
            return Task.Run(() =>
            {
                ShowThreadId("Thread.Sleep Before");
                Thread.Sleep(3000);
                ShowThreadId("Thread.Sleep After");
            });
        }

        async void await非同步工作_Click(object sender, RoutedEventArgs e)
        {
            var myTask = MyPureTask();
            ShowThreadId("await myTask Before");
            await myTask;
            ShowThreadId("await myTask After");
            ShowThreadId("");
        }
        async void await非同步方法_Click(object sender, RoutedEventArgs e)
        {
            var myTask = MyAsyncMethod();
            ShowThreadId("await myTask Before");
            await myTask;
            ShowThreadId("await myTask After");
            ShowThreadId("");
        }
        void Wait非同步工作_Click(object sender, RoutedEventArgs e)
        {
            var myTask = MyPureTask();
            ShowThreadId("Wait myTask Before");
            myTask.Wait();
            ShowThreadId("Wait myTask After");
            ShowThreadId("");
        }

        void Wait非同步方法_Click(object sender, RoutedEventArgs e)
        {
            var myTask = MyAsyncMethod();
            ShowThreadId("Wait myTask Before");
            myTask.Wait();
            ShowThreadId("Wait myTask After");
            ShowThreadId("");
        }
    }
}
