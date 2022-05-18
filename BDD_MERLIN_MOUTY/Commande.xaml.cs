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

namespace BDD_MERLIN_MOUTY
{
    /// <summary>
    /// Logique d'interaction pour Commande.xaml
    /// </summary>
    public partial class Commande : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        bool isBike = false;
        public Commande()
        {
            InitializeComponent();
            AfficherCommande();
        }
        /// <summary>
        /// Vide les TextBox
        /// </summary>
        private void BoxClear()
        {
            TextBoxNumCommande.Text = "";
            TextBoxDateCommande.Text = "";
            TextBoxDateLivraison.Text = "";
            TextBoxAdresseLivraison.Text = "";
            TextBoxEmailE.Text = "";
            TextBoxEmailP.Text = "";
        }
        /// <summary>
        /// Ouvre la connexion avec la base de données
        /// </summary>
        public void OpenConnexion()
        {
            connection.Open();
        }
        /// <summary>
        /// Ferme la conenxion avec la base de données
        /// </summary>
        public void CloseConnexion()
        {
            connection.Close();
        }
        /// <summary>
        /// Execute la requête demandée si possible ou retourne l'erreur
        /// </summary>
        /// <param name="query"> Requête à executer </param>
        public void ExecuteQuery(String query)
        {
            try
            {
                OpenConnexion();

                MySqlCommand command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Opération exécutée");
                }
                else
                {
                    MessageBox.Show("Opération non exécutée");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : " + ex.Message);
                BoxClear();
            }
            finally
            {
                CloseConnexion();
            }
        }
        /// <summary>
        /// Permet d'afficher la liste des commandes 
        /// </summary>
        private void AfficherCommande()
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Commande";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            BoxClear();
            CloseConnexion();
        }
        /// <summary>
        /// Permet d'afficher le catalogue des pièces
        /// </summary>
        private void AfficherPièce()
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Pièce";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid2.DataContext = dt;
            BoxClear();
            CloseConnexion();
        }
        /// <summary>
        /// Permet d'afficher le catalogue des vélos
        /// </summary>
        private void AfficherVélos()
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Bicyclette";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid2.DataContext = dt;
            BoxClear();
            CloseConnexion();
        }
        /// <summary>
        /// Permet d'ajouter une commande à la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAjouter_Click(object sender, RoutedEventArgs e)
        {
            string numCommande = TextBoxNumCommande.Text;
            string dateCommande = TextBoxDateCommande.Text;
            string dateLivraison = TextBoxDateLivraison.Text;
            string adresseLivraison = TextBoxAdresseLivraison.Text;
            string emailE = "";
            string emailP = "";
            string insertQuery = "";
            if(TextBoxEmailE.Text != "" && TextBoxEmailP.Text != "")
            {
                emailE = TextBoxEmailE.Text;
                emailP = TextBoxEmailP.Text;

                insertQuery = $"insert into Commande value ('{numCommande}','{dateCommande}','{dateLivraison}','{adresseLivraison}','{emailE}','{emailP}')";
            }
            else
            {
                if(TextBoxEmailE.Text == "")
                {
                    emailE = null;
                    emailP = TextBoxEmailP.Text;
                    insertQuery = $"insert into Commande value ('{numCommande}','{dateCommande}','{dateLivraison}','{adresseLivraison}', null,'{emailP}')";
                }
                else
                {
                    emailE = TextBoxEmailE.Text;
                    emailP = null;
                    insertQuery = $"insert into Commande value ('{numCommande}','{dateCommande}','{dateLivraison}','{adresseLivraison}','{emailE}', null)";
                }
            }
            ExecuteQuery(insertQuery);
            BoxClear();
            AfficherCommande();
        }
        /// <summary>
        /// Permet de retirer une commande de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numeroC = row.Row.ItemArray[0].ToString();
            string insertQuery = $"delete from Commande where numero_C = '{numeroC}'";
            ExecuteQuery(insertQuery);
            AfficherCommande();
        }
        /// <summary>
        /// Permet de mettre à jour une commande 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numCommande = row.Row.ItemArray[0].ToString();
            string dateCommande = row.Row.ItemArray[0].ToString();
            string dateLivraison = row.Row.ItemArray[0].ToString();
            string adresseLivraison = row.Row.ItemArray[0].ToString();
            //date_C = '{dateCommande}', date_livraison_C = '{dateLivraison}', 
            string insertQuery = $"update Commande set adresse_livraison_C = '{adresseLivraison}' where numero_C = '{numCommande}'";
            ExecuteQuery(insertQuery);
            AfficherCommande();
        }
        /// <summary>
        /// Permet d'afficher le contenu d'une commande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonInfoCommande_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numCommande = row.Row.ItemArray[0].ToString();
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from contient_P natural join Pièce where numero_C = '{numCommande}' union select * from contient_B  natural join Bicyclette where numero_C = '{numCommande}'";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid2.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Affiche le catalogue des pièces
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonInfoPiece_Click(object sender, RoutedEventArgs e)
        {
            AfficherPièce();
            isBike = false;
        }
        /// <summary>
        /// Affiche le catalogue des vélos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonInfoVelo_Click(object sender, RoutedEventArgs e)
        {
            AfficherVélos();
            isBike = true;
        }
        /// <summary>
        /// Permet de commander des pièces ou des vélos et de les ajouter à la commande
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonCommander_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numCommande = row.Row.ItemArray[0].ToString();
            string quantite = TextBoxQuantiteC.Text;
            string insertQuery = "";
            if (!isBike)
            {
                DataRowView row2 = dataGrid2.SelectedItem as DataRowView;
                string numeroProdP = row2.Row.ItemArray[0].ToString();
                string quantiteP = row2.Row.ItemArray[4].ToString();
                insertQuery = $"insert into contient_P value ('{numeroProdP}','{numCommande}','{quantite}')";
                ExecuteQuery(insertQuery);
                insertQuery = $"update Pièce set quantite_P = '{Convert.ToInt32(quantiteP)-Convert.ToInt32(quantite)}' where numero_prod_P = '{numeroProdP}'";
                ExecuteQuery(insertQuery);
                AfficherPièce();
            }
            else
            {
                DataRowView row2 = dataGrid2.SelectedItem as DataRowView;
                string numero_prod_B = row2.Row.ItemArray[0].ToString();
                insertQuery = $"insert into contient_B value ('{numero_prod_B}','{numCommande}','{quantite}')";
                ExecuteQuery(insertQuery);
                AfficherVélos();
            }
            
            TextBoxQuantiteC.Text = "";
            AfficherCommande();
        }
        /// <summary>
        /// Retour au menu principal
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
