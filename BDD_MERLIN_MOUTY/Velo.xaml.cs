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
    /// Logique d'interaction pour Velo.xaml
    /// </summary>
    public partial class Velo : Window
    {
        //string cs = @"server=localhost;userid=test;password=password;database=VeloMax";

        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        public Velo()
        {
            InitializeComponent();
        }
        private void BoxClear()
        {
            TextBoxNumProdB.Text = "";
            TextBoxNomB.Text = "";
            ComboBoxTailleB.Text = "";
            TextBoxPrixB.Text = "";
            ComboBoxLigneB.Text = "";
            TextBoxDateIntroB.Text = "";
            TextBoxDateDiscB.Text = "";

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
            string numProdB = TextBoxNumProdB.Text;
            string nomB = TextBoxNomB.Text;
            string tailleB = ComboBoxTailleB.Text;
            string prixB = TextBoxPrixB.Text;
            string ligneB = ComboBoxLigneB.Text;
            string dateIntroB = TextBoxDateIntroB.Text;
            string dateDiscB = TextBoxDateDiscB.Text;
            string insertQuery = $"insert into Bicyclette value ({numProdB},'{nomB}','{tailleB}',{prixB},'{ligneB}','{dateIntroB}','{dateDiscB}')";
            ExecuteQuery(insertQuery);
            BoxClear();
        }
        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numProdB = row.Row.ItemArray[0].ToString();
            string insertQuery = $"delete from Bicyclette where numero_prod_B = '{numProdB}'";
            ExecuteQuery(insertQuery);
        }
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string numProdB = row.Row.ItemArray[0].ToString();
            string nomB = row.Row.ItemArray[1].ToString();
            string tailleB = row.Row.ItemArray[2].ToString();
            string prixB = row.Row.ItemArray[3].ToString();
            string ligneB = row.Row.ItemArray[4].ToString();
            string insertQuery = $"update Bicyclette set nom_B = '{nomB}', grandeur_B = '{tailleB}', prix_B = '{prixB}', ligne_produit_B = '{ligneB}' where numero_prod_B = '{numProdB}'";
            ExecuteQuery(insertQuery);
        }
        private void BouttonAfficher_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();

            MySqlCommand command = connection.CreateCommand();
            if (TextBoxNumProdB.Text != "")
            {
                string numProdB = TextBoxNumProdB.Text;
                command.CommandText = $"select * from Bicyclette where numero_prod_B like '%{numProdB}%'";
            }
            else if(TextBoxNomB.Text != "")
            {
                string nomB = TextBoxNomB.Text;
                command.CommandText = $"select * from Bicyclette where nom_B like '%{nomB}%'";
            }
            else if (ComboBoxTailleB.Text != "")
            {
                string tailleB = ComboBoxTailleB.Text;
                command.CommandText = $"select * from Bicyclette where grandeur_B = '{tailleB}'";
            }
            else if (ComboBoxLigneB.Text != "")
            {
                string ligneB = ComboBoxLigneB.Text;
                command.CommandText = $"select * from Bicyclette where ligne_produit_B = '{ligneB}'";
            }
            else
            {
                command.CommandText = $"select * from Bicyclette";
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
