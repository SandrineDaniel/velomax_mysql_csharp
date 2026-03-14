using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMDD
{
    internal class Salarié
    {
        int id_salarie;
        int id_magasin;
        string typecontrat;
        int salaire;
        int prime;
        string nom;
        double satisfaction;
        Connexion connexion = new Connexion();
        string caractéristiques = "1) Id Salarié\n2) Id magasin\n3) Type de contrat\n4) Salaire\n5) Prime\n6) Nom du salarié\n7) Satisfaction";
        string caractéristiques2 = "1) Id Salarié 2) Id magasin 3) Type de contrat 4) Salaire 5) Prime 6) Nom du salarié 7) Satisfaction\n";


        public Salarié() { }
        /// <summary>
        /// Inserer tuple à salarié
        /// </summary>
        public void Cration_salarie()
        {
            string insertTable = " INSERT INTO SALARIE VALUES (";
            do
            {
                Console.WriteLine("Insérez ID SALARIE\n\n");
                id_salarie = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (id_salarie <20||id_salarie>=100) Console.WriteLine("Saisie Invalide\n");
            } while (id_salarie < 20 || id_salarie >= 100);
            do
            {
                Console.WriteLine("\nInsérez ID MAGASIN\n\n");
                id_magasin = Convert.ToInt32(Console.ReadLine());
                if (id_magasin < 5 || id_magasin >= 100) Console.WriteLine("Saisie Invalide\n");
            } while (id_magasin < 5 || id_magasin >= 100);
            do
            {
                Console.WriteLine("\nInsérez type CONTRAT\n\n");
                typecontrat = Console.ReadLine();
                if (typecontrat.Length > 50) Console.WriteLine("Saisie Invalide\n");
            } while (typecontrat.Length > 50);
            do
            {
                Console.WriteLine("\nInsérez SALAIRE\n\n");
                salaire = Convert.ToInt32(Console.ReadLine());
                if (salaire >9999|| salaire < 0) Console.WriteLine("Saisie Invalide\n");
            } while (salaire > 9999 || salaire < 0);
            do
            {
                Console.WriteLine("\nInsérez PRIME\n\n");
                prime = Convert.ToInt32(Console.ReadLine());
                if (prime < 0 || prime > 99) Console.WriteLine("Saisie Invalide\n");
            } while (prime < 0 || prime > 99);
            do
            {
                Console.WriteLine("\nInsérez NOM SALARIE\n\n");
                nom = Console.ReadLine();
                if (nom.Length > 50) Console.WriteLine("Saisie Invalide\n");
            } while (nom.Length > 50);
            do
            {
                Console.WriteLine("\nInsérez SATISFACTION (Comprise entre 0 et 5)\n\n");
                satisfaction = Convert.ToDouble(Console.ReadLine());
                if (satisfaction<0&&satisfaction>5) Console.WriteLine("Saisie Invalide\n");
            } while (satisfaction < 0 && satisfaction > 5);
            insertTable += id_salarie + "," + id_magasin + ",'" + typecontrat + "'," + salaire + "," + prime + ",'" + nom +"',"+satisfaction+ ");";


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
        /// Supprimer tuple salarié
        /// </summary>
        public void Suppression_salarie()
        {
            int choix;
            do
            {
                Console.WriteLine("En fonction de quelle caractéristique voulez-vous supprimer le salarie?\n" + caractéristiques);
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix < 0 && choix > 7) Console.WriteLine("Saisie Invalide\n");
            } while (choix < 0 && choix > 7);
            string suppression = "DELETE FROM SALARIE WHERE ";
            int id;
            switch (choix)
            {

                case 1:
                   
                    do
                    {
                        Console.WriteLine("Insérez ID SALARIE à supprimer\n\n");
                        id= Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id < 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id <  0|| id>= 100);
                    suppression += "ID_SALARIE=" + id + ";";

                    break;


                case 2:
                   
                    do
                    {
                        Console.WriteLine("Insérez MAGASIN à supprimer\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id < 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id < 0 || id >= 100);
                    suppression += "ID_SALARIE=" + id + ";";

                    break;
                case 3:
                    string typec;
                    do
                    {
                        Console.WriteLine("\nInsérez type contrat à supprimer\n\n");
                        typec = Console.ReadLine();
                        if (typec.Length > 50) Console.WriteLine("Saisie Invalide\n");
                    } while (typec.Length > 50);
                    suppression += "TYPE_CONTRAT= '" + typec + "';";

                    break;
                case 4:
                 
                    do
                    {
                        Console.WriteLine("Insérez SALAIRE à supprimer\n\n");
                         id= Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id> 9999 || id < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (id > 9999 || id < 0);
                    suppression += "SALAIRE=" + id + ";";

                    break;
                case 5:
                
                    do
                    {
                        Console.WriteLine("Insérez PRIME à supprimer\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id < 0 || id > 99) Console.WriteLine("Saisie Invalide\n");
                    } while (id < 0 || id > 99);
                    suppression += "PRIME=" + id + ";";

                    break;
                case 6:
                    string choixNOM;
                    do
                    {
                        Console.WriteLine("\nInsérez NOM du salarié à supprimer\n\n");
                        choixNOM = Console.ReadLine();
                        if (choixNOM.Length > 20) Console.WriteLine("Saisie Invalide\n");
                    } while (choixNOM.Length > 20);
                    suppression += "NOM_SALARIE= '" + choixNOM + "';";
                    break;
                case 7:
                    Double choixsatisfaction;
                    do
                    {
                        Console.WriteLine("\nInsérez SATISFACTION àsupprimer (Comprise entre 0 et 5)\n\n");
                        choixsatisfaction = Convert.ToDouble(Console.ReadLine());
                        if (choixsatisfaction < 0 && choixsatisfaction > 5) Console.WriteLine("Saisie Invalide\n");
                    } while (choixsatisfaction < 0 && choixsatisfaction > 5);

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
        /// Afficher la table salarié
        /// </summary>
        public void AfficherSalarie()
        {
            string requete = "SELECT * FROM SALARIE";
            connexion.Command.CommandText = requete;
            MySqlDataReader reader = connexion.Command.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            Console.WriteLine("    SALARIE :\n" + caractéristiques2);
            while (reader.Read())
            {
                int id = reader.GetInt32("ID_SALARIE");
                int id2= reader.GetInt32("ID_MAGASIN");
                string nom = reader.GetString("NOM_SALARIE");
                string contrat = reader.GetString("TYPE_CONTRAT");
                int salaire = reader.GetInt32("SALAIRE");

                int prime = reader.GetInt32("PRIME");
                double satisfaction = reader.GetDouble("SATISFACTION");


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
        /// Mettre à joour la table salarié
        /// </summary>
        public void Maj_Salarie()
        {
            int choix;
            do
            {
                Console.WriteLine("Quelle caractéristique voulez-vous modifier?\n" + caractéristiques);
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix < 0 && choix > 7) Console.WriteLine("Saisie Invalide\n");
            } while (choix < 0 && choix > 7);
            int choix2;
            do
            {
                Console.WriteLine("En fonction de quelle caractéristique voulez-vous la modifier?\n" + caractéristiques);
                choix2 = Convert.ToInt32(Console.ReadLine());
                if (choix2 < 0 && choix2 > 7) Console.WriteLine("Saisie Invalide\n");
            } while (choix2 < 0 && choix2 > 7);
            string maj = "UPDATE SALARIE SET ";
            string choix_maj;
            int choix_majj;
            int id;
            #region
            switch (choix)
            {

                case 1:
                   

                    do
                    {
                        Console.WriteLine("Insérez nouveau  ID_SALARIE\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id <= 0 || id >= 100);
                    maj += "ID_SALARIE=" + id + " ";

                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_SALARIE initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_SALARIE= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_MAGASIN initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_MAGASIN= " + id + ";";
                            break;

                        case 3:
                            string choixcontrat;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle contrat initiale?\n\n");
                                choixcontrat= Console.ReadLine();
                                if (choixcontrat.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixcontrat.Length > 50);
                            maj += "WHERE TYPE_CONTRAT= '" + choixcontrat + "';";

                            break;

                        case 4:
                            
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel SALAIRE intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 9999 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 9999 || id < 0);
                            maj += "WHERE SALAIRE= " + id + ";";

                            break;


                        case 5:
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 99 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 99 || id < 0);
                            maj += "WHERE PRIME= " + id + ";";


                            break;

                        case 6:
                            string choixnom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM de salarié intitiale?\n\n");
                                choixnom = Console.ReadLine();
                                if (choixnom.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnom.Length > 20);
                            maj += "WHERE NOM_SALARIE='" + choixnom + "';";

                            break;
                        case 7:
                            double d;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                d= Convert.ToDouble(Console.ReadLine());
                                if (d>5 || d < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (d > 5 || d < 0);
                            maj += "WHERE SATISFACTION= " + d + ";";


                         break;


                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;


                case 2:


                    

                    do
                    {
                        Console.WriteLine("Insérez nouveau  ID_MAGASIN\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id <= 0 || id >= 100);
                    maj += "ID_MAGASIN=" + id + " ";

                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_SALARIE initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_SALARIE= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_MAGASIN initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_MAGASIN= " + id + ";";
                            break;

                        case 3:
                            string choixcontrat;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle contrat initiale?\n\n");
                                choixcontrat = Console.ReadLine();
                                if (choixcontrat.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixcontrat.Length > 50);
                            maj += "WHERE TYPE_CONTRAT= '" + choixcontrat + "';";

                            break;

                        case 4:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel SALAIRE intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 9999 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 9999 || id < 0);
                            maj += "WHERE SALAIRE= " + id + ";";

                            break;


                        case 5:
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 99 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 99 || id < 0);
                            maj += "WHERE PRIME= " + id + ";";


                            break;

                        case 6:
                            string choixnom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM de salarié intitiale?\n\n");
                                choixnom = Console.ReadLine();
                                if (choixnom.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnom.Length > 20);
                            maj += "WHERE NOM_SALARIE='" + choixnom + "';";

                            break;
                        case 7:
                            double d;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                d = Convert.ToDouble(Console.ReadLine());
                                if (d > 5 || d < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (d > 5 || d < 0);
                            maj += "WHERE SATISFACTION= " + d + ";";


                            break;
                    }
                    break;
                case 3:


                    do
                    {
                        Console.WriteLine("Insérez nouveau TYPE DE CONTRAT\n\n");
                        choix_maj = Console.ReadLine();
                        if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 50);
                    maj += "TYPE_CONTRAT= '" + choix_maj + "' ";
                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_SALARIE initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_SALARIE= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_MAGASIN initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_MAGASIN= " + id + ";";
                            break;

                        case 3:
                            string choixcontrat;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle contrat initiale?\n\n");
                                choixcontrat = Console.ReadLine();
                                if (choixcontrat.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixcontrat.Length > 50);
                            maj += "WHERE TYPE_CONTRAT= '" + choixcontrat + "';";

                            break;

                        case 4:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel SALAIRE intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 9999 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 9999 || id < 0);
                            maj += "WHERE SALAIRE= " + id + ";";

                            break;


                        case 5:
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 99 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 99 || id < 0);
                            maj += "WHERE PRIME= " + id + ";";


                            break;

                        case 6:
                            string choixnom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM de salarié intitiale?\n\n");
                                choixnom = Console.ReadLine();
                                if (choixnom.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnom.Length > 20);
                            maj += "WHERE NOM_SALARIE='" + choixnom + "';";

                            break;
                        case 7:
                            double d;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                d = Convert.ToDouble(Console.ReadLine());
                                if (d > 5 || d < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (d > 5 || d < 0);
                            maj += "WHERE SATISFACTION= " + d + ";";


                            break;
                    }

                            break;
                case 4:
                    
                    do
                    {
                        Console.WriteLine("\nInsérez nouveau SALAIRE\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        if (id > 9999|| id < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (id > 9999 || id < 0);
                    maj += "SALAIRE= " + id + ";";

                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_SALARIE initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_SALARIE= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_MAGASIN initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_MAGASIN= " + id + ";";
                            break;

                        case 3:
                            string choixcontrat;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle contrat initiale?\n\n");
                                choixcontrat = Console.ReadLine();
                                if (choixcontrat.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixcontrat.Length > 50);
                            maj += "WHERE TYPE_CONTRAT= '" + choixcontrat + "';";

                            break;

                        case 4:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel SALAIRE intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 9999 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 9999 || id < 0);
                            maj += "WHERE SALAIRE= " + id + ";";

                            break;


                        case 5:
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 99 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 99 || id < 0);
                            maj += "WHERE PRIME= " + id + ";";


                            break;

                        case 6:
                            string choixnom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM de salarié intitiale?\n\n");
                                choixnom = Console.ReadLine();
                                if (choixnom.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnom.Length > 20);
                            maj += "WHERE NOM_SALARIE='" + choixnom + "';";

                            break;
                        case 7:
                            double d;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                d = Convert.ToDouble(Console.ReadLine());
                                if (d > 5 || d < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (d > 5 || d < 0);
                            maj += "WHERE SATISFACTION= " + d + ";";


                            break;
                    }
                    break;

                case 5:

                    do
                    {
                        Console.WriteLine("\nInsérez nouvelle PRIME\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        if (id > 99|| id < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (id > 99 || id < 0);
                    maj += "PRIME= " + id + ";";



                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_SALARIE initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_SALARIE= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_MAGASIN initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_MAGASIN= " + id + ";";
                            break;

                        case 3:
                            string choixcontrat;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle contrat initiale?\n\n");
                                choixcontrat = Console.ReadLine();
                                if (choixcontrat.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixcontrat.Length > 50);
                            maj += "WHERE TYPE_CONTRAT= '" + choixcontrat + "';";

                            break;

                        case 4:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel SALAIRE intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 9999 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 9999 || id < 0);
                            maj += "WHERE SALAIRE= " + id + ";";

                            break;


                        case 5:
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 99 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 99 || id < 0);
                            maj += "WHERE PRIME= " + id + ";";


                            break;

                        case 6:
                            string choixnom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM de salarié intitiale?\n\n");
                                choixnom = Console.ReadLine();
                                if (choixnom.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnom.Length > 20);
                            maj += "WHERE NOM_SALARIE='" + choixnom + "';";

                            break;
                        case 7:
                            double d;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                d = Convert.ToDouble(Console.ReadLine());
                                if (d > 5 || d < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (d > 5 || d < 0);
                            maj += "WHERE SATISFACTION= " + d + ";";


                            break;
                    }
                    break;
                case 6:

                    do
                    {
                        Console.WriteLine("Insérez nouveau NOM SALARIE\n\n");
                        choix_maj = Console.ReadLine();
                        if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 50);
                    maj += "NOM_SALARIE= '" + choix_maj + "' ";

                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_SALARIE initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_SALARIE= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_MAGASIN initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_MAGASIN= " + id + ";";
                            break;

                        case 3:
                            string choixcontrat;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle contrat initiale?\n\n");
                                choixcontrat = Console.ReadLine();
                                if (choixcontrat.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixcontrat.Length > 50);
                            maj += "WHERE TYPE_CONTRAT= '" + choixcontrat + "';";

                            break;

                        case 4:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel SALAIRE intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 9999 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 9999 || id < 0);
                            maj += "WHERE SALAIRE= " + id + ";";

                            break;


                        case 5:
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 99 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 99 || id < 0);
                            maj += "WHERE PRIME= " + id + ";";


                            break;

                        case 6:
                            string choixnom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM de salarié intitiale?\n\n");
                                choixnom = Console.ReadLine();
                                if (choixnom.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnom.Length > 20);
                            maj += "WHERE NOM_SALARIE='" + choixnom + "';";

                            break;
                        case 7:
                            double d;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                d = Convert.ToDouble(Console.ReadLine());
                                if (d > 5 || d < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (d > 5 || d < 0);
                            maj += "WHERE SATISFACTION= " + d + ";";


                            break;
                    }
                    break;
                case 7:
                    double d2;
                    do
                    {
                        Console.WriteLine("\nEn fonction de quel SATISFACTION intitial?\n\n");
                        d2 = Convert.ToDouble(Console.ReadLine());
                        if (d2 > 5 || d2 < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (d2 > 5 || d2 < 0);
                    maj += "SATISFACTION= " + d2 + ";";
              
                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_SALARIE initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_SALARIE= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_MAGASIN initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_MAGASIN= " + id + ";";
                            break;

                        case 3:
                            string choixcontrat;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle contrat initiale?\n\n");
                                choixcontrat = Console.ReadLine();
                                if (choixcontrat.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixcontrat.Length > 50);
                            maj += "WHERE TYPE_CONTRAT= '" + choixcontrat + "';";

                            break;

                        case 4:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel SALAIRE intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 9999 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 9999 || id < 0);
                            maj += "WHERE SALAIRE= " + id + ";";

                            break;


                        case 5:
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                if (id > 99 || id < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (id > 99 || id < 0);
                            maj += "WHERE PRIME= " + id + ";";


                            break;

                        case 6:
                            string choixnom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM de salarié intitiale?\n\n");
                                choixnom = Console.ReadLine();
                                if (choixnom.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnom.Length > 20);
                            maj += "WHERE NOM_SALARIE='" + choixnom + "';";

                            break;
                        case 7:
                            double d;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel PRIME intitial?\n\n");
                                d = Convert.ToDouble(Console.ReadLine());
                                if (d > 5 || d < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (d > 5 || d < 0);
                            maj += "WHERE SATISFACTION= " + d + ";";


                            break;
                    }
                    break;



                default:
                    Console.WriteLine("Choix invalide");
                    break;

            }
            #endregion


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
