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
    /// Logique d'interaction pour Piece.xaml
    /// </summary>
    public partial class Piece : Window
    {
        //string cs = @"server=localhost;userid=test;password=password;database=VeloMax";

        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        public Piece()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Vide les TextBox
        /// </summary>
        private void BoxClear()
        {
            TextBoxNumProdP.Text = "";
            TextBoxDescProdP.Text = "";
            TextBoxDateIntroP.Text = "";
            TextBoxDateDiscP.Text = "";
            TextBoxQuantiteP.Text = "";
            ComboBoxType.Text = "";
            TextBoxPrixP.Text = "";

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
        /// Ajouter une pièce à la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAjouter_Click(object sender, RoutedEventArgs e)
        {
            string numProdP = TextBoxNumProdP.Text;
            string descProdP = TextBoxDescProdP.Text;
            string dateIntroP = TextBoxDateIntroP.Text;
            string dateDiscP = TextBoxDateDiscP.Text;
            string quantiteP = TextBoxQuantiteP.Text;
            string typeP = ComboBoxType.Text;
            string prixP = TextBoxPrixP.Text;
            string insertQuery = $"insert into Pièce value ({numProdP},'{descProdP}','{dateIntroP}','{dateDiscP}',{quantiteP},'{typeP}',{prixP})";
            ExecuteQuery(insertQuery);
            BoxClear();
        }
        /// <summary>
        /// Retirer une pièce de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numProdP = row.Row.ItemArray[0].ToString();
            string insertQuery = $"delete from Pièce where numero_prod_P = '{numProdP}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Mettre à jour les infos d'une pièce dans la base de données 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numProdP = row.Row.ItemArray[0].ToString();
            string descProdP = row.Row.ItemArray[1].ToString();
            string dateIntroP = row.Row.ItemArray[2].ToString();
            string dateDiscP = row.Row.ItemArray[3].ToString();
            string quantiteP = row.Row.ItemArray[4].ToString();
            string typeP = row.Row.ItemArray[5].ToString();
            string prixP = row.Row.ItemArray[6].ToString();
            //date_intro_P = '{dateIntroP}', date_disc_P = '{dateDiscP}'
            string insertQuery = $"update Pièce set desc_prod_P = '{descProdP}', quantite_P = '{quantiteP}', type_P = '{typeP}', prix_P = '{prixP}' where numero_prod_P = '{numProdP}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Afficher les pièces de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAfficher_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();

            MySqlCommand command = connection.CreateCommand();
            if (TextBoxNumProdP.Text != "")
            {
                string numProdP = TextBoxNumProdP.Text;
                command.CommandText = $"select * from Pièce where numero_prod_P like '%{numProdP}%'";
            }
            else if (ComboBoxType.Text != "")
            {
                string typeP = ComboBoxType.Text;
                command.CommandText = $"select * from Pièce where type_P like '%{typeP}%'";
            }
            else
            {
                command.CommandText = $"select * from Pièce";
            }
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            BoxClear();
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
