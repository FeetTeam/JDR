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
        private bool translationEnCours;
        private Point origineGlissement;

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
            else if (e.Source == DessinCanvas)
            {
                translationEnCours = true;
                origineGlissement = e.GetPosition(DessinCanvas);
            }
        }

        private void DessinCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedEllipse != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    var position = e.GetPosition(DessinCanvas);

                    if (captureEnCours)
                    {
                        //Matrix matrixAssociation = (SelectedEllipse.RenderTransform as MatrixTransform).Matrix;
                        Matrix matrixEllipse = SelectedEllipse.RenderTransform.Value;

                        if (position.X - TAILLE_CASE / 2 > 0 && position.Y - TAILLE_CASE / 2 > 0
                            && position.X + TAILLE_CASE / 2 < ActualWidth
                            && position.Y + TAILLE_CASE / 2 < ActualHeight)
                        {
                            matrixEllipse.OffsetX = position.X - TAILLE_CASE / 2;
                            matrixEllipse.OffsetY = position.Y - TAILLE_CASE / 2;
                            SelectedEllipse.RenderTransform = new MatrixTransform(matrixEllipse);
                        }
                    }
                }
            }
            if (translationEnCours)
            {
                var position = e.GetPosition(DessinCanvas);
                Matrix matrixDessin = DessinCanvas.RenderTransform.Value;
                var deltax = position.X - origineGlissement.X;
                var deltay = position.Y - origineGlissement.Y;
                matrixDessin.Translate(deltax, deltay);
                DessinCanvas.RenderTransform = new MatrixTransform(matrixDessin);
            }
        }

        private void DessinCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (SelectedEllipse != null)
            {
                captureEnCours = false;
                Matrix matrixEllipse = SelectedEllipse.RenderTransform.Value;
                var position = e.GetPosition(DessinCanvas);

                Aligner(position, ref matrixEllipse);
                SelectedEllipse.RenderTransform = new MatrixTransform(matrixEllipse);
            }
            else
            {
                translationEnCours = false;
            }
        }

        private void DessinCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!captureEnCours) return;
            if (SelectedEllipse == null) return;

            var ptSouris = e.GetPosition(DessinCanvas);
            Matrix matrixEllipse = SelectedEllipse.RenderTransform.Value;

            if (ptSouris.X > DessinCanvas.ActualWidth)
            {
                ptSouris.Offset(-TAILLE_CASE, 0);
            }
            if (ptSouris.Y > DessinCanvas.ActualHeight)
            {
                ptSouris.Offset(0, -TAILLE_CASE);
            }

            Aligner(ptSouris, ref matrixEllipse);
            SelectedEllipse.RenderTransform = new MatrixTransform(matrixEllipse);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedEllipse = new Ellipse { Width = TAILLE_CASE, Height = TAILLE_CASE, Fill = Brushes.Red };
            DessinCanvas.Children.Add(SelectedEllipse);
            DessinerCases();
            DessinCanvas.ClipToBounds = true;
        }

        public void Aligner(Point p, ref Matrix mSrc)
        {
            var resteX = p.X % TAILLE_CASE;
            var resteY = p.Y % TAILLE_CASE;

            mSrc.OffsetX = p.X - resteX;
            mSrc.OffsetY = p.Y - resteY;
        }

        public void Aligner(Point pSouris, Rect rectContainer, ref Point ptInContainer)
        {
            ptInContainer = pSouris;
            if (pSouris.X < rectContainer.X) ptInContainer.X = 0;
            if (pSouris.X > rectContainer.Width) ptInContainer.X = rectContainer.Width;
            if (pSouris.Y < rectContainer.Y) ptInContainer.X = 0;
            if (pSouris.X > rectContainer.Height) ptInContainer.Y = rectContainer.Height - TAILLE_CASE;
        }

        public void DessinerCases()
        {
            for (int col = 0; col < DessinCanvas.ActualWidth / TAILLE_CASE; col++)
            {
                var x = col * TAILLE_CASE;
                DessinCanvas.Children.Add(new Line { Stroke = Brushes.Black, X1 = x, X2 = x, Y1 = 0, Y2 = DessinCanvas.ActualHeight, Opacity = 0.50 });
            }
            for (int ligne = 0; ligne < DessinCanvas.ActualHeight / TAILLE_CASE; ligne++)
            {
                var y = ligne * TAILLE_CASE;
                DessinCanvas.Children.Add(new Line { Stroke = Brushes.Black, X1 = 0, X2 = DessinCanvas.ActualWidth, Y1 = y, Y2 = y });
            }
        }

        private void DessinCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var matrice = DessinCanvas.RenderTransform.Value;
            double valeurZoom = 0;
            double delta = e.Delta;
            valeurZoom = 1 + delta / 1000d;
            matrice.Scale(valeurZoom, valeurZoom);
            DessinCanvas.RenderTransform = new MatrixTransform(matrice);
        }
    }
}