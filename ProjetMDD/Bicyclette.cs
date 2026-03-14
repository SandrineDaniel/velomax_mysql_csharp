using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMDD
{
    internal class Bicyclette
    {
        int numero;
        string nom;
        string grandeur;
        double prix_unitaire;
        DateTime date_debut;
        DateTime date_fin;
        int stockvelo;
        int id_magasin;
        string caractéristiques = "1) NUMERO\n2) NOM\n3) GRANDEUR\n4) PRIX_UNITAIRE\n5) DATE_DEBUT\n6) DATE_FIN\n7) STOCK_VELO\n8) ID_MAGASIN\n";
        string caractéristiques2 = "1) NUMERO 2) NOM 3) GRANDEUR 4) PRIX_UNITAIRE 5) DATE_DEBUT 6) DATE_FIN 7) STOCK_VELO 8) ID_MAGASIN\n";
        Connexion connexion = new Connexion();
        public Bicyclette() { }

        /// <summary>
        /// Insérer tuple à vélo
        /// </summary>
        public void Creation_VELO()
        {
            string insertTable = " INSERT INTO BICYCLETTE VALUES (";
            Console.WriteLine(caractéristiques + "  Complétez:" + insertTable);
            insertTable += Console.ReadLine() + ");";

            connexion.Command.CommandText = insertTable;
            try
            {
                connexion.Command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }
            connexion.Command.Dispose();

        }
        /// <summary>
        /// Supprimer tuple table bicyclette
        /// </summary>
        public void Suppression_Velo()
        {

            string suppression = "DELETE FROM BICYCLETTE WHERE ";
            Console.WriteLine(caractéristiques + "  Complétez:" + suppression);
            suppression += Console.ReadLine() + ");";


            connexion.Command.CommandText = suppression;

            try
            {
                connexion.Command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

        }
        /// <summary>
        /// Mise à jour de la table bicyclette
        /// </summary>
        public void Maj_velo()
        {
            Console.WriteLine("Modification: \n\nExemple: UPDATE BICYCLETTE SET NUMERO=5 WHERE STOCK_VELO=5 ");
            Console.WriteLine("Rappel des carctéristiques:" + caractéristiques + "\n\nComplétez: UPDATE BICYCLETTE SET");
            string maj = "UPDATE BICYCLETTE SET ";

            string n = Console.ReadLine();
            maj += n + " WHERE ";
            Console.WriteLine("Rappel des carctéristiques:" + caractéristiques + "\n\n" + maj);
            maj += Console.ReadLine() + ");";
            connexion.Command.CommandText = maj;
            try
            {
                connexion.Command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }


            connexion.Command.CommandText = maj;
            try
            {
                connexion.Command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }
        }
        /// <summary>
        /// Afficher la table bicyclette
        /// </summary>
        public void AfficherVelo()
        {

            string requete = "SELECT * FROM BICYCLETTE";
            connexion.Command.CommandText = requete;
            MySqlDataReader reader = connexion.Command.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            Console.WriteLine("   BICYCLETTE :\n" + caractéristiques2);
            while (reader.Read())
            {
                int numero = reader.GetInt32("numero");
                string nom = reader.GetString("nom");
                string grandeur = reader.GetString("grandeur");
                double prix_unitaire = reader.GetDouble("prix_unitaire");
                DateTime date_debut = reader.GetDateTime("date_debut");
                DateTime date_fin = reader.GetDateTime("date_fin");
                int stockvelo = reader.GetInt32("stock_velo");
                int id_magasin = reader.GetInt32("id_magasin");



                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine("\n");
            }
            reader.Close();
            connexion.Command.Dispose();
        }
    }
}
