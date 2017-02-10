using PathfinderAdventure.BasePathFinder;
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

namespace ClientWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class ServerMainWindow : Window
    {
        private IService1 channelChat;
        private CharacterWs charTemp;

        public ServerMainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource characterViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("characterViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // characterViewSource.Source = [source de données générique]
            System.Windows.Data.CollectionViewSource coinsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("coinsViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
        }

        private void buttonGet_Click(object sender, RoutedEventArgs e)
        {
            //genderTextBox.Text = channelChat.GetData(5);
            using (var factoChat = new ChannelFactory<IService1>("cep"))
            {
                channelChat = factoChat.CreateChannel();
                //var fiche = channelChat.GetCharacterPersoWs("Beurk2");
                //canvas1.DataContext = fiche;

                //var ficheSuperficielle = channelChat.GetCharacters();
                //var ab = channelChat.GetAbilities();

                var characterByName = channelChat.GetCharacterPersoWs(nameTextBox.Text);
                charTemp = new CharacterWs { CharacterPersoWs = characterByName };
                canvas1.DataContext = charTemp.CharacterPersoWs;
            }
        }

        private void buttonSet_Click(object sender, RoutedEventArgs e)
        {
            //genderTextBox.Text = channelChat.GetData(5);
            using (var factoChat = new ChannelFactory<IService1>("cep"))
            {
                channelChat = factoChat.CreateChannel();
                //charTemp.CharacterPersoWs.CoinsQuantity.GoldCoins = 333;
                //var nvCharact = new CharacterWs { CharacterPersoWs = new PathfinderAdventure.Character { Name = "bob", } };
                channelChat.CreateCharacter(charTemp);
            }
        }

        private void btNew_Click(object sender, RoutedEventArgs e)
        {
            charTemp = new CharacterWs { CharacterPersoWs = new PathfinderAdventure.Character() { CharacterName = "{init}" } };
            canvas1.DataContext = charTemp.CharacterPersoWs;
        }
    }
}