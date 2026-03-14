using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMDD
{
    internal class Client
    {
        int id_client;
        string rue;
        string ville;
        int code_postal;
        string province;
        int telephone;
        string courriel;
        string nom;
        string libelle;
        DateTime date_adhesion;
        int id_programme;
        Connexion connexion=new Connexion();
        string caractéristiques = "1) Id Client\n2) Rue\n3) Ville\n4) Code postal\n5) Province\n6) Téléphone\n7) Courriel\n8) Nom\n9) Libellé\n10) Date d'adhésion\n11) Id Programme\n";
        string caractéristiques2 = "1) Id Client 2) Rue 3) Ville 4) Code postal 5) Province 6) Téléphone 7) Courriel 8) Nom 9) Libellé 10) Date d'adhésion 11) Id Programme\n";
        public Client()
        {
          
        }
        /// <summary>
        /// Fonction qui Insere des valeurs dans la table client
        /// </summary>
        public void Creation_Client()
        {
            string insertTable = " INSERT INTO Client(ID_CLIENT, RUE, VILLE, CODE_POSTAL, PROVINCE, TELEPHONE, COURIEL, NOM, LIBELLE, DATE_ADHESION, ID_PROGRAMME)  VALUES (";
            do
            {
                Console.WriteLine("Insérez ID_Client\n\n");
                id_client = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (id_client <= 5 || id_client >= 100) Console.WriteLine("Saisie Invalide\n");
            } while (id_client <= 5 || id_client >= 100);
            do
            {
                Console.WriteLine("\nInsérez votre Rue\n\n");
                rue = Console.ReadLine();
                if (rue.Length > 40) Console.WriteLine("Saisie Invalide\n");
            } while (rue.Length > 40);
            do
            {
                Console.WriteLine("\nInsérez votre Ville\n\n");
                ville = Console.ReadLine();
                if (ville.Length > 40) Console.WriteLine("Saisie Invalide\n");
            } while (ville.Length > 40);
            do
            {
                Console.WriteLine("\nInsérez votre Code Postal\n\n");
                code_postal = Convert.ToInt32(Console.ReadLine());
                if (code_postal > 99999 || code_postal < 0) Console.WriteLine("Saisie Invalide\n");
            } while (code_postal > 99999 || code_postal < 0);
            do
            {
                Console.WriteLine("\nInsérez votre Province\n\n");
                province = Console.ReadLine();
                if (province.Length > 40) Console.WriteLine("Saisie Invalide\n");
            } while (province.Length > 40);
            do
            {
                Console.WriteLine("\nInsérez votre numéro de télephone\n\n");
                telephone = Convert.ToInt32(Console.ReadLine());
                if (telephone > 9999999999 || telephone < 0) Console.WriteLine("Saisie Invalide\n");
            } while (telephone > 9999999999 || telephone < 0);
            do
            {
                Console.WriteLine("\nInsérez votre email\n\n");
                courriel = Console.ReadLine();

                if (courriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
            } while (courriel.Length > 128);
            do
            {
                Console.WriteLine("\nInsérez votre nom");
                nom = Console.ReadLine();
                if (nom.Length < 0 || nom.Length > 40) Console.WriteLine("Saisie Invalide\n");
            } while (nom.Length < 0 || nom.Length > 40);
            int choix;
            do
            {
                Console.WriteLine("\n\nEtes vous une entreprise ou un individu?\n1)Entreprise\n2)Individu\n\n");
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix != 1 && choix != 2) Console.WriteLine("Saisie Invalide\n");
            } while (choix != 1 && choix != 2);
            if (choix == 1) { libelle = "Entreprise"; }
            else
            {
                libelle = "Individu";
            }
            string date;
            do
            {
                Console.WriteLine("\n\nInsérez date d'adhésion: format (AAAA-MM-JJ)\n\n");
                date = Console.ReadLine();
                if (DateTime.TryParse(date, out date_adhesion) == false)
                {
                    Console.WriteLine("La saisie n'est pas une date valide\n");
                }

            } while (DateTime.TryParse(date, out date_adhesion) == false);
            if (libelle == "Individu")
            {
                do
                {
                    Console.WriteLine("\n\nInsérez le programme de fidélité:\n1) Fidélio\n2) Fidélio Or\n3) Fidélio Platine\n4) Fidélio Max");
                    id_programme = Convert.ToInt32(Console.ReadLine());
                    if(id_programme < 1 && id_programme > 4) { Console.WriteLine("Saisie Invalide\n"); }
                } while (id_programme < 1 && id_programme > 4);
            }

            insertTable += id_client + ",'" + rue + "','" + ville + "'," + code_postal + ",'" + province + "'," + telephone + ",'" + courriel + "','" + nom + "','" + libelle + "','" + date_adhesion.ToString("yyyy-MM-dd") + "'," + id_programme + ");";


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
        /// Fonction qui supprime des valeurs dans la table client
        /// </summary>
        public void Suppression_Client()
        {
            int choix;
            do
            {
                Console.WriteLine("En fonction de quelle caractéristique voulez-vous supprimer le client?\n"+caractéristiques);
                choix = Convert.ToInt32(Console.ReadLine());
                if(choix < 0 && choix > 11) Console.WriteLine("Saisie Invalide\n");
            } while (choix<0&&choix>11);
            string suppression = "DELETE FROM client WHERE ";
          
            switch (choix)
            {
                // Cas 1 : Suppression par ID_CLIENT
                case 1:
                    int id;
                    do
                    {
                        Console.WriteLine("Insérez ID_Client à supprimer\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id <= 5 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id <= 0 || id >= 100);
                    suppression += "ID_CLIENT=" + id + ";";
                    
                    break;

                // Cas 2 : Suppression par Rue
                case 2:
                    string choixRue;
                    do
                    {
                        Console.WriteLine("\nInsérez Rue du Client à supprimer\n\n");
                        choixRue = Console.ReadLine();
                        if (choixRue.Length > 40) Console.WriteLine("Saisie Invalide\n");
                    } while (choixRue.Length > 40);
                    suppression += "RUE= '" + choixRue + "';";
             
                    break;

                // Cas 3 : Suppression par Ville
                case 3:
                    string choixVille;
                    do
                    {
                        Console.WriteLine("\nInsérez Ville du Client à supprimer\n\n");
                        choixVille = Console.ReadLine();
                        if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                    } while (choixVille.Length > 40);
                    suppression += "VILLE= '" + choixVille + "';";
                 
                    break;

                // Cas 4 : Suppression par Code Postal
                case 4:
                    int choixCodePostal;
                    do
                    {
                        Console.WriteLine("\nInsérez Code Postal du Client à supprimer\n\n");
                        choixCodePostal = Convert.ToInt32(Console.ReadLine());
                        if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (choixCodePostal > 99999 || choixCodePostal < 0);
                    suppression += "CODE_POSTAL=" + choixCodePostal + ";";
           
                    break;

                // Cas 5 : Suppression par Province
                case 5:
                    string choixProvince;
                    do
                    {
                        Console.WriteLine("\nInsérez Province du Client à supprimer\n\n");
                        choixProvince = Console.ReadLine();
                        if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                    } while (choixProvince.Length > 40);
                    suppression += "PROVINCE= '" + choixProvince + "';";
           
                    break;

                // Cas 6 : Suppression par Téléphone
                case 6:
                    int choixTelephone;
                    do
                    {
                        Console.WriteLine("\nInsérez Téléphone du Client à supprimer\n\n");
                        choixTelephone = Convert.ToInt32(Console.ReadLine());
                        if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (choixTelephone > 9999999999 || choixTelephone < 0);
                    suppression += "TELEPHONE=" + choixTelephone + ";";
               
                    break;

                // Cas 7 : Suppression par Courriel
                case 7:
                    string choixCourriel;
                    do
                    {
                        Console.WriteLine("\nInsérez Courriel du Client à supprimer\n\n");
                        choixCourriel = Console.ReadLine();
                        if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                    } while (choixCourriel.Length > 128);
                    suppression += "COURIEL= '" + choixCourriel + "';";
               
                    break;

                // Cas 8 : Suppression par Nom
                case 8:
                    string choixNom;
                    do
                    {
                        Console.WriteLine("\nInsérez Nom du Client à supprimer\n\n");
                        choixNom = Console.ReadLine();
                        if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                    } while (choixNom.Length < 0 || choixNom.Length > 40);
                    suppression += "NOM= '" + choixNom + "';";
                
                    break;

                // Cas 9 : Suppression par Libellé
                case 9:
                    int choixLibelle;
                    do
                    {
                        Console.WriteLine("\nInsérez Libellé du Client à supprimer\n\n");
                        choixLibelle =Convert.ToInt32( Console.ReadLine());
                        if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                    } while (choixLibelle!=1 || choixLibelle!=2);
                    if (choix == 1) { libelle = "Entreprise"; }
                    else
                    {
                        libelle = "Individu";
                    }
                    suppression += "LIBELLE= '" +libelle+ "';";
          
                    break;

                // Cas 10 : Suppression par Date d'adhésion
                case 10:
                    DateTime choixDateAdhesion;
                    string date;
                    do
                    {
                        Console.WriteLine("\nInsérez Date d'adhésion du Client à supprimer (format : AAAA-MM-JJ)\n\n");
                        date = Console.ReadLine();
                        if (!DateTime.TryParse(date, out choixDateAdhesion))
                        {
                            Console.WriteLine("La saisie n'est pas une date valide\n");
                        }
                    } while (!DateTime.TryParse(date, out choixDateAdhesion));
                    suppression += "DATE_ADHESION= " + date.ToString() + "';";
               
                    break;

                // Cas 11 : Suppression par ID Programme
                case 11:
                    int choixIdProgramme;
                    do
                    {
                        Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                        choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                        if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                    } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                    suppression += "ID_PROGRAMME=" + choixIdProgramme + ";";
                  
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
        /// Fonction qui met à jour la table client
        /// </summary>
        public void Mise_a_jour()
        {
            int choix;
            do
            {
                Console.WriteLine("Quelle caractéristique voulez-vous modifier?\n" + caractéristiques);
                choix = Convert.ToInt32(Console.ReadLine());
                if (choix < 0 && choix > 11) Console.WriteLine("Saisie Invalide\n");
            } while (choix < 0 && choix > 11);
            int choix2;
            do
            {
                Console.WriteLine("En fonction de quelle caractéristique voulez-vous la modifier?\n" + caractéristiques);
                choix2 = Convert.ToInt32(Console.ReadLine());
                if (choix2 < 0 && choix2 > 11) Console.WriteLine("Saisie Invalide\n");
            } while (choix2 < 0 && choix2 > 11);
            string maj = "UPDATE CLIENT SET ";
            string choix_maj;
            int choix_majj;
            #region
            switch (choix)
            {
                
                case 1:
                    int id;
                
                    do
                    {
                        Console.WriteLine("Insérez ID_Client à mettre à jour\n\n");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (id <= 5 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (id <= 5 || id >= 100);
                    maj+= "ID_Client=" + id +" ";

                    switch (choix2)
                    {
                        // Sous-Cas 1 : Mise à jour de la Rue
                        case 1:
                           
                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:
                           
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

                  
                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

               
                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

                       
                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

             
                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;

                
                case 2:
                    
                    do
                    {
                        Console.WriteLine("Insérez Rue à mettre à jour\n\n");
                        choix_maj = Console.ReadLine();
                        Console.WriteLine();
                        if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 40);
                    maj += "RUE= '" + choix_maj + "' ";

                    switch (choix2)
                    {
                       
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:
                          
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

                     
                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

                   
                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

             
                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

                    
                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

                    
                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                    
                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;
                case 3:

                    do
                    {
                        Console.WriteLine("Insérez VILLE à mettre à jour\n\n");
                        choix_maj = Console.ReadLine();
                        Console.WriteLine();
                        if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 40);
                    maj += "VILLE= '" + choix_maj + "' ";

                    switch (choix2)
                    {

                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

              
                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

                     
                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

               
                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

                   
                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

           
                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                  
                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

                       
                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                            
                        
                         
                    }
                    break;
                case 4:


                   
                    do
                    {
                        Console.WriteLine("\nInsérez Code Postal à METTRE à jour\n\n");
                        choix_majj = Convert.ToInt32(Console.ReadLine());
                        if (choix_majj > 99999 || choix_majj < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_majj > 99999 || choix_majj < 0);
                    maj += "CODE_POSTAL=" + choix_majj + " ";

                    switch (choix2)
                    {

                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

                        
                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

                       
                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

               
                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

                    
                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

                     
                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

                    
                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                    
                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

               
                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;

                case 5:

                    do
                    {
                        Console.WriteLine("Insérez PROVINCE à mettre à jour\n\n");
                        choix_maj = Console.ReadLine();
                        Console.WriteLine();
                        if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 40);
                    maj += "PROVINCE= '" + choix_maj + "' ";

                    switch (choix2)
                    {

                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

                       
                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

                     
                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                      
                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

                
                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;
                case 6:



                    do
                    {
                        Console.WriteLine("\nInsérez telephone à METTRE à jour\n\n");
                        choix_majj = Convert.ToInt32(Console.ReadLine());
                        if (choix_majj > 9999999999 || choix_majj < 0) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_majj> 9999999999 || choix_majj < 0);
                    maj += "TELEPHONE=" + choix_majj + " ";

                    switch (choix2)
                    {

                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

                     
                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

              
                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

                
                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

     
                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

               
                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

                 
                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;


                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                     
                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

                 
                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;
                case 7:

                    do
                    {
                        Console.WriteLine("Insérez COURRIEL à mettre à jour\n\n");
                        choix_maj = Console.ReadLine();
                        Console.WriteLine();
                        if (choix_maj.Length > 128) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 128);
                    maj += "COURIEL= '" + choix_maj + "' ";

                    switch (choix2)
                    {

                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;
                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

                 
                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

           
                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

               
                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

              
                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                 
                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;
                case 8:

                    do
                    {
                        Console.WriteLine("Insérez NOM à mettre à jour\n\n");
                        choix_maj = Console.ReadLine();
                        Console.WriteLine();
                        if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_maj.Length > 40);
                    maj += "NOM= '" + choix_maj + "' ";

                    switch (choix2)
                    {

                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

                
                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

         
                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

                 
                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

                 
                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

                    
                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;
                case 9:

                
               
                    
                    do
                    {
                        Console.WriteLine("\nInsérez libellé à mettre à jour:\n1) Entreprise 2) Individu\n\n");
                        choix_majj = Convert.ToInt32(Console.ReadLine());
                        if (choix_majj != 1 || choix_majj != 2) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_majj != 1 || choix_majj != 2);
                    if (choix_majj == 1) { libelle = "Entreprise"; }
                    else
                    {
                        libelle = "Individu";
                    }
                    maj += "LIBELLE= '" + libelle + "' ";

                    switch (choix2)
                    {

                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

      
                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

                     
                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

        
                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

  
                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

             
                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;
                case 10:




                    DateTime choixDateAdhesion2;
                    string date2;
                    do
                    {
                        Console.WriteLine("\nInsérez DATE à mettre à jour (format : AAAA-MM-JJ)\n\n");
                        date2 = Console.ReadLine();
                        if (!DateTime.TryParse(date2, out choixDateAdhesion2))
                        {
                            Console.WriteLine("La saisie n'est pas une date valide\n");
                        }
                    } while (!DateTime.TryParse(date2, out choixDateAdhesion2));
                    maj += "DATE= '" + date2.ToString() + "' ";

                    switch (choix2)
                    {

                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

              
                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

            
                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

               
                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

           
                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

                 
                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

                 
                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

                            break;

                        default:
                            Console.WriteLine("Choix invalide");
                            break;
                    }
                    break;
                case 11:
                  

                    do
                    {
                        Console.WriteLine("Insérez ID PROGRAMME à mettre à jour\n\n");
                        choix_majj = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        if (choix_majj <= 5 || choix_majj >= 100) Console.WriteLine("Saisie Invalide\n");
                    } while (choix_majj <= 5 || choix_majj >= 100);
                    maj += "ID_PROGRAMME=" + choix_majj + " ";

                    switch (choix2)
                    {
                
                        case 1:

                            do
                            {
                                Console.WriteLine("En fonction de quel ID_CLIENT?\n\n");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (id <= 0 || id >= 100) Console.WriteLine("Saisie Invalide\n");
                            } while (id <= 0 || id >= 100);
                            maj += "WHERE ID_Client= " + id + ";";
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle RUE?\n\n");
                                choix_maj = Console.ReadLine();
                                if (choix_maj.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choix_maj.Length > 40);
                            maj += "WHERE RUE= '" + choix_maj + "';";

                            break;

                   
                        case 3:
                            string choixVille;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle VILLE?\n\n");
                                choixVille = Console.ReadLine();
                                if (choixVille.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixVille.Length > 40);
                            maj += "WHERE VILLE= '" + choixVille + "';";

                            break;

                        case 4:
                            int choixCodePostal;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel CODE POSTAL?\n\n");
                                choixCodePostal = Convert.ToInt32(Console.ReadLine());
                                if (choixCodePostal > 99999 || choixCodePostal < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCodePostal > 99999 || choixCodePostal < 0);
                            maj += "WHERE CODE_POSTAL= " + choixCodePostal + ";";

                            break;

                   
                        case 5:
                            string choixProvince;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quellle PROVINCE?\n\n");
                                choixProvince = Console.ReadLine();
                                if (choixProvince.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixProvince.Length > 40);
                            maj += "WHERE PROVINCE= '" + choixProvince + "';";

                            break;

                  
                        case 6:
                            int choixTelephone;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel TELEPHONE?\n\n");
                                choixTelephone = Convert.ToInt32(Console.ReadLine());
                                if (choixTelephone > 9999999999 || choixTelephone < 0) Console.WriteLine("Saisie Invalide\n");
                            } while (choixTelephone > 9999999999 || choixTelephone < 0);
                            maj += "WHERE TELEPHONE=" + choixTelephone + ";";

                            break;

                        case 7:
                            string choixCourriel;
                            do
                            {
                                Console.WriteLine("\nEn fonctionde quel COURRIEL?\n\n");
                                choixCourriel = Console.ReadLine();
                                if (choixCourriel.Length > 128) Console.WriteLine("Saisie Invalide\n");
                            } while (choixCourriel.Length > 128);
                            maj += "WHERE COURIEL= '" + choixCourriel + "';";

                            break;

                     
                        case 8:
                            string choixNom;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel NOM?\n\n");
                                choixNom = Console.ReadLine();
                                if (choixNom.Length < 0 || choixNom.Length > 40) Console.WriteLine("Saisie Invalide\n");
                            } while (choixNom.Length < 0 || choixNom.Length > 40);
                            maj += "WHERE NOM= '" + choixNom + "';";

                            break;

                    
                        case 9:
                            int choixLibelle;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quel libellé?\n1) Entreprise 2) Individu\n\n");
                                choixLibelle = Convert.ToInt32(Console.ReadLine());
                                if (choixLibelle != 1 || choixLibelle != 2) Console.WriteLine("Saisie Invalide\n");
                            } while (choixLibelle != 1 || choixLibelle != 2);
                            if (choix == 1) { libelle = "Entreprise"; }
                            else
                            {
                                libelle = "Individu";
                            }
                            maj += "WHERE LIBELLE= '" + libelle + "';";


                            break;

                        case 10:
                            DateTime choixDateAdhesion;
                            string date;
                            do
                            {
                                Console.WriteLine("\nEn fonction de quelle DATE? (format : AAAA-MM-JJ)\n\n");
                                date = Console.ReadLine();
                                if (!DateTime.TryParse(date, out choixDateAdhesion))
                                {
                                    Console.WriteLine("La saisie n'est pas une date valide\n");
                                }
                            } while (!DateTime.TryParse(date, out choixDateAdhesion));
                            maj += "WHERE DATE_ADHESION='" + date.ToString() + "';";

                            break;

             
                        case 11:
                            int choixIdProgramme;
                            do
                            {
                                Console.WriteLine("\nInsérez ID Programme du Client à supprimer\n\n");
                                choixIdProgramme = Convert.ToInt32(Console.ReadLine());
                                if (choixIdProgramme < 1 || choixIdProgramme > 4) Console.WriteLine("Saisie Invalide\n");
                            } while (choixIdProgramme < 1 || choixIdProgramme > 4);
                            maj += "WHERE ID_PROGRAMME=" + choixIdProgramme + ";";

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
        /// <summary>
        /// Fonction qui Affiche la table Client
        /// </summary>
        public void AfficherClient() 
        {
            string requete = "SELECT * FROM CLIENT";
            connexion.Command.CommandText = requete;
            MySqlDataReader reader = connexion.Command.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            Console.WriteLine("    CLIENTS :\n"+caractéristiques2);
            while (reader.Read())
            {
                int id = reader.GetInt32("ID_Client");
                string rue = reader.GetString("RUE");
                string ville = reader.GetString("VILLE");
                int code_postal = reader.GetInt32("CODE_POSTAL");
                string province = reader.GetString("PROVINCE");
                int telephone = reader.GetInt32("TELEPHONE");
                string courriel = reader.GetString("COURIEL");
                string nom = reader.GetString("NOM");
                string libelle = reader.GetString("LIBELLE");
                DateTime date_adhesion = reader.GetDateTime("DATE_ADHESION");
                int id_programme = reader.GetInt32("ID_PROGRAMME");
                //DateTime mylastupdate = (DateTime)reader["mydate"];
               


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
