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

namespace PathfinderControlsLib
{
    /// <summary>
    /// Logique d'interaction pour DrawingTable.xaml
    /// </summary>
    public partial class DrawingTable : UserControl
    {
        public const int TAILLE_CASE = 20;
        public int NbCols { get; set; }
        public int NbRows { get; set; }

        public Ellipse SelectedEllipse { get; set; }
        public Point Origine { get; set; }
        private bool captureEnCours;

        public DrawingTable()
        {
            InitializeComponent();
        }

        private void DessinCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("DessinCanvas_MouseDown");
            SelectedEllipse = e.Source as Ellipse;

            if (SelectedEllipse != null)
            {
                captureEnCours = true;
            }
        }

        private void DessinCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (captureEnCours && e.LeftButton == MouseButtonState.Pressed && e.Source is Ellipse)
            {
                var position = e.GetPosition(DessinCanvas);
                DessinCanvas.ClipToBounds = true;

                // Matrix matrixAssociation = (SelectedEllipse.RenderTransform as MatrixTransform).Matrix;
                Matrix matrixAssociation = SelectedEllipse.RenderTransform.Value;

                matrixAssociation.OffsetX = position.X - TAILLE_CASE / 2;
                matrixAssociation.OffsetY = position.Y - TAILLE_CASE / 2;
                SelectedEllipse.RenderTransform = new MatrixTransform(matrixAssociation);
            }
        }

        private void DessinCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            captureEnCours = false;
            Matrix matrixAssociation = SelectedEllipse.RenderTransform.Value;

            var position = e.GetPosition(DessinCanvas);
            var resteX = position.X % TAILLE_CASE;
            var resteY = position.Y % TAILLE_CASE;
            matrixAssociation.OffsetX = position.X - resteX;
            matrixAssociation.OffsetY = position.Y - resteY;
            SelectedEllipse.RenderTransform = new MatrixTransform(matrixAssociation);
        }

        private void DessinCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            captureEnCours = false;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedEllipse = new Ellipse { Width = TAILLE_CASE, Height = TAILLE_CASE, Fill = Brushes.Red };
            DessinCanvas.Children.Add(SelectedEllipse);
            DessinerCases();
        }

        public void DessinerCases()
        {
            for (int col = 0; col < DessinCanvas.ActualWidth / TAILLE_CASE; col++)
            {
                var x = col * TAILLE_CASE;

                DessinCanvas.Children.Add(new Line { Stroke = Brushes.Black, X1 = x, X2 = x, Y1 = 0, Y2 = DessinCanvas.ActualHeight });
            }
            for (int ligne = 0; ligne < DessinCanvas.ActualHeight / TAILLE_CASE; ligne++)
            {
                var y = ligne * TAILLE_CASE;

                DessinCanvas.Children.Add(new Line { Stroke = Brushes.Black, X1 = 0, X2 = DessinCanvas.ActualWidth, Y1 = y, Y2 = y });
            }
        }
    }
}