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
    /// Logique d'interaction pour Fidelio.xaml
    /// </summary>
    public partial class Fidelio : Window
    {
        //string cs = @"server=localhost;userid=test;password=password;database=VeloMax";

        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        public Fidelio()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Vide les TextBox
        /// </summary>
        private void BoxClear()
        {
            TextBoxNumProg.Text = "";
            TextBoxDescProg.Text = "";
            TextBoxCoutProg.Text = "";
            TextBoxDureeProg.Text = "";
            TextBoxRabaisProg.Text = "";
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
        /// Ajouter un nouveau programme Fidélio dans la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAjouter_Click(object sender, RoutedEventArgs e)
        {
            string numProg = TextBoxNumProg.Text;
            string descProg = TextBoxDescProg.Text;
            string coutProg = TextBoxCoutProg.Text;
            string dureeProg = TextBoxDureeProg.Text;
            string rabaisProg = TextBoxRabaisProg.Text;
            string insertQuery = $"insert into Fidelio value ({numProg},'{descProg}',{coutProg},{dureeProg},{rabaisProg})";
            ExecuteQuery(insertQuery);
            BoxClear();
        }
        /// <summary>
        /// Retirer un programme Fidélio de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numProg = row.Row.ItemArray[0].ToString();
            string insertQuery = $"delete from Fidelio where numero_programme = '{numProg}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Mettre à jour un programme fidélio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numProg = row.Row.ItemArray[0].ToString();
            string descProg = row.Row.ItemArray[1].ToString();
            string coutProg = row.Row.ItemArray[2].ToString();
            string dureeProg = row.Row.ItemArray[3].ToString();
            string rabaisProg = row.Row.ItemArray[4].ToString();
            string insertQuery = $"update Fidelio set description_programme = '{descProg}', cout_programme = '{coutProg}', duree_programme = '{dureeProg}', rabais_programme = '{rabaisProg}' where  numero_programme = '{numProg}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Afficher les différents programme fidélio disponible dans la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAfficher_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();

            MySqlCommand command = connection.CreateCommand();
            if (TextBoxNumProg.Text != "")
            {
                string numProg = TextBoxNumProg.Text;
                command.CommandText = $"select * from Fidelio where numero_programme like '%{numProg}%'";
            }
            else
            {
                command.CommandText = $"select * from Fidelio";
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
