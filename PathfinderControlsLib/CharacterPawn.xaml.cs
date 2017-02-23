using PathfinderAdventure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour PionCharacter.xaml
    /// </summary>
    public partial class CharacterPawn : UserControl
    {
        public string CharachterName { get; set; }
        public Brush PublicColor { get; set; }
        public Image Avatar { get; set; }
        private PawnTooltip toolTip;
        private Brush localColor = Brushes.Green;

        public CharacterPawn()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            toolTip = new PawnTooltip { };
            ToolTip = toolTip;
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                this.DataContextChanged += CharacterPawn_DataContextChanged;
            }
        }

        private void CharacterPawn_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            toolTip.DataContext = DataContext;
        }
    }
}