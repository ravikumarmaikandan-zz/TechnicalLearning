using System;
using System.Collections.Generic;
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

namespace AsynchronousProgramming
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

        private async void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            #region Asyncronous using Task
            //btnLogin.IsEnabled = false;
            // var task = Task.Run(() =>
            // {
            //    Thread.Sleep(2000);
            //     return "Login Successfull";
            // });

            //task.ContinueWith((t) =>
            //{
            //    Dispatcher.Invoke(() =>
            //    {
            //        btnLogin.IsEnabled = true;
            //        btnLogin.Content = t.Result;
            //    });
            //});
            //task.ConfigureAwait(true).GetAwaiter().OnCompleted(() =>
            //{
            //    if (task.IsFaulted)
            //    {
            //        btnLogin.IsEnabled = true;
            //        btnLogin.Content = "Login Failed!!";

            //    }
            //    else
            //    {
            //        btnLogin.IsEnabled = true;
            //        btnLogin.Content = task.Result;

            //    }
            //});
#endregion

            #region Async Await
            try
            {
                var result = await LoginAsync();
                btnLogin.Content = result;

            }
            catch (Exception)
            {

                btnLogin.Content = "Internal Error!!!";
            }
            #endregion
        }

        public async Task<string> LoginAsync()
        {
            try
            {
                //Firing single task with return result
                //var result = await Task.Run(() =>
                //{
                //    Thread.Sleep(2000);
                //    return "Login Successful!!";
                //});

                //Firing multiple task at the same time (parallel execution)
                var firstTask = Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    return "Login Successful!!";
                });

                var secondTask = Task.Delay(2000);
                var thirstTask = Task.Delay(1000);

                await Task.WhenAll(firstTask, secondTask, thirstTask);
                return firstTask.Result;
            }
            catch (Exception)
            {

                return "Login Failed!!";
            }

        }
    }
}
