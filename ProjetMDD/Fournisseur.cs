using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMDD
{

    internal class Fournisseur
    {
        int id_fournisseur;
        string nom;
        string adresse;
        int contact;
       
        int note;
        string libelle;
     
        Connexion connexion = new Connexion();
        string caractéristiques = "1) Id Fournisseur\n2) Nom\n3) Adresse\n4) Contact\n5) note\n6) libellé\n";
        string caractéristiques2 = "1) Id Fournisseur 2) Nom 3) Adresse 4) Contact 5) note 6) libellé\n";


        public Fournisseur() { }
        /// <summary>
        /// Fonction qui insere tuples à fournisseur
        /// </summary>
        public void Creation_fournisseur()
        {
            string insertTable = " INSERT INTO FOURNISSEUR  VALUES (";
            do
            {
                Console.WriteLine("Insérez ID Fournisseur\n\n");
                id_fournisseur = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if ((id_fournisseur > 6 && id_fournisseur<16)||id_fournisseur<0) Console.WriteLine("Saisie Invalide\n");
            } while ((id_fournisseur > 6 && id_fournisseur < 16)|| id_fournisseur < 0);
            do
            {
                Console.WriteLine("\nInsérez nom fournisseur\n\n");
                nom = Console.ReadLine();
                if (nom.Length > 50) Console.WriteLine("Saisie Invalide\n");
            } while (nom.Length > 50);
            do
            {
                Console.WriteLine("\nInsérez adresse fournisseur\n\n");
                adresse = Console.ReadLine();
                if (adresse.Length > 50) Console.WriteLine("Saisie Invalide\n");
            } while (adresse.Length > 50);
            do
            {
                Console.WriteLine("\nInsérez contact fournisseur\n\n");
                contact = Convert.ToInt32(Console.ReadLine());
                if (contact > 9999999999 || contact < 0) Console.WriteLine("Saisie Invalide\n");
            } while (contact > 9999999999 || contact < 0);
            do
            {
                Console.WriteLine("\nInsérez note fournisseur (Entre 0 et 5)\n\n");
                note = Convert.ToInt32(Console.ReadLine());
                if (note<0||note>5) Console.WriteLine("Saisie Invalide\n");
            } while (note < 0 || note > 5);
            do
            {
                Console.WriteLine("\nInsérez libelle fournisseur\n\n");
                libelle = Console.ReadLine();
                if (libelle.Length > 20) Console.WriteLine("Saisie Invalide\n");
            } while (libelle.Length > 20);
            insertTable += id_fournisseur + ",'" + nom + "','" + adresse + "'," + contact + "," + note + ",'" + libelle + "');";


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
        /// Fonction qui supprime valeurs  dans fournisseur
        /// </summary>
        public void Suppression_fournisseur()
        {
            int choix;
            do
            {
                Console.WriteLine("En fonction de quelle caractéristique voulez-vous supprimer le fournisseur?\n" + caractéristiques);
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix < 0 && choix > 6) Console.WriteLine("Saisie Invalide\n");
            } while (choix < 0 && choix > 6);
            string suppression = "DELETE FROM FOURNISSEUR WHERE ";

            switch (choix)
            {
                
                case 1:
                    int id;
                    do
                    {
                        Console.WriteLine("Insérez ID_FROUNISSEUR à supprimer\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id <= 0 || id >= 100);
                    suppression += "ID_FOURNISSEUR=" + id + ";";

                    break;

              
                case 2:
                    string choixnom;
                    do
                    {
                        Console.WriteLine("\nInsérez NOM du fournisseur à supprimer\n\n");
                        choixnom = Console.ReadLine();
                        if (choixnom.Length > 50) Console.WriteLine("Saisie Invalide\n");
                    } while (choixnom.Length > 50);
                    suppression += "NOM= '" + choixnom + "';";

                    break;
                case 3:
                    string choixadresse;
                    do
                    {
                        Console.WriteLine("\nInsérez adresse du fournisseur à supprimer\n\n");
                        choixadresse = Console.ReadLine();
                        if (choixadresse.Length > 50) Console.WriteLine("Saisie Invalide\n");
                    } while (choixadresse.Length > 50);
                    suppression += "ADRESSE= '" + choixadresse + "';";

                    break;
                case 4:
                    int tel;
                    do
                    {
                        Console.WriteLine("Insérez CONTACT fournisseur à supprimer\n\n");
                        tel = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (tel > 9999999999 || tel < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (tel > 9999999999 || tel < 0);
                    suppression += "CONTACT=" + tel + ";";

                    break;
                case 5:
                    int no;
                    do
                    {
                        Console.WriteLine("Insérez ID_FROUNISSEUR à supprimer\n\n");
                        no = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (no<= 0 || no>5) Console.WriteLine("Saisie Invalide\n");
                    } while (no <= 0 || no > 5);
                    suppression += "NOTE=" + no + ";";

                    break;
                case 6:
                    string choixlibelle;
                    do
                    {
                        Console.WriteLine("\nInsérez libelle du fournisseur à supprimer\n\n");
                        choixlibelle = Console.ReadLine();
                        if (choixlibelle.Length > 20) Console.WriteLine("Saisie Invalide\n");
                    } while (choixlibelle.Length > 20);
                    suppression += "LIBELLE= '" + choixlibelle + "';";
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
        /// Fonction qui affiche la table fournisseur
        /// </summary>
        public void AfficherFournisseur()
        {
            string requete = "SELECT * FROM FOURNISSEUR";
            connexion.Command.CommandText = requete;
            MySqlDataReader reader = connexion.Command.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            Console.WriteLine("    FOURNISSEURS :\n" + caractéristiques2);
            while (reader.Read())
            {
                int id = reader.GetInt32("ID_FOURNISSEUR");
                string nom = reader.GetString("NOM");
                string adresse = reader.GetString("ADRESSE");
                int contact = reader.GetInt32("CONTACT");
              
                int note = reader.GetInt32("NOTE");
                string LIBELLE = reader.GetString("LIBELLE");
              

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
        /// Fonction qui met à jour la table fournisseur
        /// </summary>
        public void Maj_fournisseur()
        {
            int choix;
            do
            {
                Console.WriteLine("Quelle caractéristique voulez-vous modifier?\n" + caractéristiques);
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix < 0 && choix > 6) Console.WriteLine("Saisie Invalide\n");
            } while (choix < 0 && choix > 6);
            int choix2;
            do
            {
                Console.WriteLine("En fonction de quelle caractéristique voulez-vous la modifier?\n" + caractéristiques);
                choix2 = Convert.ToInt32(Console.ReadLine());
                if (choix2 < 0 && choix2 > 6) Console.WriteLine("Saisie Invalide\n");
            } while (choix2 < 0 && choix2 > 6);
            string maj = "UPDATE FOURNISSEUR SET ";
            string choix_maj;
            int choix_majj;
            #region
            switch (choix)
            {

                case 1:
                    int id;

                    do
                    {
                        Console.WriteLine("Insérez nouveau  ID_FOURNISSEUR\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id <= 0 || id >= 100);
                    maj += "ID_FOURNISSEUR=" + id + " ";

                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_fournisseur initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_FOURNISSEUR= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM initiale?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 50);
                            maj += "WHERE NOM= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixADRESSE;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle ADRESSE initiale?\n\n");
                                choixADRESSE = Console.ReadLine();
                                if (choixADRESSE.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixADRESSE.Length > 50);
                            maj += "WHERE ADRESSE= '" + choixADRESSE + "';";

                            break;

                        case 4:
                            int choixContact;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CONTACT intitial?\n\n");
                                choixContact = Convert.ToInt32(Console.ReadLine());
                                if (choixContact > 9999999999 || choixContact < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixContact > 9999999999 || choixContact < 0);
                            maj += "WHERE CONTACT= " + choixContact + ";";

                            break;


                        case 5:
                            int choixnote;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle note fournisseur? (Entre 0 et 5)\n\n");
                                choixnote = Convert.ToInt32(Console.ReadLine());
                                if (choixnote < 0 || choixnote > 5) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnote < 0 || choixnote > 5);
                            maj += "WHERE NOTE= " + choixnote + ";";

                            break;

                        case 6:
                            string choixlibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle libelle fournisseur intitiale?\n\n");
                                choixlibelle = Console.ReadLine();
                                if (choixlibelle.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixlibelle.Length > 20);
                            maj += "WHERE LIBELLE='" + choixlibelle + "';";

                            break;


                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;


                case 2:

          
                    do
                    {
                        Console.WriteLine("Insérez nouveau  NOM\n\n");
                        choix_maj = Console.ReadLine();
                        if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 50);
                    maj += "NOM= '" + choix_maj + "' ";

                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_fournisseur initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_FOURNISSEUR= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM initiale?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 50);
                            maj += "WHERE NOM= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixADRESSE;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle ADRESSE initiale?\n\n");
                                choixADRESSE = Console.ReadLine();
                                if (choixADRESSE.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixADRESSE.Length > 50);
                            maj += "WHERE ADRESSE= '" + choixADRESSE + "';";

                            break;

                        case 4:
                            int choixContact;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CONTACT intitial?\n\n");
                                choixContact = Convert.ToInt32(Console.ReadLine());
                                if (choixContact > 9999999999 || choixContact < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixContact > 9999999999 || choixContact < 0);
                            maj += "WHERE CONTACT= " + choixContact + ";";

                            break;


                        case 5:
                            int choixnote;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle note fournisseur? (Entre 0 et 5)\n\n");
                                choixnote = Convert.ToInt32(Console.ReadLine());
                                if (choixnote < 0 || choixnote > 5) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnote < 0 || choixnote > 5);
                            maj += "WHERE NOTE= " + choixnote + ";";

                            break;

                        case 6:
                            string choixlibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle libelle fournisseur intitiale?\n\n");
                                choixlibelle = Console.ReadLine();
                                if (choixlibelle.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixlibelle.Length > 20);
                            maj += "WHERE LIBELLE='" + choixlibelle + "';";

                            break;


                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;
                case 3:


                    do
                    {
                        Console.WriteLine("Insérez nouvelle ADRESSE\n\n");
                        choix_maj = Console.ReadLine();
                        if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 50);
                    maj += "ADRESSE= '" + choix_maj + "' ";
                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_fournisseur initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_FOURNISSEUR= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM initiale?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 50);
                            maj += "WHERE NOM= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixADRESSE;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle ADRESSE initiale?\n\n");
                                choixADRESSE = Console.ReadLine();
                                if (choixADRESSE.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixADRESSE.Length > 50);
                            maj += "WHERE ADRESSE= '" + choixADRESSE + "';";

                            break;

                        case 4:
                            int choixContact;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CONTACT intitial?\n\n");
                                choixContact = Convert.ToInt32(Console.ReadLine());
                                if (choixContact > 9999999999 || choixContact < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixContact > 9999999999 || choixContact < 0);
                            maj += "WHERE CONTACT= " + choixContact + ";";

                            break;


                        case 5:
                            int choixnote;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle note fournisseur? (Entre 0 et 5)\n\n");
                                choixnote = Convert.ToInt32(Console.ReadLine());
                                if (choixnote < 0 || choixnote > 5) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnote < 0 || choixnote > 5);
                            maj += "WHERE NOTE= " + choixnote + ";";

                            break;

                        case 6:
                            string choixlibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle libelle fournisseur intitiale?\n\n");
                                choixlibelle = Console.ReadLine();
                                if (choixlibelle.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixlibelle.Length > 20);
                            maj += "WHERE LIBELLE='" + choixlibelle + "';";

                            break;


                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }

                    break;
                case 4:
                    int choixContact2;
                    do
                    {
                        Console.WriteLine("\nInsérez nouveau CONTACT\n\n");
                        choixContact2 = Convert.ToInt32(Console.ReadLine());
                        if (choixContact2 > 9999999999 || choixContact2 < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (choixContact2 > 9999999999 || choixContact2 < 0);
                    maj += "CONTACT= " + choixContact2 + ";";

                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_fournisseur initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_FOURNISSEUR= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM initiale?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 50);
                            maj += "WHERE NOM= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixADRESSE;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle ADRESSE initiale?\n\n");
                                choixADRESSE = Console.ReadLine();
                                if (choixADRESSE.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixADRESSE.Length > 50);
                            maj += "WHERE ADRESSE= '" + choixADRESSE + "';";

                            break;

                        case 4:
                            int choixContact;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CONTACT intitial?\n\n");
                                choixContact = Convert.ToInt32(Console.ReadLine());
                                if (choixContact > 9999999999 || choixContact < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixContact > 9999999999 || choixContact < 0);
                            maj += "WHERE CONTACT= " + choixContact + ";";

                            break;


                        case 5:
                            int choixnote;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle note fournisseur? (Entre 0 et 5)\n\n");
                                choixnote = Convert.ToInt32(Console.ReadLine());
                                if (choixnote < 0 || choixnote > 5) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnote < 0 || choixnote > 5);
                            maj += "WHERE NOTE= " + choixnote + ";";

                            break;

                        case 6:
                            string choixlibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle libelle fournisseur intitiale?\n\n");
                                choixlibelle = Console.ReadLine();
                                if (choixlibelle.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixlibelle.Length > 20 );
                            maj += "WHERE LIBELLE='" + choixlibelle + "';";

                            break;


                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;

                case 5:

                    int choixnote2;
                    do
                    {
                        Console.WriteLine("\nInsérez nouveelle NOTE (Entre 0 et 5)\n\n");
                        choixnote2 = Convert.ToInt32(Console.ReadLine());
                        if (choixnote2 < 0 || choixnote2 > 5) Console.WriteLine("Saisie Invalide\n");
                    } while (choixnote2 < 0 || note > 5);
                    maj += "NOTE= " + choixnote2 + ";";



                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_fournisseur initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_FOURNISSEUR= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM initiale?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 50);
                            maj += "WHERE NOM= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixADRESSE;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle ADRESSE initiale?\n\n");
                                choixADRESSE = Console.ReadLine();
                                if (choixADRESSE.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixADRESSE.Length > 50);
                            maj += "WHERE ADRESSE= '" + choixADRESSE + "';";

                            break;

                        case 4:
                            int choixContact;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CONTACT intitial?\n\n");
                                choixContact = Convert.ToInt32(Console.ReadLine());
                                if (choixContact > 9999999999 || choixContact < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixContact > 9999999999 || choixContact < 0);
                            maj += "WHERE CONTACT= " + choixContact + ";";

                            break;


                        case 5:
                            int choixnote;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle note fournisseur? (Entre 0 et 5)\n\n");
                                choixnote = Convert.ToInt32(Console.ReadLine());
                                if (choixnote < 0 || choixnote > 5) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnote < 0 || choixnote > 5);
                            maj += "WHERE NOTE= " + choixnote + ";";

                            break;

                        case 6:
                            string choixlibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle libelle fournisseur intitiale?\n\n");
                                choixlibelle = Console.ReadLine();
                                if (choixlibelle.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixlibelle.Length > 20);
                            maj += "WHERE LIBELLE='" + choixlibelle + "';";
                            break;


                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;
                case 6:

                    do
                    {
                        Console.WriteLine("Insérez nouveau LIBELLE\n\n");
                        choix_maj = Console.ReadLine();
                        if (choix_maj.Length > 20) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 20);
                    maj += "LIBELLE= '" + choix_maj + "' ";

                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_fournisseur initial?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_FOURNISSEUR= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM initiale?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 50);
                            maj += "WHERE NOM= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixADRESSE;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle ADRESSE initiale?\n\n");
                                choixADRESSE = Console.ReadLine();
                                if (choixADRESSE.Length > 50) Console.WriteLine("Saisie Invalide\n");
                            } while (choixADRESSE.Length > 50);
                            maj += "WHERE ADRESSE= '" + choixADRESSE + "';";

                            break;

                        case 4:
                            int choixContact;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CONTACT intitial?\n\n");
                                choixContact = Convert.ToInt32(Console.ReadLine());
                                if (choixContact > 9999999999 || choixContact < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixContact > 9999999999 || choixContact < 0);
                            maj += "WHERE CONTACT= " + choixContact + ";";

                            break;


                        case 5:
                            int choixnote;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle note fournisseur? (Entre 0 et 5)\n\n");
                                choixnote = Convert.ToInt32(Console.ReadLine());
                                if (choixnote < 0 || choixnote > 5) Console.WriteLine("Saisie Invalide\n");
                            } while (choixnote < 0 || choixnote > 5);
                            maj += "WHERE NOTE= " + choixnote + ";";

                            break;

                        case 6:
                            string choixlibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle libelle fournisseur intitiale?\n\n");
                                choixlibelle = Console.ReadLine();
                                if (choixlibelle.Length > 20) Console.WriteLine("Saisie Invalide\n");
                            } while (choixlibelle.Length > 20);
                            maj += "WHERE LIBELLE='" + choixlibelle + "';";

                            break;


                        default:
                            Console.WriteLine("Choix invalide");
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
