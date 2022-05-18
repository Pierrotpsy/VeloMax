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
using Newtonsoft.Json;

namespace BDD_MERLIN_MOUTY
{
    /// <summary>
    /// Logique d'interaction pour Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        //string cs = @"server=localhost;userid=test;password=password;database=VeloMax";

        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        public Client()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Vide toutes les TextBox
        /// </summary>
        private void BoxClear()
        {
            TextBoxEmailP.Text = "";
            TextBoxNomP.Text = "";
            TextBoxPrenomP.Text = "";
            TextBoxRueP.Text = "";
            TextBoxVilleP.Text = "";
            TextBoxCodePostalP.Text = "";
            TextBoxProvinceP.Text = "";
            TextBoxTelP.Text = "";
        }
        /// <summary>
        /// Ouvre la connexion à la base de données
        /// </summary>
        public void OpenConnexion()
        {
            connection.Open();
        }
        /// <summary>
        /// Ferme la connexion à la base de données
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
        /// Ajouter un nouveau client particulier dans la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAjouter_Click(object sender, RoutedEventArgs e)
        {
            string emailP = TextBoxEmailP.Text;
            string nomP = TextBoxNomP.Text;
            string prenomP = TextBoxPrenomP.Text;
            string rueP = TextBoxRueP.Text;
            string villeP = TextBoxVilleP.Text;
            string codePostalP = TextBoxCodePostalP.Text;
            string provinceP = TextBoxProvinceP.Text;
            string telP = TextBoxTelP.Text;
            string insertQuery = $"insert into Particulier value ('{emailP}','{nomP.ToUpper()}','{prenomP}','{rueP}','{villeP}','{codePostalP}','{provinceP}','{telP}')";
            ExecuteQuery(insertQuery);
            BoxClear();
        }
        /// <summary>
        /// Retirer un client particulier dans la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string emailP = row.Row.ItemArray[0].ToString();
            string insertQuery = $"delete from Particulier where email_P = '{emailP}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Mettre à jour les infos d'un client particulier dans la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = dataGrid.SelectedItem as DataRowView;
            string emailP = row.Row.ItemArray[0].ToString();
            string nomP = row.Row.ItemArray[1].ToString();
            string prenomP = row.Row.ItemArray[2].ToString();
            string rueP = row.Row.ItemArray[3].ToString();
            string villeP = row.Row.ItemArray[4].ToString();
            string codePostalP = row.Row.ItemArray[5].ToString();
            string provinceP = row.Row.ItemArray[6].ToString();
            string telP = row.Row.ItemArray[7].ToString();
            string insertQuery= $"update Particulier set nom_P = '{nomP}', prenom_p = '{prenomP}', rue_P = '{rueP}', ville_P = '{villeP}', code_postal_P = '{codePostalP}', province_P = '{provinceP}', telephone_P = '{telP}' where email_P = '{emailP}'";
            ExecuteQuery(insertQuery);
        }
        /// <summary>
        /// Afficher les clients de la base de données 
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
                command.CommandText = $"select * from Particulier where email_P like '%{emailP}%'";
            }
            else if(TextBoxNomP.Text != "")
            {
                string nomP = TextBoxNomP.Text;
                command.CommandText = $"select * from Particulier where nom_P like '%{nomP}%'";
            }
            else if (TextBoxTelP.Text != "")
            {
                string telP = TextBoxNomP.Text;
                command.CommandText = $"select * from Particulier where telephone_P like '%{telP}%'";
            }
            else
            {
                command.CommandText = $"select * from Particulier";
            }
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            BoxClear();
            CloseConnexion();
        }
        /// <summary>
        /// Exporter un fichier JSON contenant les infos des clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonExporterJSON_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select email_P, date_adhesion,  date_add(date_adhesion, interval duree_programme year) as 'date expiration' from Fidelio natural join Adhere where date_add(date_adhesion, interval duree_programme year) < date(now() + interval 2 month)";
            string monFichier = "Programme.json";
            DataTable dt2 = new DataTable();
            dt2.Load(command.ExecuteReader());
            StreamWriter writer = new StreamWriter(monFichier);
            JsonTextWriter jwriter = new JsonTextWriter(writer);

            jwriter.WriteStartObject();
            jwriter.WritePropertyName("Fidelio");

            jwriter.WriteStartArray();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                jwriter.WriteStartObject();
                jwriter.WritePropertyName("email");
                jwriter.WriteValue(dt2.Rows[i][0]);
                jwriter.WriteEndObject();

                jwriter.WriteStartObject();
                jwriter.WritePropertyName("date_adhesion");
                jwriter.WriteValue(dt2.Rows[i][1]);
                jwriter.WriteEndObject();

                jwriter.WriteStartObject();
                jwriter.WritePropertyName("date_expiration");
                jwriter.WriteValue(dt2.Rows[i][2]);
                jwriter.WriteEndObject();
            }

            jwriter.WriteEndObject();

            jwriter.Close();
            writer.Close();
            CloseConnexion();
            MessageBox.Show("Export Réussi");
        }
        /// <summary>
        /// Retour vers le menu
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
