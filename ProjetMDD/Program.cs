using MySql.Data.MySqlClient;
using ProjetMDD;
using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connexionString;
            string optionsRoot = "1) Afficher Stock \n2) Modification \n3) Statistiques \n4) Mode Démo \n5) Afficher\n6) Sortir";
            string optionsbozo = "1) Afficher \n2) Statistiques\n3) Sortir";
            string tables = "1) Client \n2) Fournisseur \n3) Bicyclette \n4) Pièces de rechange \n5) Salarié \n6) Commande";
            string choix_modification = "1) Insérer dans une table \n2) Suppression\n3) Mise à jour";


            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("                                                 VELO MAX");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n\n\n\n\nAppuyez sur entrer...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Connectez vous: \n1) Root      2) Bozo\n");
            Console.ForegroundColor = ConsoleColor.White;
            int choix_identifiant;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nSaisir numéro Identifiant:");              //Choix identifiant
                choix_identifiant = Convert.ToInt32(Console.ReadLine());
                if (choix_identifiant != 1 && choix_identifiant != 2) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Saisie invalide"); }
            } while (choix_identifiant != 1 && choix_identifiant != 2);

            string mdp;
            bool continuer = true;
            do
            {
                continuer = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nSaisir mot de passe:");    //Mot de passe
                mdp = Console.ReadLine();

                if (choix_identifiant == 1 && mdp != "root") { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nMot de passe invalide"); continuer = false; }
                else if (choix_identifiant == 2 && mdp != "bozo") { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nMot de passe invalide"); continuer = false; }
            } while (continuer == false);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            bool Continuer_menu = true;
            do                  //Entrer dans le menu
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                 BIENVENUE CHEZ VELOMAX!");
                Console.WriteLine("\n\n\n\n");
                int n;
                Console.ForegroundColor = ConsoleColor.White;
                if (choix_identifiant == 1)  //Si root faire options suivantes
                {
                    do
                    {
                        Console.WriteLine("Que voulez vous faire?\n\n\n" + optionsRoot);
                        n = Convert.ToInt32(Console.ReadLine());          //Choix utilisateur root
                    } while (n < 0 && n > 5);
                    Console.WriteLine("");

                    Console.Clear();
                    switch (n)
                    {
                        case 1: //Afficher stock
                            Requetes gestion = new Requetes();
                            gestion.Gestion_Stock();
                            break;
                        case 2:  // Modification

                            int choix_modif;
                            int choix_table;
                            do
                            {
                                Console.WriteLine("Quelle table voulez-vous modifier?\n\n" + tables);
                                choix_table = Convert.ToInt32(Console.ReadLine());
                                if (choix_table < 0 && choix_table > 6) Console.WriteLine("Saisie Invalide");      //Saisie sécurisée sur la table à modifier
                            } while (choix_table < 0 && choix_table > 6);
                            do
                            {
                                Console.WriteLine("Que voulez-vous faire?\n\n" + choix_modification);
                                choix_modif = Convert.ToInt32(Console.ReadLine());              //Saisie sécurisée choix modification
                                if (choix_modif < 0 && choix_modif > 3) Console.WriteLine("Saisie Invalide");
                            } while (choix_modif < 0 && choix_modif > 3);
                            Requetes Modification = new Requetes();
                            Modification.Modification(choix_table, choix_modif);

                            break;
                        case 3: //Statistiques
                            Requetes stat = new Requetes();
                            stat.Module_Statistique(1);
                            break;
                        case 4:  //Mode Démo
                            Client client = new Client();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("                 Bienvenue dans le mode démo!\n\n\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n1) Afficher Client\n\n");
                            client.AfficherClient();
                            Console.WriteLine("Appuyez sur entrer...");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("\n2) Insertion Client\n\n");
                            client.Creation_Client();
                            client.AfficherClient();
                            Console.WriteLine("Appuyez sur entrer...");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("\n3) Suppression Client\n\n");
                            client.Suppression_Client();
                            client.AfficherClient();
                            Console.WriteLine("Appuyez sur entrer...");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("\n4) Modification client\n\n");
                            client.Mise_a_jour();
                            client.AfficherClient();
                            Console.WriteLine("Appuyez sur entrer...");
                            Console.ReadLine();
                            Console.Clear();
                            Console.Clear();
                            Console.WriteLine("Requêtes définies");
                            Requetes r = new Requetes();
                            r.Requete();
                            break;
                        case 6:  //Sortir
                            Continuer_menu = false;
                            break;
                        case 5:  //Afficher

                            int choix_table2;
                            do
                            {
                                Console.WriteLine("\nQuelle table voulez-vous Afficher?\n\n" + tables);
                                choix_table2 = Convert.ToInt32(Console.ReadLine());                        //Demander quelle table à afficher
                                if (choix_table2 < 0 && choix_table2 > 6) Console.WriteLine("Saisie Invalide");
                            } while (choix_table2 < 0 && choix_table2 > 6);
                            //1) Client \n2) Fournisseur \n3) Bicyclette \n4) Pièces de rechange \n5) Salarié \n6) Commande";
                            Console.Clear();
                            switch (choix_table2)
                            {
                                case 1:
                                    Client c = new Client();
                                    c.AfficherClient();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 2:
                                    Fournisseur f = new Fournisseur();
                                    f.AfficherFournisseur();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 3:
                                    Bicyclette b = new Bicyclette();
                                    b.AfficherVelo();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 4:
                                    Pièces p = new Pièces();
                                    p.AfficherPiece();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 5:
                                    Salarié s = new Salarié();
                                    s.AfficherSalarie();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 6:
                                    Commande com = new Commande();
                                    com.AfficherCommande();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();

                                    break;
                            }
                            break;
                    }
                }
                else //Si bozo faire options suivantes
                {
                    do
                    {
                        Console.WriteLine("Que voulez vous faire?\n\n\n" + optionsbozo);
                        n = Convert.ToInt32(Console.ReadLine());
                    } while (n < 0 && n > 3);
                    Console.Clear();
                    switch (n)
                    {
                        case 1: //Afficher

                            int choix_table;
                            do
                            {
                                Console.WriteLine("Quelle table voulez-vous Afficher?\n\n" + tables);
                                choix_table = Convert.ToInt32(Console.ReadLine());
                                if (choix_table < 0 && choix_table > 6) Console.WriteLine("Saisie Invalide");
                            } while (choix_table < 0 && choix_table > 6);
                            //1) Client \n2) Fournisseur \n3) Bicyclette \n4) Pièces de rechange \n5) Salarié \n6) Commande";
                            switch (choix_table)
                            {
                                case 1:
                                    Client c = new Client();
                                    c.AfficherClient();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 2:
                                    Fournisseur f = new Fournisseur();
                                    f.AfficherFournisseur();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 3:
                                    Bicyclette b = new Bicyclette();
                                    b.AfficherVelo();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 4:
                                    Pièces p = new Pièces();
                                    p.AfficherPiece();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 5:
                                    Salarié s = new Salarié();
                                    s.AfficherSalarie();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case 6:
                                    Commande com = new Commande();
                                    com.AfficherCommande();
                                    Console.WriteLine("Appuyez sur entrer...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }
                            break;
                        case 2: //Stat
                            Requetes stat = new Requetes();
                            stat.Module_Statistique(2);
                            break;
                        case 3:  // Sortir
                            Continuer_menu = false;
                            break;
                    }
                }
                Console.Clear();
            } while (Continuer_menu == true);


        }
    }
}



