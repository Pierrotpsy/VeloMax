// See https://aka.ms/new-console-template for more information
using MySql.Data.MySqlClient;

string cs = @"server=localhost;userid=test;password=password;database=VeloMax";

using var con = new MySqlConnection(cs);
con.Open();

string sql = "SELECT * FROM Commande";
using var cmd = new MySqlCommand(sql, con);

using MySqlDataReader rdr = cmd.ExecuteReader();

Console.WriteLine($"{rdr.GetName(0),-4} {rdr.GetName(1),-10} {rdr.GetName(2),10}");

while (rdr.Read())
{
    Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetDateTime(1), 
            rdr.GetDateTime(2));
}
