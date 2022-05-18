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
    /// Logique d'interaction pour Entreprise.xaml
    /// </summary>
    public partial class Entreprise : Window
    {
        //string cs = @"server=localhost;userid=test;password=password;database=VeloMax";

        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        public Entreprise()
        {
            InitializeComponent();
        }
        private void BoxClear()
        {
            TextBoxEmailE.Text = "";
            TextBoxNomE.Text = "";
            TextBoxTelE.Text = "";
            TextBoxNomContactE.Text = "";
            TextBoxPrenomContactE.Text = "";
            TextBoxRueE.Text = "";
            TextBoxVilleE.Text = "";
            TextBoxCodePostalE.Text = "";
            TextBoxProvinceE.Text = "";
            TextBoxRemiseE.Text = "";
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
            string emailE = TextBoxEmailE.Text;
            string nomE = TextBoxNomE.Text;
            string telE = TextBoxTelE.Text;
            string nomContactE = TextBoxNomContactE.Text;
            string prenomContactE = TextBoxPrenomContactE.Text;
            string rueE = TextBoxRueE.Text;
            string villeE = TextBoxVilleE.Text;
            string codePostalE = TextBoxCodePostalE.Text;
            string provinceE = TextBoxProvinceE.Text;
            string remiseE = TextBoxRemiseE.Text;
            string insertQuery = $"insert into Entreprise value ('{emailE}','{nomE}','{telE}','{nomContactE}','{prenomContactE}','{rueE}','{villeE}','{codePostalE}','{provinceE}',{remiseE})";
            ExecuteQuery(insertQuery);
            BoxClear();
        }
        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string emailE = row.Row.ItemArray[0].ToString();
            string insertQuery = $"delete from Entreprise where email_E = '{emailE}'";
            ExecuteQuery(insertQuery);
        }
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string emailE = row.Row.ItemArray[0].ToString();
            string nomE = row.Row.ItemArray[1].ToString();
            string telE = row.Row.ItemArray[2].ToString();
            string nomContactE = row.Row.ItemArray[3].ToString();
            string prenomContactE = row.Row.ItemArray[4].ToString();
            string rueE = row.Row.ItemArray[5].ToString();
            string villeE = row.Row.ItemArray[6].ToString();
            string codePostalE = row.Row.ItemArray[7].ToString();
            string provinceE = row.Row.ItemArray[8].ToString();
            string remiseE = row.Row.ItemArray[9].ToString();
            string insertQuery = $"update Entreprise set nom_E = '{nomE}', telephone_E = '{telE}', nom_contact_E = '{nomContactE}', prenom_contact_E = '{prenomContactE}', rue_E = '{rueE}', ville_E = '{villeE}', code_postal_E = '{codePostalE}', province_E = '{provinceE}', remise_E = '{remiseE}' where email_E = '{emailE}'";
            ExecuteQuery(insertQuery);
        }
        private void BouttonAfficher_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();

            MySqlCommand command = connection.CreateCommand();
            if (TextBoxEmailE.Text != "")
            {
                string emailE = TextBoxEmailE.Text;
                command.CommandText = $"select * from Entreprise where email_E like '%{emailE}%'";
            }
            else if(TextBoxNomE.Text != "")
            {
                string nomE = TextBoxNomE.Text;
                command.CommandText = $"select * from Entreprise where nom_E like '%{nomE}%'";
            }
            else
            {
                command.CommandText = $"select * from Entreprise";
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
