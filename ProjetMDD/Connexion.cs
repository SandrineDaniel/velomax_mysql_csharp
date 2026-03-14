using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ProjetMDD
{
    internal class Connexion
    {
        string connexionString;
        MySqlConnection maConnexion = null;
        MySqlCommand command;
        MySqlCommand command2;
        string connexionString2;
        public Connexion() {         //Connexion root

            try
            {
                connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=velomax;" +
                                         "UID=root;PASSWORD=root";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            command = maConnexion.CreateCommand();
        }
        public Connexion(int n) //Connexion bozo
        {
            try
            {
                connexionString2 = "SERVER=localhost;PORT=3306;" +
                          "DATABASE=velomax;" +
                          "UID=bozo;PASSWORD=bozo";

                maConnexion = new MySqlConnection(connexionString2);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            command2 = maConnexion.CreateCommand();
        }
        public MySqlCommand Command{
            get { return command; }
            set { command = value; }
            }
        public MySqlCommand Command2
        {
            get { return command2; }
            set { command2 = value; }
        }
  
        public string ConnexionString
        { get { return connexionString; } set { connexionString = value; } }

        public string ConnexionString2
        { get { return connexionString2; } set { connexionString2 = value; } }
        public MySqlConnection MaConnexion { get { return maConnexion; } }
        
    }
}
