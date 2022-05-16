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
        private void BouttonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
