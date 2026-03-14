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
    internal class Pièces
    {
        int piece_id;
        string description;
        DateTime Datedebut;
        DateTime Datefin;
        int delai;
        int idfournisseur;
        double prix;
        int id_catalogue;
        int numero;
        int stock_piece;
        int id_magasin;
        string caractéristiques = "1) piece_id\n2) description\n3) date_début\n4) date_fin\n5) delai\n6) id_fournisseur\n7) prix\n8) id_catalogue\n9) numero\n10) stock_piece\n11) id_magasin\n";
        string caractéristiques2 = "1) Id pièce 2) Description 3) Date début 4) Date fin 5) delai 6) Id fournisseur 7) prix 8) Id catalogue 9) numero 10) stock_piece 11) Magasin\n";
        Connexion connexion = new Connexion();
        public Pièces() { }
        /// <summary>
        /// Insérer tuples à pièces rechange
        /// </summary>
        public void Creation_PIECES_RECHANGEt()
        {
            string insertTable = " INSERT INTO PIECES_RECHANGE VALUES (";
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
        /// Supprimer pièce de rechange
        /// </summary>
        public void Suppression_Piece()
        {

            string suppression = "DELETE FROM PIECES_RECHANGE WHERE ";
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
        ///   Afficher tuples de la table Pièce de rechange
        /// </summary>
        public void AfficherPiece()
        {

            string requete = "SELECT * FROM PIECES_RECHANGE";
            connexion.Command.CommandText = requete;
            MySqlDataReader reader = connexion.Command.ExecuteReader();
            string[] valueString = new string[reader.FieldCount];
            Console.WriteLine("   PIECES_RECHANGE :\n" + caractéristiques2);
            while (reader.Read())
            {
                int piece_id = reader.GetInt32("piece_id");
                string description = reader.GetString("description");
                DateTime Datedebut = reader.GetDateTime("Datedebut");
                DateTime Datefin = reader.GetDateTime("Datefin");
                int delai = reader.GetInt32("delai");
                int idfournisseur = reader.GetInt32("idfournisseur");
                double prix = reader.GetDouble("prix");
                int id_catalogue = reader.GetInt32("id_catalogue");
                int numero = reader.GetInt32("numero");
                int stock_piece = reader.GetInt32("stock_piece");
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
        /// <summary>
        /// Mise à jour table pièce de rechange
        /// </summary>
        public void Maj_PIECE()
        {
            Console.WriteLine("Modification: \n\nExemple: UPDATE PIECES_RECHANGE SET PIECE_ID=5 WHERE ID_FOURNISSEUR=5 ");
            Console.WriteLine("Rappel des carctéristiques:" + caractéristiques + "\n\nComplétez: UPDATE PIECES_RECHANGE SET");
            string maj = "UPDATE PIECES_RECHANGE SET ";

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
    }
}
