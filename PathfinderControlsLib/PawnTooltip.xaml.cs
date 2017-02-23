using PathfinderAdventure;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace PathfinderControlsLib
{
    /// <summary>
    /// Logique d'interaction pour PionTooltip.xaml
    /// </summary>
    public partial class PawnTooltip : UserControl
    {
        public string Nom { get; set; }
        public int PV { get; set; }
        public string Race { get; set; }
        public System.Drawing.Image Avatar { get; set; }
        public Icon Icon { get; set; }

        public PawnTooltip()
        {
            InitializeComponent();

            PV = 10;
            Nom = "Nom";
            DataContextChanged += PawnTooltip_DataContextChanged;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Ne chargez pas vos données au moment du design.
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                // 	//Chargez vos données ici et assignez le résultat à CollectionViewSource.
                //System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["characterViewSource"];
                //myCollectionViewSource.Source = null;
            }
        }

        private void PawnTooltip_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            return;
            var character = e.NewValue as Character;
            if (character != null)
            {
                this.nameTextBlock.Text = character.Name;
                this.nameTextBlock1.Text = character?.Race?.Name;
                this.currentHealthPointTextBlock.Text = character.Health.FirstOrDefault().CurrentHealthPoint.ToString();
            }
        }
    }
}