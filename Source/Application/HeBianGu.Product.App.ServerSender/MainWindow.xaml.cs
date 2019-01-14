using HeBianGu.Product.Domain.ServerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace HeBianGu.Product.App.ServerSender
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ServerManager.Instance.StartServer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServerManager.Instance.SendMessage(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + this.txt_message.Text);
        }
    }
}
