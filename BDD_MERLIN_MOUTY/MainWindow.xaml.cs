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
        /// <summary>
        /// Charger la fenêtre Fidélio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoFidelio(object sender, RoutedEventArgs e)
        {
            Fidelio pageFidelio = new Fidelio();
            pageFidelio.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Adhésion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoAdhesion(object sender, RoutedEventArgs e)
        {
            Adhesion pageAdhesion = new Adhesion();
            pageAdhesion.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoClient(object sender, RoutedEventArgs e)
        {
            Client pageClient = new Client();
            pageClient.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Entreprise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoEntreprise(object sender, RoutedEventArgs e)
        {
            Entreprise pageEntreprise = new Entreprise();
            pageEntreprise.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoFournisseur(object sender, RoutedEventArgs e)
        {
            Fournisseur pageFournisseur = new Fournisseur();
            pageFournisseur.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Fournir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoFournir(object sender, RoutedEventArgs e)
        {
            Fournir pageFournir = new Fournir();
            pageFournir.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Pièce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoPiece(object sender, RoutedEventArgs e)
        {
            Piece pagePiece = new Piece();
            pagePiece.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Commande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoCommande(object sender, RoutedEventArgs e)
        {
            Commande pageCommande = new Commande();
            pageCommande.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Velo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoVelo(object sender, RoutedEventArgs e)
        {
            Velo pageVelo= new Velo();
            pageVelo.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Stats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoStats(object sender, RoutedEventArgs e)
        {
            Statistiques pageStats = new Statistiques();
            pageStats.Show();
            this.Close();
        }
        /// <summary>
        /// Charger la fenêtre Stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoStock(object sender, RoutedEventArgs e)
        {
            Stocks pageStocks = new Stocks();
            pageStocks.Show();
            this.Close();
        }
    }
}
