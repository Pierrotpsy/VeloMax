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
    /// Logique d'interaction pour Fournisseur.xaml
    /// </summary>
    public partial class Fournisseur : Window
    {
        //string cs = @"server=localhost;userid=test;password=password;database=VeloMax";

        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        public Fournisseur()
        {
            InitializeComponent();
        }
        private void BoxClear()
        {
            TextBoxSiretF.Text="";
            TextBoxNomF.Text="";
            TextBoxContactF.Text="";
            TextBoxAdresseF.Text="";
            TextBoxLibelleF.Text="";
        }
        public void OpenConnexion()
        {
            connection.Open();
        }
        public void CloseConnexion()
        {
            connection.Close();
        }
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
        private void BouttonAjouter_Click(object sender, RoutedEventArgs e)
        {
            string siretF = TextBoxSiretF.Text;
            string nomF = TextBoxNomF.Text;
            string contactF = TextBoxContactF.Text;
            string adresseF = TextBoxAdresseF.Text;
            string libelleF = TextBoxLibelleF.Text;
            string insertQuery = $"insert into Fournisseur value ('{siretF}','{nomF}','{contactF}','{adresseF}',{libelleF})";
            BoxClear();
            ExecuteQuery(insertQuery);
        }
        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
        }
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
        }
        private void BouttonAfficher_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();

            MySqlCommand command = connection.CreateCommand();
            if (TextBoxSiretF.Text != "")
            {
                string siretF = TextBoxSiretF.Text;
                command.CommandText = $"select * from Fournisseur where siret_F like '%{siretF}%'";
            }
            else if (TextBoxNomF.Text != "")
            {
                string nomF = TextBoxNomF.Text;
                command.CommandText = $"select * from Fournisseur where nom_F like '%{nomF}%'";
            }
            else
            {
                command.CommandText = $"select * from Fournisseur";
            }
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            BoxClear();
            CloseConnexion();
        }
        private void BouttonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
