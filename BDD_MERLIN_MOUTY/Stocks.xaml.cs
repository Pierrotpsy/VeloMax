using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml;

namespace BDD_MERLIN_MOUTY
{
    /// <summary>
    /// Logique d'interaction pour Stocks.xaml
    /// </summary>
    public partial class Stocks : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");

        /// <summary>
        /// Initialise la fenêtre stock
        /// </summary>
        public Stocks()
        {
            InitializeComponent();
            BouttonAfficherStockFaible.Visibility = Visibility.Hidden;
            BouttonExporterXMLStockFaibles.Visibility = Visibility.Hidden;
            BouttonPiècesOrderByPrix.Visibility = Visibility.Hidden;
            BouttonPiècesOrderByDateDisc.Visibility = Visibility.Hidden;
            TextBlockTypePiece.Visibility = Visibility.Hidden;
            ComboBoxTypePiece.Visibility = Visibility.Hidden;
            AfficherTypePièce.Visibility = Visibility.Hidden;
            BouttonFournisseursOrderByDelaiF.Visibility = Visibility.Hidden;
            BouttonFournisseursOrderByLibelleF.Visibility = Visibility.Hidden;
            BouttonVelosOrderByPrixB.Visibility = Visibility.Hidden;
            BouttonVelosOrderByGrandeurB.Visibility = Visibility.Hidden;
            TextBlockLigneProduit.Visibility = Visibility.Hidden;
            ComboBoxLigneProduit.Visibility = Visibility.Hidden;
            AfficherLigneProduit.Visibility = Visibility.Hidden;
            TextBlockGrandeur.Visibility = Visibility.Hidden;
            ComboBoxGrandeur.Visibility = Visibility.Hidden;
            AfficherGrandeur.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// ouvre la connexion avec la base de données
        /// </summary>
        public void OpenConnexion()
        {
            connection.Open();
        }
        /// <summary>
        /// Ferme la connexion avec la base de données
        /// </summary>
        public void CloseConnexion()
        {
            connection.Close();
        }
        /// <summary>
        /// Affiche les bouttons nécessaire pour le stock pièce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonStockP_Click(object sender, RoutedEventArgs e)
        {
            BouttonAfficherStockFaible.Visibility = Visibility.Hidden;
            BouttonExporterXMLStockFaibles.Visibility = Visibility.Hidden;
            BouttonFournisseursOrderByDelaiF.Visibility = Visibility.Hidden;
            BouttonFournisseursOrderByLibelleF.Visibility = Visibility.Hidden;
            BouttonVelosOrderByPrixB.Visibility = Visibility.Hidden;
            BouttonVelosOrderByGrandeurB.Visibility = Visibility.Hidden;
            TextBlockLigneProduit.Visibility = Visibility.Hidden;
            ComboBoxLigneProduit.Visibility = Visibility.Hidden;
            AfficherLigneProduit.Visibility = Visibility.Hidden;
            TextBlockGrandeur.Visibility = Visibility.Hidden;
            ComboBoxGrandeur.Visibility = Visibility.Hidden;
            AfficherGrandeur.Visibility = Visibility.Hidden;

            BouttonPiècesOrderByPrix.Visibility = Visibility.Visible;
            BouttonPiècesOrderByDateDisc.Visibility = Visibility.Visible;
            TextBlockTypePiece.Visibility = Visibility.Visible;
            ComboBoxTypePiece.Visibility = Visibility.Visible;
            AfficherTypePièce.Visibility = Visibility.Visible;            
        }
        /// <summary>
        /// Affiche les bouttons nécessaire pour le stock vélos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonStockV_Click(object sender, RoutedEventArgs e)
        {
            BouttonAfficherStockFaible.Visibility = Visibility.Hidden;
            BouttonExporterXMLStockFaibles.Visibility = Visibility.Hidden;
            BouttonPiècesOrderByPrix.Visibility = Visibility.Hidden;
            BouttonPiècesOrderByDateDisc.Visibility = Visibility.Hidden;
            TextBlockTypePiece.Visibility = Visibility.Hidden;
            ComboBoxTypePiece.Visibility = Visibility.Hidden;
            AfficherTypePièce.Visibility = Visibility.Hidden;
            BouttonFournisseursOrderByDelaiF.Visibility = Visibility.Hidden;
            BouttonFournisseursOrderByLibelleF.Visibility = Visibility.Hidden;

            BouttonVelosOrderByPrixB.Visibility = Visibility.Visible;
            BouttonVelosOrderByGrandeurB.Visibility = Visibility.Visible;
            TextBlockLigneProduit.Visibility = Visibility.Visible;
            ComboBoxLigneProduit.Visibility = Visibility.Visible;
            AfficherLigneProduit.Visibility = Visibility.Visible;
            TextBlockGrandeur.Visibility = Visibility.Visible;
            ComboBoxGrandeur.Visibility = Visibility.Visible;
            AfficherGrandeur.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Affiche les boutons necéssaire pour le stock fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonStockF_Click(object sender, RoutedEventArgs e)
        {
            BouttonAfficherStockFaible.Visibility = Visibility.Hidden;
            BouttonExporterXMLStockFaibles.Visibility = Visibility.Hidden;
            BouttonPiècesOrderByPrix.Visibility = Visibility.Hidden;
            BouttonPiècesOrderByDateDisc.Visibility = Visibility.Hidden;
            TextBlockTypePiece.Visibility = Visibility.Hidden;
            ComboBoxTypePiece.Visibility = Visibility.Hidden;
            AfficherTypePièce.Visibility = Visibility.Hidden;
            BouttonVelosOrderByPrixB.Visibility = Visibility.Hidden;
            BouttonVelosOrderByGrandeurB.Visibility = Visibility.Hidden;
            TextBlockLigneProduit.Visibility = Visibility.Hidden;
            ComboBoxLigneProduit.Visibility = Visibility.Hidden;
            AfficherLigneProduit.Visibility = Visibility.Hidden;
            TextBlockGrandeur.Visibility = Visibility.Hidden;
            ComboBoxGrandeur.Visibility = Visibility.Hidden;
            AfficherGrandeur.Visibility = Visibility.Hidden;

            BouttonFournisseursOrderByDelaiF.Visibility = Visibility.Visible;
            BouttonFournisseursOrderByLibelleF.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Affiche les bouttons nécessaire pour le stock faible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonStocksFaibles_Click(object sender, RoutedEventArgs e)
        {
            BouttonPiècesOrderByPrix.Visibility = Visibility.Hidden;
            BouttonPiècesOrderByDateDisc.Visibility = Visibility.Hidden;
            TextBlockTypePiece.Visibility = Visibility.Hidden;
            ComboBoxTypePiece.Visibility = Visibility.Hidden;
            AfficherTypePièce.Visibility = Visibility.Hidden;
            BouttonFournisseursOrderByDelaiF.Visibility = Visibility.Hidden;
            BouttonFournisseursOrderByLibelleF.Visibility = Visibility.Hidden;
            BouttonVelosOrderByPrixB.Visibility = Visibility.Hidden;
            BouttonVelosOrderByGrandeurB.Visibility = Visibility.Hidden;
            TextBlockLigneProduit.Visibility = Visibility.Hidden;
            ComboBoxLigneProduit.Visibility = Visibility.Hidden;
            AfficherLigneProduit.Visibility = Visibility.Hidden;
            TextBlockGrandeur.Visibility = Visibility.Hidden;
            ComboBoxGrandeur.Visibility = Visibility.Hidden;
            AfficherGrandeur.Visibility = Visibility.Hidden;

            BouttonAfficherStockFaible.Visibility = Visibility.Visible;
            BouttonExporterXMLStockFaibles.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Trier les pièces par prix croissant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonPièceOrderByPrix_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from pièce order by prix_P";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Trier les pièces par date de discontinuité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonPièceOrderByDateDisc_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from pièce order by date_disc_P";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Affiche les pièces selon le type sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAfficherTypePiece_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            if (ComboBoxTypePiece.Text != "All")
            {
                command.CommandText = $"select * from pièce where type_P = '{ComboBoxTypePiece.Text}'";
            }
            else
            {
                command.CommandText = $"select * from pièce";
            }
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Trier les vélos par prix croissant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonVelosOrderByPrixB_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from bicyclette order by prix_B";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Trier les velos par taille 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonVelosOrderByGrandeurB_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from bicyclette order by grandeur_B";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Afficher les vélos selon la ligne produit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAfficherLigneProduit_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            if (ComboBoxLigneProduit.Text != "All")
            {
                command.CommandText = $"select * from bicyclette where ligne_produit_B = '{ComboBoxLigneProduit.Text}'";
            }
            else
            {
                command.CommandText = $"select * from bicyclette";
            }
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Afficher les vélos selon la taille
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAfficherGrandeur_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            if (ComboBoxGrandeur.Text != "All")
            {
                command.CommandText = $"select * from bicyclette where grandeur_B = '{ComboBoxGrandeur.Text}'";
            }
            else
            {
                command.CommandText = $"select * from bicyclette";
            }
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Trier les pièces fournies par les fournisseurs selon les délais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonFournisseursOrderByDelaiF_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select nom_F, libelle_F, numero_prod_P, numero_prod_F, delai_F, prix_F from fournisseur, fourni order by delai_F";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Trier les pièces fournies par les fournisseurs selon leur libelle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonFournisseursOrderByLibelleF_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select nom_F, libelle_F, numero_prod_P, numero_prod_F, delai_F, prix_F  from fournisseur, fourni order by libelle_F";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Afficher les pièces dont le sotck est faible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAfficherStocksFaibles_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select type_P, numero_prod_P, desc_prod_P, quantite_P as 'Stock disponible' from Pièce where quantite_p <=2";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Exporter le XML des stocks faibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonExporterXMLStocksFaibles_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select numero_prod_P, desc_prod_P, quantite_P as 'Stock disponible' from Pièce where quantite_p <=2";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            XmlDocument docXml = new XmlDocument();

            XmlElement root = docXml.CreateElement("StockFaible");
            docXml.AppendChild(root);

            XmlDeclaration xmldecl = docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");
            docXml.InsertBefore(xmldecl, root);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XmlElement num = docXml.CreateElement("numero");
                num.InnerText = Convert.ToString(dt.Rows[i][0]);
                root.AppendChild(num);
                XmlElement desc = docXml.CreateElement("description");
                desc.InnerText = Convert.ToString(dt.Rows[i][1]);
                root.AppendChild(desc);
                XmlElement quantite = docXml.CreateElement("quantite");
                quantite.InnerText = Convert.ToString(dt.Rows[i][2]);
                root.AppendChild(quantite);
            }
            docXml.Save("StockFaible.xml");
            MessageBox.Show("Export réussi");
            CloseConnexion();
        }
        /// <summary>
        /// Retour au menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
