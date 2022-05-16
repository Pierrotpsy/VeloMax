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

namespace BDD_MERLIN_MOUTY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GoFidelio(object sender, RoutedEventArgs e)
        {
            Fidelio pageFidelio = new Fidelio();
            pageFidelio.Show();
            this.Close();
        }
        private void GoAdhesion(object sender, RoutedEventArgs e)
        {
            Adhesion pageAdhesion = new Adhesion();
            pageAdhesion.Show();
            this.Close();
        }
        private void GoClient(object sender, RoutedEventArgs e)
        {
            Client pageClient = new Client();
            pageClient.Show();
            this.Close();
        }
        private void GoEntreprise(object sender, RoutedEventArgs e)
        {
            Entreprise pageEntreprise = new Entreprise();
            pageEntreprise.Show();
            this.Close();
        }
        private void GoFournisseur(object sender, RoutedEventArgs e)
        {
            Fournisseur pageFournisseur = new Fournisseur();
            pageFournisseur.Show();
            this.Close();
        }
        private void GoPiece(object sender, RoutedEventArgs e)
        {
            Piece pagePiece = new Piece();
            pagePiece.Show();
            this.Close();
        }
        private void GoCommande(object sender, RoutedEventArgs e)
        {
            Commande pageCommande = new Commande();
            pageCommande.Show();
            this.Close();
        }
        private void GoVelo(object sender, RoutedEventArgs e)
        {
            Velo pageVelo= new Velo();
            pageVelo.Show();
            this.Close();
        }
    }
}
