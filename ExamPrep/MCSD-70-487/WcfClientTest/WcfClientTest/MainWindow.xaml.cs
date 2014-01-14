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
using System.ServiceModel;

namespace WcfClientTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CallableServiceCallback callback;
        ServiceReference1.CallableServiceClient client;
        
        public MainWindow()
        {
            InitializeComponent();
            callback = new CallableServiceCallback();
            callback.ServiceResponse += callback_ServiceResponse;
        }

        void callback_ServiceResponse(object sender, ServiceResponseEventArgs e)
        {
            TextBox1.Text = e.Response.ToString() + Environment.NewLine;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var instanceContext = new InstanceContext(callback);
            client = new ServiceReference1.CallableServiceClient(instanceContext);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client.Add(1, 2);
        }
    }
}
