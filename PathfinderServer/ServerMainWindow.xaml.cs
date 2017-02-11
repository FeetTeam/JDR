using PathfinderWebServiceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace PathfinderServer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static CharacterService service;
        private ServiceHost serviceHost;

        public MainWindow()
        {
            InitializeComponent();
            var dbctxt = new PathfinderAdventure.BasePathFinder.PathFinderDbContext();

            dbctxt.Database.CreateIfNotExists();

            service = new CharacterService();
            service.OnLog += Service_OnLog;
            btStart_Click(this, new RoutedEventArgs());
        }

        private void Service_OnLog(object sender, LogEventArgs e)
        {
            Console.WriteLine(e.Message);
            listBox.Items.Add(e.Message);
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            btStart.IsEnabled = false;
            serviceHost = new ServiceHost(service);
            serviceHost.Open();

            //Create a ChannelFactory and load the configuration setting
            var channelFactory = new ChannelFactory<ICharacterService>("cep");
            Console.WriteLine(channelFactory.Endpoint.Address);
            //var channel = channelFactory.CreateChannel();
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            serviceHost.Close();
            btStart.IsEnabled = true;
        }
    }
}