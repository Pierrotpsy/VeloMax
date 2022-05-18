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
    /// Logique d'interaction pour Adhesion.xaml
    /// </summary>
    public partial class Adhesion : Window
    {
        //string cs = @"server=localhost;userid=test;password=password;database=VeloMax";

        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        public Adhesion()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Vide toutes les TextBox
        /// </summary>
        private void BoxClear()
        {
            TextBoxEmailP.Text = "";
            TextBoxNumeroProgramme.Text = "";
            TextBoxDateAdhesion.Text = "";
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
        /// <param name="query"> requête à executer </param>
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
        /// Permet d'ajouter un client à un programme fidélio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAjouter_Click(object sender, RoutedEventArgs e)
        {
            string emailP = TextBoxEmailP.Text;
            string numprog = TextBoxNumeroProgramme.Text;
            string date = TextBoxDateAdhesion.Text;
            string insertQuery = $"insert into Adhere value ('{numprog}','{emailP}','{date}')";
            ExecuteQuery(insertQuery);
            BoxClear();
        }
        /// <summary>
        /// Permet de retirer un client d'un programme fidélio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numProg = row.Row.ItemArray[0].ToString();
            string emailP = row.Row.ItemArray[1].ToString();
            string insertQuery = $"delete from Adhere where email_P = '{emailP}' and numero_programme = '{numProg}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Permet de mettre à jour un programme fidélio pour un client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numProg = row.Row.ItemArray[0].ToString();
            string emailP = row.Row.ItemArray[1].ToString();
            string date = row.Row.ItemArray[2].ToString();
            string insertQuery = $"update Adhere set numero_programme = '{numProg}' where email_P = '{emailP}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Permet d'afficher les clients ne fonction de la variable voulue (email, n° programme, tous)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAfficher_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            if (TextBoxEmailP.Text != "")
            {
                string emailP = TextBoxEmailP.Text;
                command.CommandText = $"select * from Adhere where email_P like '%{emailP}%'";
            }
            else if(TextBoxNumeroProgramme.Text != ""){
                string numProg = TextBoxNumeroProgramme.Text;
                command.CommandText = $"select * from Adhere where numero_programme like '%{numProg}%'";
            }
            else
            {
                command.CommandText = $"select * from Adhere";
            }
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            BoxClear();
            CloseConnexion();
        }
        /// <summary>
        /// Permet de revenir au menu
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
