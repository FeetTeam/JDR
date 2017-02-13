﻿using PathfinderAdventure.BasePathFinder;
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
        private ICharacterService channelChat;
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
            using (var factoChat = new ChannelFactory<ICharacterService>("cep"))
            {
                channelChat = factoChat.CreateChannel();
                var characterByName = channelChat.GetCharacterPersoWs(nameTextBox.Text);
                //characterByName.Abilities.Charisma = new PathfinderAdventure.Ability { Name = "Cha" };
                charTemp = new CharacterWs { CharacterPersoWs = characterByName };
                canvas1.DataContext = charTemp.CharacterPersoWs;

                wrapPanel1.DataContext = charTemp.CharacterPersoWs;
                carac.DataContext = charTemp.CharacterPersoWs;
            }
        }

        private void buttonSet_Click(object sender, RoutedEventArgs e)
        {
            //genderTextBox.Text = channelChat.GetData(5);
            using (var factoChat = new ChannelFactory<ICharacterService>("cep"))
            {
                channelChat = factoChat.CreateChannel();
                channelChat.CreateCharacter(charTemp);

                if (charTemp.CharacterPersoWs.Id == 0)
                {
                    channelChat.GetCharacterPersoWs(charTemp.CharacterPersoWs.Name);
                }
            }
        }

        private void btNew_Click(object sender, RoutedEventArgs e)
        {
            charTemp = new CharacterWs();
            canvas1.DataContext = charTemp.CharacterPersoWs;
        }
    }
}