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
    /// Logique d'interaction pour Fournir.xaml
    /// </summary>
    public partial class Fournir : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        public Fournir()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Vide les TextBox
        /// </summary>
        private void BoxClear()
        {
            TextBoxSiretF.Text = "";
            TextBoxNumProdP.Text = "";
            TextBoxNumProdF.Text = "";
            TextBoxNomF.Text = "";
            TextBoxDelaiF.Text = "";
            TextBoxPrixF.Text = "";
        }
        /// <summary>
        /// Ouvre la connexion avec la base de données
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
        /// Ajouter des pièces fournies par un fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAjouter_Click(object sender, RoutedEventArgs e)
        {
            string siretF = TextBoxSiretF.Text;
            string numProdP = TextBoxNumProdP.Text;
            string numProdF = TextBoxNumProdF.Text;
            string nomF = TextBoxNomF.Text;
            string delaiF = TextBoxDelaiF.Text;
            string prixF = TextBoxPrixF.Text;
            string insertQuery = $"insert into Fourni value ({siretF},{numProdP},{numProdF},'{nomF}',{delaiF},{prixF})";
            ExecuteQuery(insertQuery);
            BoxClear();
        }
        /// <summary>
        /// Retirer des pièces fournis par un fournisseur 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string siretF = row.Row.ItemArray[0].ToString();
            string numProdP = row.Row.ItemArray[1].ToString();
            string insertQuery = $"delete from Fourni where siret_F = '{siretF}' and numero_prod_P = '{numProdP}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Mettre à jour les pièces fournies par un fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string siretF = row.Row.ItemArray[0].ToString();
            string numProdP = row.Row.ItemArray[1].ToString();
            string numProdF = row.Row.ItemArray[2].ToString();
            string nomF = row.Row.ItemArray[3].ToString();
            string delaiF = row.Row.ItemArray[4].ToString();
            string prixF = row.Row.ItemArray[5].ToString();
            string insertQuery = $"update Fourni set numero_prod_F = '{numProdF}', nom_fournisseur_P = '{nomF}', delai_F = '{delaiF}', prix_F = '{prixF}' where siret_F = '{siretF}' and numero_prod_P='{numProdP}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Afficher les pièces fournies par un fournisseur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAfficher_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            if (TextBoxSiretF.Text != "")
            {
                string siretF = TextBoxSiretF.Text;
                command.CommandText = $"select * from Fourni where siret_F like '%{siretF}%'";
            }
            else if (TextBoxNumProdP.Text != "")
            {
                string numProdP = TextBoxNumProdP.Text;
                command.CommandText = $"select * from Fourni where numero_prod_P like '%{numProdP}%'";
            }
            else if (TextBoxNumProdF.Text != "")
            {
                string numProdF = TextBoxNumProdF.Text;
                command.CommandText = $"select * from Fourni where numero_prod_F like '%{numProdF}%'";
            }
            else if (TextBoxNomF.Text != "")
            {
                string nomF = TextBoxNomF.Text;
                command.CommandText = $"select * from Fourni where nom_fournisseur_P like '%{nomF}%'";
            }
            else
            {
                command.CommandText = $"select * from Fourni";
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
