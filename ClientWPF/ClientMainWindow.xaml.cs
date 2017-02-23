using Microsoft.Win32;
using PathfinderAdventure;
using PathfinderControlsLib;
using PathfinderWebServiceLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ClientWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class ClientMainWindow : Window
    {
        private ICharacterService channelChat;
        private CharacterWs charTemp;
        private List<Character> charactersModifiedList;
        private CollectionViewSource characterViewSource;
        private CollectionViewSource raceViewSource;

        public ClientMainWindow()
        {
            InitializeComponent();
            charactersModifiedList = new List<Character>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            characterViewSource = new CollectionViewSource();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                characterViewSource = ((CollectionViewSource)(this.FindResource("characterViewSource")));
                CollectionViewSource coinsViewSource = ((CollectionViewSource)(this.FindResource("coinsViewSource")));
                raceViewSource = ((CollectionViewSource)(this.FindResource("raceViewSource")));

                characterDataGrid.SelectionChanged += DataGrid_SelectionChanged;
                DrawingTable1.OnGridModified += DrawingTable1_OnGridModified;
            }
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // raceViewSource.Source = [source de données générique]
        }

        private void DrawingTable1_OnGridModified(object sender, GrilleEventArg e)
        {
        }

        private void buttonGet_Click(object sender, RoutedEventArgs e)
        {
            using (var factoChat = new ChannelFactory<ICharacterService>("cep"))
            {
                channelChat = factoChat.CreateChannel();
                var characterByName = channelChat.GetCharacterPersoWs(nameTextBox.Text);
                charTemp = new CharacterWs { CharacterPersoWs = characterByName };
                canvas1.DataContext = charTemp.CharacterPersoWs;
                carac.DataContext = charTemp.CharacterPersoWs;

                characterViewSource.Source = channelChat.GetCharacters();
                raceViewSource.Source = channelChat.GetRaces();

                characterDataGrid.ItemsSource = characterViewSource.View;

                this.DataContext = charTemp.CharacterPersoWs;
                DrawingTable1.Pawn.DataContext = DataContext;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void buttonSet_Click(object sender, RoutedEventArgs e)
        {
            using (var factoChat = new ChannelFactory<ICharacterService>("cep"))
            {
                channelChat = factoChat.CreateChannel();
                channelChat.CreateCharacter(charTemp);

                var selection = characterDataGrid.SelectedItem;

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

        private void characterDataGrid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            this.charactersModifiedList.Add(BindingOperations.GetBindingExpression(e.TargetObject, e.Property).DataItem as Character);
        }

        private void characterDataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            var cell = e.OriginalSource as DataGridCell;
            var dataGrid = sender as DataGrid;
            if (cell != null)
            {
                cell.IsEditing = true;
            }
        }

        private void characterDataGrid_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
        }

        private void image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as CheckBox;
            if (button != null && button.IsChecked == true)
            {
                var dlgBox = new OpenFileDialog();
                var res = dlgBox.ShowDialog();
                if (res != null && res == true)
                {
                    var img = new Bitmap(dlgBox.FileName);
                    //charTemp.CharacterPersoWs.Avatar = img;
                    //charTemp.CharacterPersoWs.AvatarToBytes(img);
                }
            }
        }
    }

    public class DebugConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}