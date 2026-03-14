using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMDD
{
    internal class Requetes
    {
        Connexion connexion = new Connexion();
        Connexion connexion2 = new Connexion(2);
        public Requetes() { }

        /// <summary>
        /// Fonction qui envoie les requêtes du module statistique
        /// </summary>
        /// <param name="n"></param>
        public void Module_Statistique(int n)
        {

            #region Requete 
            Console.ForegroundColor = ConsoleColor.Red;
            string requete = "SELECT M.NOM_MAGASIN, P.PIECE_ID, SUM(passe_piece.QUANTITE_P) FROM magasin M\r\njoin pieces_rechange P on P.ID_MAGASIN=M.ID_MAGASIN\r\njoin passe_piece on passe_piece.PIECE_ID=P.PIECE_ID\r\ngroup by passe_piece.PIECE_ID;\n\n";
            Console.WriteLine("Quantités vendues de chaque pièce qui se trouve dans l’inventaire de VéloMax dans son ensemble, par magasin:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (n==1)connexion.Command.CommandText = requete;
            else connexion2.Command2.CommandText = requete;
            try
            {
                if(n==1)connexion.Command.ExecuteNonQuery();
                else connexion2.Command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }
            MySqlDataReader reader;
            if (n == 1) reader = connexion.Command.ExecuteReader(); 
            else reader=connexion2.Command2.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("\nAppuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();

            #region Requete1 
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT M.NOM_MAGASIN, bicyclette.NUMERO, SUM(passe_bicyclette.QUANTITE_B) FROM magasin M\r\njoin bicyclette on bicyclette.ID_MAGASIN=M.ID_MAGASIN\r\njoin passe_bicyclette on passe_bicyclette.NUMERO=bicyclette.NUMERO\r\ngroup by passe_bicyclette.NUMERO;\n\n";
            Console.WriteLine("Quantités vendues de chaque bicyclette qui se trouve dans l’inventaire de VéloMax dans son ensemble, par magasin:\n\n" + requete+"\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (n == 1) connexion.Command.CommandText = requete;
            else connexion2.Command2.CommandText = requete;
            try
            {
                if (n == 1) connexion.Command.ExecuteNonQuery();
                else connexion2.Command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            if (n == 1) reader = connexion.Command.ExecuteReader();
            else reader = connexion2.Command2.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("\nAppuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();

            #region Requete2
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT programme.DESCRIPTION, client.NOM, (client.DATE_ADHESION+programme.DUREE) AS date_expiration from programme\r\njoin client on client.ID_PROGRAMME=programme.ID_PROGRAMME;\n\n";
            Console.WriteLine("La liste des membres pour chaque programme d’adhésion:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (n == 1) connexion.Command.CommandText = requete;
            else connexion2.Command2.CommandText = requete;
            try
            {
                if (n == 1) connexion.Command.ExecuteNonQuery();
                else connexion2.Command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            if (n == 1) reader = connexion.Command.ExecuteReader();
            else reader = connexion2.Command2.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("\nAppuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();

            #region Requete3
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT client.NOM, SUM(commande.PRIX_COMMANDE)AS Montant_depensé from client\r\njoin commande on commande.ID_CLIENT=client.ID_CLIENT\r\ngroup by(commande.ID_CLIENT)\r\norder by Montant_depensé desc;";
            Console.WriteLine("Meilleur clients en fonction des quantités vendues en nombre de \r\npièces vendues ou en cumul en euros  :\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (n == 1) connexion.Command.CommandText = requete;
            else connexion2.Command2.CommandText = requete;
            try
            {
                if (n == 1) connexion.Command.ExecuteNonQuery();
                else connexion2.Command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            if (n == 1) reader = connexion.Command.ExecuteReader();
            else reader = connexion2.Command2.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("\nAppuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();

            #region Requete4
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT avg(PRIX_COMMANDE) AS montant_moyen FROM COMMANDE;";
            Console.WriteLine(" Moyenne du montant des commandes:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (n == 1) connexion.Command.CommandText = requete;
            else connexion2.Command2.CommandText = requete;
            try
            {
                if (n == 1) connexion.Command.ExecuteNonQuery();
                else connexion2.Command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            if (n == 1) reader = connexion.Command.ExecuteReader();
            else reader = connexion2.Command2.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("\nAppuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();

            #region Requete5
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT avg(QUANTITE_P) AS quantité_moyenne_piece FROM passe_piece;";
            Console.WriteLine(" Moyenne du nombre de pièces par commande:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (n == 1) connexion.Command.CommandText = requete;
            else connexion2.Command2.CommandText = requete;
            try
            {
                if (n == 1) connexion.Command.ExecuteNonQuery();
                else connexion2.Command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            if (n == 1) reader = connexion.Command.ExecuteReader();
            else reader = connexion2.Command2.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("\nAppuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();
            #region Requete6
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT avg(QUANTITE_B) AS quantité_moyenne_bicyclette FROM passe_bicyclette;";
            Console.WriteLine(" Moyenne du nombre de vélos par commande:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (n == 1) connexion.Command.CommandText = requete;
            else connexion2.Command2.CommandText = requete;
            try
            {
                if (n == 1) connexion.Command.ExecuteNonQuery();
                else connexion2.Command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            if (n == 1) reader = connexion.Command.ExecuteReader();
            else reader = connexion2.Command2.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("\nAppuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();

            #region Requete7
            requete = "SELECT PRIME, SATISFACTION FROM salarie;";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Calcul des bonus des salariés en fonction de la satisfaction client:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (n == 1) connexion.Command.CommandText = requete;
            else connexion2.Command2.CommandText = requete;
            try
            {
                if (n == 1) connexion.Command.ExecuteNonQuery();
                else connexion2.Command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            if (n == 1) reader = connexion.Command.ExecuteReader();
            else reader = connexion2.Command2.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("\nAppuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();

            #region Requete8
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT avg(PRIME) from salarie;";
            Console.WriteLine("Bonus moyen :\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (n == 1) connexion.Command.CommandText = requete;
            else connexion2.Command2.CommandText = requete;
            try
            {
                if (n == 1) connexion.Command.ExecuteNonQuery();
                else connexion2.Command2.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }

            if (n == 1) reader = connexion.Command.ExecuteReader();
            else reader = connexion2.Command2.ExecuteReader();
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("\nAppuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();
        }



        /// <summary>
        /// Fonction qui renvoie les requêtes du mode démo
        /// </summary>
        public void Requete()
        {

            #region Requete 
            Console.ForegroundColor = ConsoleColor.Red;
            string requete = "SELECT COUNT(*) FROM CLIENT;\n\n";
            Console.WriteLine("Nombre de clients:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            connexion.Command.CommandText = requete;

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
            MySqlDataReader reader = connexion.Command.ExecuteReader();

            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("Appuyez sur entrer...");
            Console.ReadLine();
       
            Console.Clear();

            #region Requete 1
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "select Cl.NOM, SUM(C.PRIX_COMMANDE) FROM COMMANDE C\r\njoin CLIENT Cl on Cl.ID_CLIENT=C.ID_CLIENT\r\nGROUP BY C.ID_CLIENT;\n\n";
            Console.WriteLine("Nom d'un client avec le cumul de toutes ses commandes en euro:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            connexion.Command.CommandText = requete;

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
            reader = connexion.Command.ExecuteReader();

                valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("Appuyez sur entrer...");
            Console.ReadLine();
            Console.Clear();
            #region Requete 2
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT PIECE_ID, ID_CATALOGUE FROM pieces_rechange\r\nwhere STOCK_PIECE<2;\n\n";
            Console.WriteLine("Liste des produit avec un stock inferieur à 2:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            connexion.Command.CommandText = requete;

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
            reader = connexion.Command.ExecuteReader();

           valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("Appuyez sur entrer...");
            Console.ReadLine();
            Console.Clear();
            #region Requete 3   
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT F.ID_FOURNISSEUR, COUNT(P.PIECE_ID) FROM FOURNISSEUR F\r\njoin PIECES_RECHANGE P on P.ID_FOURNISSEUR=F.ID_FOURNISSEUR\r\nGROUP BY F.ID_FOURNISSEUR;\n\n";
            Console.WriteLine("Nombre de piece par fournisseur:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            connexion.Command.CommandText = requete;

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
            reader = connexion.Command.ExecuteReader();

            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("Appuyez sur entrer...");
            Console.ReadLine();
            Console.Clear();

            #region Requete 4  
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT M.CHIFFRE_AFFAIRE, S.ID_SALARIE, SUM(C.PRIX_COMMANDE) FROM magasin M\r\njoin SALARIE S on S.ID_MAGASIN=M.ID_MAGASIN\r\njoin COMMANDE C on C.ID_SALARIE=S.ID_SALARIE\r\nGROUP BY C.ID_SALARIE;\n\n";
            Console.WriteLine("Chiffre d'affaire des magasins et vente generee par salariés:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            connexion.Command.CommandText = requete;

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
            reader = connexion.Command.ExecuteReader();

            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("Appuyez sur entrer...");
            Console.ReadLine();
            Console.Clear();
        }
        /// <summary>
        /// Fonction qui affiche le stock
        /// </summary>
        public void Gestion_Stock()
        {

            #region Requete 
            Console.ForegroundColor = ConsoleColor.Red;
            string requete = "SELECT PIECE_ID, ID_CATALOGUE, STOCK_PIECE from pieces_rechange;\n\n";
            Console.WriteLine("Stock pièces:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            connexion.Command.CommandText = requete;

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
            MySqlDataReader reader = connexion.Command.ExecuteReader();

            string[] valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("Appuyez sur entrer...");
            Console.ReadLine();

            Console.Clear();

            #region Requete 1
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT NUMERO, NOM, STOCK_VELO FROM BICYCLETTE;\n\n";
            Console.WriteLine("Stock Vélo:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            connexion.Command.CommandText = requete;

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
            reader = connexion.Command.ExecuteReader();

            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("Appuyez sur entrer...");
            Console.ReadLine();
            Console.Clear();
            #region Requete 1
            Console.ForegroundColor = ConsoleColor.Red;
            requete = "SELECT magasin.ID_MAGASIN, magasin.NOM_MAGASIN, P.PIECE_ID, P.STOCK_PIECE, B.NUMERO, B.STOCK_VELO from magasin \r\njoin pieces_rechange P on P.ID_MAGASIN=magasin.ID_MAGASIN\r\njoin BiCYCLETTE B on B.ID_MAGASIN=magasin.ID_MAGASIN;\n\n";
            Console.WriteLine("Stock magasin:\n\n" + requete + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            connexion.Command.CommandText = requete;

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
            reader = connexion.Command.ExecuteReader();

            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    //  valueString[i] = reader1.GetString(i);
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            reader.Close();
            #endregion
            Console.WriteLine("Appuyez sur entrer...");
            Console.ReadLine();
            Console.Clear();
        }
        /// <summary>
        /// Fonction qui appelle les fonctions des classes des tables pour modifier la table choisie
        /// </summary>
        /// <param name="choix_table">choix de la table à modifier</param>
        /// <param name="choix_modification">Choix de la caractéristique</param>
        public void Modification(int choix_table, int choix_modification)
        {//"1) Insérer dans une table \n2) Suppression\n3) Mise à jour";
         // string tables = "1) Client \n2) Fournisseur \n3) Bicyclette \n4) Pièces de rechange \n5) Salarié \n6) Commande";
            switch (choix_table)
            {
                case 1:
                    Client c = new Client();
                    switch (choix_modification)
                    {
                        case 1:
                            
                            c.Creation_Client();
                            break;
                        case 2:
                            c.Suppression_Client();
                            break;
                        case 3:
                            c.Mise_a_jour();
                            break;
                    }
                    break;
                case 2:
                    Fournisseur f= new Fournisseur();
                    switch(choix_modification)
                    {
                        case 1:
                           f.Creation_fournisseur();
                            break;
                        case 2:
                            f.Suppression_fournisseur();
                            break;
                        case 3:
                            f.Maj_fournisseur();
                            break;

                    }

                    break;
                case 3:
                    Bicyclette b = new Bicyclette();
                    switch (choix_modification)
                    {
                        case 1:
                            b.Creation_VELO();
                            break;
                        case 2:
                            b.Suppression_Velo();
                            break;
                        case 3:
                            b.Maj_velo();
                            break;

                    }


                    break;
                case 4:
                    Pièces p = new Pièces();
                    switch (choix_modification)
                    {
                       case 1:
                        p.Creation_PIECES_RECHANGEt();
                            break;
                        case 2:
                          p.Suppression_Piece();
                            break;
                        case 3:
                            p.Maj_PIECE();
                            break;

                    }
                    break;

                case 5:
                    Salarié s = new Salarié();
                    switch (choix_modification)
                    {
                        case 1:
                            s.Cration_salarie();
                            break;
                        case 2:
                            s.Suppression_salarie();
                            break;
                        case 3:
                            s.Maj_Salarie();
                            break;

                    }
                    break;
                case 6:
                    Commande com=new Commande();
                    switch (choix_modification)
                    {
                        case 1:
                            com.Creation_Commande();
                            break;
                        case 2:
                            com.Suppression_commande();
                            break;
                        case 3:
                            com.Maj_Salarie();
                            break;
                    }
                    break;
            }
        }
    }
}
