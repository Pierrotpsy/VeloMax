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
using System.Xml;

namespace BDD_MERLIN_MOUTY
{
    /// <summary>
    /// Logique d'interaction pour Statistiques.xaml
    /// </summary>
    public partial class Statistiques : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER=localhost;userid=test;password=password;DATABASE=VeloMax");
        /// <summary>
        /// Initialise la page et calcule les statistiques demandées
        /// </summary>
        public Statistiques()
        {
            InitializeComponent();
            OpenConnexion();
            MySqlCommand stat1 = connection.CreateCommand();
            stat1.CommandText = $"select avg(quantite_commande_P)  from contient_P";
            Stats1.Text = $"Quantité moyenne \nde pièces commandées : \n{GetStringFromResquest(stat1)}";
            CloseConnexion();
            OpenConnexion();
            MySqlCommand stat2 = connection.CreateCommand();
            stat2.CommandText = $"select avg(quantite_commande_B) from contient_B";
            Stats2.Text = $"Quantité moyenne \nde vélos commandés : \n{GetStringFromResquest(stat2)}";
            CloseConnexion();
        }
        /// <summary>
        /// Transforme le retour de la requête en string
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string GetStringFromResquest(MySqlCommand command)
        {
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            string a = "";
            while (reader.Read())
            {
                a = reader.GetString(0);
            }
            return a;
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
        /// <param name="query">Requête à executer </param>
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
            }
            finally
            {
                CloseConnexion();
            }
        }
        /// <summary>
        /// Affiche les clients des différents programmes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonAfficherProgramme_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            if (ComboBoxProgramme.Text == "Fidelio")
            {
                command.CommandText = "select email_P,  description_programme from Fidelio natural join Adhere where description_programme = 'Fidelio'";
            }
            else if(ComboBoxProgramme.Text == "Fidelio Or")
            {
                command.CommandText = "select email_P,  description_programme from Fidelio natural join Adhere where description_programme = 'Fidelio Or'";
            }
            else if (ComboBoxProgramme.Text == "Fidelio Platine")
            {
                command.CommandText = "select email_P,  description_programme from Fidelio natural join Adhere where description_programme = 'Fidelio Platine'";
            }
            else if (ComboBoxProgramme.Text == "Fidelio Max")
            {
                command.CommandText = "select email_P,  description_programme from Fidelio natural join Adhere where description_programme = 'Fidelio Max'";
            }
            else { 
                command.CommandText= "select email_P,  description_programme from Fidelio natural join Adhere order by description_programme";
            }
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Affiche les clients dont le programme arrive à expiration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonDateExpiration_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select email_P,  description_programme, date_add(date_adhesion, interval duree_programme year) as 'date expiration' from Fidelio natural join Adhere";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Affiche les meilleurs clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMeilleursClients_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"(select email_P, sum(quantite_commande_P)*prix_F from Particulier natural join Commande natural join contient_P natural join Fourni group by email_P union select email_P, sum(quantite_commande_B)*prix_B from Particulier natural join Commande natural join contient_B natural join Bicyclette group by email_P union select email_E, sum(quantite_commande_P)*prix_F from Entreprise natural join Commande natural join contient_P natural join Fourni group by email_E union select email_E, sum(quantite_commande_B)*prix_B from Entreprise natural join Commande natural join contient_B natural join Bicyclette group by email_E)";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnexion();
        }
        /// <summary>
        /// Exporter un XML contenant les clients adhérant à un programme et leur date d'expiration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonExportXML_Click(object sender, RoutedEventArgs e)
        {
            OpenConnexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select email_P,  date_add(date_adhesion, interval duree_programme year) as 'date expiration' from Fidelio natural join Adhere";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            XmlDocument docXml = new XmlDocument();

            XmlElement root = docXml.CreateElement("Programme_Fidelite");
            docXml.AppendChild(root);

            XmlDeclaration xmldecl = docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");
            docXml.InsertBefore(xmldecl, root);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XmlElement balisetest = docXml.CreateElement("couriel");
                balisetest.InnerText = Convert.ToString(dt.Rows[i][0]);
                root.AppendChild(balisetest);
                XmlElement no_programme = docXml.CreateElement("Date_expiration");
                no_programme.InnerText = Convert.ToString(dt.Rows[i][1]);
                root.AppendChild(no_programme);
            }
            docXml.Save("Programme_Fidelite.xml");
            MessageBox.Show("Export réussi");
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
