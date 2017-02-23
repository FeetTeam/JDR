using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using static PathfinderControlsLib.GrilleEventArg;

namespace PathfinderControlsLib
{
    /// <summary>
    /// Logique d'interaction pour DrawingTable.xaml
    /// </summary>
    public partial class DrawingTable : UserControl
    {
        public event EventHandler<GrilleEventArg> OnGridModified;

        public bool IsTranslatable { get; set; }
        public bool IsZoomable { get; set; }
        public const int TAILLE_CASE = 20;
        public int NbCols { get; set; }
        public int NbRows { get; set; }

        public CharacterPawn Pawn { get; set; }

        public Point Origine { get; set; }
        private bool captureEnCours;
        private bool translationEnCours;
        private Point origineGlissement;
        public CollectionViewSource SourcePersos { get; set; }

        public DrawingTable()
        {
            InitializeComponent();
            Pawn = new CharacterPawn { Width = TAILLE_CASE, Height = TAILLE_CASE, PublicColor = Brushes.Blue };
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                DessinCanvas.ClipToBounds = true;
                DessinerCases();
                DessinCanvas.Children.Add(Pawn);
                SourcePersos = new CollectionViewSource();
                SourcePersos.Source = new List<CharacterPawn>() { };
            }
        }

        private void DessinCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("DessinCanvas_MouseDown");
            Pawn = e.Source as CharacterPawn;

            if (Pawn != null)
            {
                captureEnCours = true;
            }
            else if (e.Source == DessinCanvas && IsTranslatable)
            {
                translationEnCours = true;
                origineGlissement = e.GetPosition(DessinCanvas);
            }
        }

        private void DessinCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (Pawn != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    var position = e.GetPosition(DessinCanvas);

                    if (captureEnCours)
                    {
                        //Matrix matrixAssociation = (SelectedEllipse.RenderTransform as MatrixTransform).Matrix;
                        Matrix matrixEllipse = Pawn.RenderTransform.Value;

                        if (position.X - TAILLE_CASE / 2 > 0 && position.Y - TAILLE_CASE / 2 > 0
                            && position.X + TAILLE_CASE / 2 < ActualWidth
                            && position.Y + TAILLE_CASE / 2 < ActualHeight)
                        {
                            matrixEllipse.OffsetX = position.X - TAILLE_CASE / 2;
                            matrixEllipse.OffsetY = position.Y - TAILLE_CASE / 2;
                            Pawn.RenderTransform = new MatrixTransform(matrixEllipse);
                        }
                    }
                }
            }
            if (translationEnCours && IsTranslatable)
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
            if (Pawn != null)
            {
                captureEnCours = false;
                Matrix matrixEllipse = Pawn.RenderTransform.Value;
                var position = e.GetPosition(DessinCanvas);

                Aligner(position, ref matrixEllipse);
                Pawn.RenderTransform = new MatrixTransform(matrixEllipse);
                var coord = PointToPosition(position);
                OnGridModified?.Invoke(this, new GrilleEventArg { Colonne = coord.X, Ligne = coord.Y });
            }
            else
            {
                translationEnCours = false;
            }
        }

        private void DessinCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!captureEnCours) return;
            if (Pawn == null) return;

            var ptSouris = e.GetPosition(DessinCanvas);
            Matrix matrixEllipse = Pawn.RenderTransform.Value;

            if (ptSouris.X > DessinCanvas.ActualWidth)
            {
                ptSouris.Offset(-TAILLE_CASE, 0);
            }
            if (ptSouris.Y > DessinCanvas.ActualHeight)
            {
                ptSouris.Offset(0, -TAILLE_CASE);
            }

            Aligner(ptSouris, ref matrixEllipse);
            Pawn.RenderTransform = new MatrixTransform(matrixEllipse);
        }

        /// <summary>
        /// Gestion du zoom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DessinCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (IsZoomable)
            {
                var matrice = DessinCanvas.RenderTransform.Value;
                double valeurZoom = 0;
                double delta = e.Delta;
                valeurZoom = 1 + delta / 1000d;
                matrice.Scale(valeurZoom, valeurZoom);
                DessinCanvas.RenderTransform = new MatrixTransform(matrice);
            }
        }

        /// <summary>
        /// aligne l'ellipse sur les cases de la grille
        /// </summary>
        /// <param name="p"></param>
        /// <param name="mSrc"></param>
        public void Aligner(Point p, ref Matrix mSrc)
        {
            var resteX = p.X % TAILLE_CASE;
            var resteY = p.Y % TAILLE_CASE;

            mSrc.OffsetX = p.X - resteX;
            mSrc.OffsetY = p.Y - resteY;
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

        private Cooordonnées PointToPosition(Point p)
        {
            var coordonnées = new Cooordonnées();
            coordonnées.X = (int)p.X / TAILLE_CASE;
            coordonnées.Y = (int)p.Y / TAILLE_CASE;
            return coordonnées;
        }
    }

    public class GrilleEventArg : EventArgs
    {
        public class Cooordonnées
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public int Ligne { get; set; }
        public int Colonne { get; set; }
    }
}