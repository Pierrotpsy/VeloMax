﻿using System;
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
            string insertQuery = $"insert into Particulier value ('{emailE}','{nomE}','{telE}','{nomContactE}','{prenomContactE}','{rueE}','{villeE}','{codePostalE}','{provinceE}',{remiseE})";
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
