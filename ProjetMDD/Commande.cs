using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetMDD
{
    internal class Commande
    {
        int idcommande;
        int idclient;
        int idsalarie;
        DateTime datecommande;
        DateTime dateLivraison;
        string adresse;
        double prix;
        string caractéristiques = "1) Id Commande\n2) Id Client\n3) Id Salarié\n4) Date de Commzande\n5) Date de livraison\n6) adresse\n7) prix";
        string caractéristiques2 = "1) Id Commande 2) Id Client 3) Id Salarié 4) Date de Commzande 5) Date de livraison 6) adresse 7) prix";
        Connexion connexion = new Connexion();
        public Commande() { }
        /// <summary>
        /// Inserer tuples à commande
        /// </summary>
        public void Creation_Commande()
        {
            string insertTable = " INSERT INTO COMMANDE VALUES (";
            do
            {
                Console.WriteLine("Insérez ID COMMANDE\n\n");
                idcommande = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (idcommande < 30 || idcommande >= 100) Console.WriteLine("Saisie Invalide\n");
            } while (idcommande < 30 || idcommande >= 100);
            do
            {
                Console.WriteLine("Insérez ID SALARIE\n\n");
                idsalarie = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (idsalarie < 20 || idsalarie >= 100) Console.WriteLine("Saisie Invalide\n");
            } while (idsalarie < 20 || idsalarie >= 100);
            string date;
            do
            {
                Console.WriteLine("\n\nInsérez date commande: format (AAAA-MM-JJ)\n\n");
                date = Console.ReadLine();
                if (DateTime.TryParse(date, out datecommande) == false)
                {
                    Console.WriteLine("La saisie n'est pas une date valide\n");
                }

            } while (DateTime.TryParse(date, out datecommande) == false);
            do
            {
                Console.WriteLine("\n\nInsérez date Livraison: format (AAAA-MM-JJ)\n\n");
                date = Console.ReadLine();
                if (DateTime.TryParse(date, out dateLivraison) == false)
                {
                    Console.WriteLine("La saisie n'est pas une date valide\n");
                }

            } while (DateTime.TryParse(date, out dateLivraison) == false);
          
            do
            {
                Console.WriteLine("\nInsérez ADRESSE LIVRAISON\n\n");
                adresse = Console.ReadLine();
                if (adresse.Length > 50) Console.WriteLine("Saisie Invalide\n");
            } while (adresse.Length > 50);
            do
            {
                Console.WriteLine("\nInsérez PRIX de la commande\n\n");
                prix = Convert.ToDouble(Console.ReadLine());
                if (prix < 0 && prix > 999) Console.WriteLine("Saisie Invalide\n");
            } while (prix < 0 && prix > 999);
            insertTable += idcommande + "," + idclient + "," + idsalarie + ", '" + datecommande.ToString() + "' , '" + dateLivraison.ToString() + "','" +adresse + "'," + prix+ ");";


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
        /// Supprimer tuple commande
        /// </summary>
        public void Suppression_commande()
        {
            int choix;
            do
            {
                Console.WriteLine("En fonction de quelle caractéristique voulez-vous supprimer la commande?\n" + caractéristiques);
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix < 0 && choix > 7) Console.WriteLine("Saisie Invalide\n");
            } while (choix < 0 && choix > 7);
            string suppression = "DELETE FROM COMMANDE WHERE ";
            int id;
            switch (choix)
            {

                case 1:

                    do
                    {
                        Console.WriteLine("Insérez ID COMMANDE à supprimer\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id < 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id < 0 || id >= 100);
                    suppression += "ID_COMMANDE=" + id + ";";

                    break;


                case 2:

                    do
                    {
                        Console.WriteLine("Insérez ID CLIENT à supprimer\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id < 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id < 0 || id >= 100);
                    suppression += "ID_CLIENT=" + id + ";";

                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Insérez ID SALARIE à supprimer\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id < 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id < 0 || id >= 100);
                    suppression += "ID_SALARIE=" + id + ";";


                    break;
                case 4:
                    DateTime choixDate;
                    string date;
                    do
                    {
                        Console.WriteLine("\nInsérez Date de la commande à supprimer (format : AAAA-MM-JJ)\n\n");
                        date = Console.ReadLine();
                        if (!DateTime.TryParse(date, out choixDate))
                        {
                            Console.WriteLine("La saisie n'est pas une date valide\n");
                        }
                    } while (!DateTime.TryParse(date, out choixDate));
                    suppression += "DATE_COMMANDE= '" + date.ToString() + "';";

                    break;
                case 5:

                    DateTime choixDate2;
                    string date2;
                    do
                    {
                        Console.WriteLine("\nInsérez Date de livraison à supprimer (format : AAAA-MM-JJ)\n\n");
                        date2 = Console.ReadLine();
                        if (!DateTime.TryParse(date2, out choixDate2))
                        {
                            Console.WriteLine("La saisie n'est pas une date valide\n");
                        }
                    } while (!DateTime.TryParse(date2, out choixDate2));
                    suppression += "DATE_LIVRAISON= '" + date2.ToString() + "';";


                    break;
                case 6:
                    string adresse;
                    do
                    {
                        Console.WriteLine("\nInsérez adresse de la commande à supprimer\n\n");
                        adresse= Console.ReadLine();
                        if (adresse.Length > 50) Console.WriteLine("Saisie Invalide\n");
                    } while (adresse.Length > 5);
                    suppression += "ADRESSE_LIVRAISON= '" + adresse + "';";
                    break;
                case 7:
                    Double prixc;
                    do
                    {
                        Console.WriteLine("\nInsérez PRIX Commande à supprimer (Comprise entre 0 et 5)\n\n");
                        prixc = Convert.ToDouble(Console.ReadLine());
                        if (prixc < 0 && prixc > 999) Console.WriteLine("Saisie Invalide\n");
                    } while (prixc < 0 && prixc > 999);
                    suppression += " PRIX_COMMANDE= " + prixc + ";";
                    break;


            }

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
        /// Afficher tuples commande
        /// </summary>
        public void AfficherCommande()
        {
            string requete = "SELECT * FROM COMMANDE";
            connexion.Command.CommandText = requete;
            MySqlDataReader reader = connexion.Command.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            Console.WriteLine("    COMMANDE :\n" + caractéristiques2);
            while (reader.Read())
            {
                int id = reader.GetInt32("ID_COMMANDE");
                int id2 = reader.GetInt32("ID_CLIENT");
                int id3 = reader.GetInt32("ID_SALARIE");
                DateTime date_commande = reader.GetDateTime("DATE_COMMANDE");
                DateTime date_livraison = reader.GetDateTime("DATE_LIVRAISON");
                string adresse = reader.GetString("ADRESSE_LIVRAISON");
                double prixc = reader.GetDouble("PRIX_COMMANDE");


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
        /// <summary>
        /// Mise à jour commande
        /// </summary>
        public void Maj_Salarie()
        {
            Console.WriteLine("Modification: \n\nExemple: UPDATE COMMANDE SET ADRESSE=5 WHERE ID_CLIENT=5 ");
            Console.WriteLine("Rappel des carctéristiques:"+caractéristiques+ "\n\nComplétez: UPDATE COMMANDE SET");
            string maj = "UPDATE COMMANDE SET ";

            string n = Console.ReadLine();
            maj += n+" WHERE ";
            Console.WriteLine("Rappel des carctéristiques:" + caractéristiques + "\n\n"+maj);
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
        }
    }
}
