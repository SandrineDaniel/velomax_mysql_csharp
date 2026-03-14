DROP DATABASE IF EXISTS VeloMax;

CREATE DATABASE IF NOT EXISTS VeloMax;
USE VeloMax;

# -----------------------------------------------------------------------------
#       TABLE : FOURNISSEUR
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS FOURNISSEUR (
   ID_FOURNISSEUR INT(2) NOT NULL,
   NOM VARCHAR(50) NOT NULL,
   ADRESSE VARCHAR(50) NOT NULL,
   CONTACT INT(10) NOT NULL,
   NOTE INT(1) NOT NULL,
   LIBELLE VARCHAR(20),
   PRIMARY KEY (ID_FOURNISSEUR)
 );
 # -----------------------------------------------------------------------------
#       TABLE : MAGASIN
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS MAGASIN (
   ID_MAGASIN INTEGER(2) NOT NULL,
   NOM_GERANT VARCHAR(50) NOT NULL,
   CHIFFRE_AFFAIRE INTEGER(2) NOT NULL,
   NOM_MAGASIN VARCHAR(50) NOT NULL,
   PRIMARY KEY (ID_MAGASIN)
 );
 
 # -----------------------------------------------------------------------------
#       TABLE : SALARIE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS SALARIE (
   ID_SALARIE INTEGER(2) NOT NULL,
   ID_MAGASIN INTEGER(2) NOT NULL,
   TYPE_CONTRAT VARCHAR(50) NOT NULL,
   SALAIRE INTEGER(2) NOT NULL,
   PRIME INTEGER(2) NOT NULL,
   NOM_SALARIE VARCHAR(50) NOT NULL,
   SATISFACTION DECIMAL(10,2) NOT NULL,
   PRIMARY KEY (ID_SALARIE),
   FOREIGN KEY (ID_MAGASIN) REFERENCES MAGASIN(ID_MAGASIN)
 );
 # -----------------------------------------------------------------------------
#       TABLE : PROGRAMME
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS PROGRAMME (
   ID_PROGRAMME SMALLINT(10) NOT NULL,
   DESCRIPTION VARCHAR(45) NOT NULL,
   COUT INT(3) NOT NULL,
   DUREE INT(1) NOT NULL,
   RABAIS DECIMAL(15,2) NOT NULL,
   PRIMARY KEY (ID_PROGRAMME)
 );

# -----------------------------------------------------------------------------
#       TABLE : CLIENT
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS CLIENT (
   ID_CLIENT INTEGER(2) NOT NULL,
   RUE VARCHAR(40) NOT NULL,
   VILLE VARCHAR(40) NOT NULL,
   CODE_POSTAL INTEGER(5) NOT NULL,
   PROVINCE VARCHAR(40) NOT NULL,
   TELEPHONE INTEGER(10) NOT NULL,
   COURIEL VARCHAR(128) NOT NULL,
   NOM VARCHAR(128) NOT NULL,
   LIBELLE CHAR(15) NOT NULL,
   DATE_ADHESION DATE NOT NULL,
   ID_PROGRAMME SMALLINT(10) NOT NULL,
  
   PRIMARY KEY (ID_CLIENT),
    FOREIGN KEY(ID_PROGRAMME) REFERENCES PROGRAMME(ID_PROGRAMME)
 );
# -----------------------------------------------------------------------------
#       TABLE : COMMANDE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS COMMANDE (
   ID_COMMANDE INTEGER(2) NOT NULL,
   ID_CLIENT INTEGER(2) NOT NULL,
   ID_SALARIE INTEGER(2) NOT NULL,
   DATE_COMMANDE DATE NOT NULL,
   DATE_LIVRAISON DATE NOT NULL,
   ADRESSE_LIVRAISON VARCHAR(50) NOT NULL,
   PRIMARY KEY (ID_COMMANDE),
   FOREIGN KEY (ID_CLIENT) REFERENCES CLIENT(ID_CLIENT),
   FOREIGN KEY (ID_SALARIE) REFERENCES SALARIE(ID_SALARIE)
 );

# -----------------------------------------------------------------------------
#       TABLE : BICYCLETTE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS BICYCLETTE (
   NUMERO INTEGER(2) NOT NULL,
   
   NOM VARCHAR(40) NOT NULL,
   GRANDEUR VARCHAR(20) NOT NULL,
   PRIX_UNITAIRE DECIMAL(25,2) NOT NULL,
   DATE_DEBUT DATE NOT NULL,
   DATE_FIN DATE NOT NULL,
   PRIMARY KEY (NUMERO)
   
 );



# -----------------------------------------------------------------------------
#       TABLE : PIECES_RECHANGE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS PIECES_RECHANGE (
   PIECE_ID INT(4) NOT NULL,
   DESCRIPTION VARCHAR(50) NOT NULL,
   DATE_DEBUT DATE NOT NULL,
   DATE_FIN DATE NOT NULL,
   DELAI INTEGER(2) NOT NULL,
   ID_FOURNISSEUR INT(2) NOT NULL,
   PRIX DECIMAL(6,3) NOT NULL,
   ID_CATALOGUE VARCHAR(5),
   NUMERO INT(2) NOT NULL,
   PRIMARY KEY (PIECE_ID) ,
   FOREIGN KEY (ID_FOURNISSEUR) REFERENCES FOURNISSEUR(ID_FOURNISSEUR),
   FOREIGN KEY(NUMERO) REFERENCES BICYCLETTE(NUMERO)
 );
 # -----------------------------------------------------------------------------
#       TABLE : PASSE_PIECE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS PASSE_PIECE (
   ID_COMMANDE INTEGER(2) NOT NULL,
   PIECE_ID INT(4) NOT NULL,
   QUANTITE_P CHAR(32) NULL,
   PRIMARY KEY (ID_COMMANDE,PIECE_ID),
   FOREIGN KEY (ID_COMMANDE) REFERENCES COMMANDE(ID_COMMANDE),
   FOREIGN KEY (PIECE_ID) REFERENCES PIECES_RECHANGE(PIECE_ID)
 );

# -----------------------------------------------------------------------------
#       TABLE : LIGNE_PRODUIT
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS LIGNE_PRODUIT (
   PRODUIT_ID SMALLINT(10) NOT NULL,
   NOM_LIGNE VARCHAR(40) NOT NULL,
   PRIMARY KEY (PRODUIT_ID)
 );






# -----------------------------------------------------------------------------
#       TABLE : PASSE_BICYCLETTE
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS PASSE_BICYCLETTE (
   NUMERO INTEGER(2) NOT NULL,
   ID_COMMANDE INTEGER(2) NOT NULL,
   QUANTITE_B INTEGER(2) NOT NULL,
   PRIMARY KEY (NUMERO,ID_COMMANDE),
   FOREIGN KEY (NUMERO) REFERENCES BICYCLETTE(NUMERO),
   FOREIGN KEY (ID_COMMANDE) REFERENCES COMMANDE(ID_COMMANDE)
 );



# -----------------------------------------------------------------------------
#       TABLE : FOURNIT
# -----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS FOURNIT (
   PIECE_ID INT(4) NOT NULL,
   ID_FOURNISSEUR INTEGER(2) NOT NULL,
   PRIMARY KEY (PIECE_ID,ID_FOURNISSEUR),
   FOREIGN KEY (PIECE_ID) REFERENCES PIECES_RECHANGE(PIECE_ID),
   FOREIGN KEY (ID_FOURNISSEUR) REFERENCES FOURNISSEUR(ID_FOURNISSEUR)
 );
 
 
 
 INSERT INTO BICYCLETTE (NUMERO, NOM, GRANDEUR, PRIX_UNITAIRE, DATE_DEBUT, DATE_FIN) VALUES
(101, 'Kilimandjaro', 'Adultes', 569.00, '2023-03-01', '2024-12-31'),
(102, 'NorthPole', 'Adultes', 329.00, '2022-01-05', '2022-12-31'),
(103, 'MontBlanc', 'Jeunes', 399.00, '2024-02-10', '2024-12-31'),
(104, 'Hooligan', 'Jeunes', 199.00, '2024-03-15', '2024-12-31'),
(105, 'Orléans', 'Hommes', 229.00, '2024-04-20', '2021-12-31'),
(106, 'Orléans', 'Dames', 229.00, '2024-05-25', '2022-12-31'),
(107, 'BlueJay', 'Hommes', 349.00, '2024-06-30', '2023-12-31'),
(108, 'BlueJay', 'Dames', 349.00, '2024-07-10', '2023-12-31'),
(109, 'Trail Explorer', 'Filles', 129.00, '2024-08-15', '2024-12-31'),
(110, 'Trail Explorer', 'Garçons', 129.00, '2024-09-20', '2024-12-31'),
(111, 'Night Hawk', 'Jeunes', 189.00, '2024-10-25', '2024-12-31'),
(112, 'Tierra Verde', 'Hommes', 199.00, '2024-11-30', '2021-12-31'),
(113, 'Tierra Verde', 'Dames', 199.00, '2024-12-05', '2022-12-31'),
(114, 'Mud Zinger I', 'Jeunes', 279.00, '2024-01-10', '2023-12-31'),
(115, 'Mud Zinger II', 'Adultes', 359.00, '2024-02-15', '2022-12-31');

INSERT INTO FOURNISSEUR (ID_FOURNISSEUR, NOM, ADRESSE, CONTACT, NOTE, LIBELLE) VALUES
(1, 'Fournisseur1', 'Adresse1', 234567890, 5, 'Libelle1'),
(7, 'Fournisseur2', 'Adresse2', 345678901, 4, 'Libelle2'),
(8, 'Fournisseur3', 'Adresse3', 456789012, 3, 'Libelle3'),
(9, 'Fournisseur4', 'Adresse4', 467890123, 5, 'Libelle4'),
(12, 'Fournisseur5', 'Adresse5', 578901234, 4, 'Libelle5'),
(11, 'Fournisseur5', 'Adresse5', 568901234, 4, 'Libelle5'),
(13, 'Fournisseur5', 'Adresse5', 568901234, 4, 'Libelle5'),
(14, 'Fournisseur5', 'Adresse5', 567801234, 4, 'Libelle5'),
(15, 'Fournisseur5', 'Adresse5', 567901234, 4, 'Libelle5');

INSERT INTO PIECES_RECHANGE (PIECE_ID, DESCRIPTION, DATE_DEBUT, DATE_FIN, DELAI, ID_FOURNISSEUR, PRIX, ID_CATALOGUE,NUMERO) VALUES
(1, 'Cadre', '2023-01-01', '2024-12-31', 10, 1, 20.00, 'C32',101),
(2, 'Guidon', '2024-01-01', '2024-12-31', 7, 7, 10.00, 'G7',101),
(3, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 150.00, 'F3',101),
(4, 'Selle', '2024-01-01', '2024-12-31', 7, 12, 50.00, 'S88',101),
(5, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'DV133',101),
(6, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 9, 110.00, 'DR56',101),
(7, 'Roue avant', '2024-01-01', '2024-12-31', 7, 7, 200.00, 'R45',101),
(8, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 8, 210.00, 'R46',101),
(9, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 9, 15.00, 'NA',101),
(10, 'Pédalier', '2024-01-01', '2024-12-31', 7, 1, 90.00, 'P12',101),
(11, 'Ordinateur', '2024-01-01', '2024-12-31', 7, 11, 75.00, '02',101),
(12, 'Panier', '2024-01-01', '2024-12-31', 7, 14, 25.00, 'NA',101),

(115, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 260.00, 'C34',102),
(116, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 270.00, 'C76',103),
(13, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 270.00, 'C76',104),
(14, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 270.00, 'C43',105),
(15, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 270.00, 'C44f',106),
(16, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 280.00, 'C43',107),
(17, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 280.00, 'C43f',108),
(18, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 270.00, 'C01',109),
(19, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 280.00, 'C02',110),
(110, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 270.00, 'C15',111),
(111, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 280.00, 'C87',112),
(112, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 280.00, 'C87f',113),
(113, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 270.00, 'C25',114),
(114, 'Cadre', '2024-01-01', '2024-12-31', 7, 1, 280.00, 'C26',115),

-- Guidon
(21, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 50.00, 'G7',102),
(22, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 50.00, 'G7',103),
(23, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 50.00, 'G7',104),
(24, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G9',105),
(25, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G9',106),
(26, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G9',107),
(27, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G9',108),
(28, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G12',109),
(29, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G12',110),
(210, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G12',111),
(211, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G12',112),
(212, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G12',113),
(213, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G7',114),
(214, 'Guidon', '2024-01-01', '2024-12-31', 7, 13, 55.00, 'G7',115),

-- Freins

(31, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 80.00, 'F3',102),
(32, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 80.00, 'F3',103),
(33, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 80.00, 'F3',104),
(34, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 80.00, 'F3',114),
(35, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 80.00, 'F3',115),
(36, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 85.00, 'F9',105),
(37, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 85.00, 'F9',106),
(38, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 85.00, 'F9',107),
(39, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 85.00, 'F9',108),
(310, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 85.00, 'F9',111),
(320, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 85.00, 'F9',112),
(330, 'Freins', '2024-01-01', '2024-12-31', 7, 14, 85.00, 'F9',113),

-- Selle

(41, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 30.00, 'S88',102),
(42, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 30.00, 'S88',103),
(43, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 30.00, 'S88',104),
(44, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 35.00, 'S37',105),
(45, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 35.00, 'S37',107),
(46, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 35.00, 'S35',106),
(47, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 35.00, 'S35',108),
(48, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 35.00, 'S02',109),
(49, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 35.00, 'S03',110),
(410, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 35.00, 'S36',111),
(420, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 35.00, 'S36',112),
(430, 'Selle', '2024-01-01', '2024-12-31', 7, 15, 35.00, 'S34',113),

-- Dérailleur Avant

(51, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 1, 90.00, 'DV133',115),
(52, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 1, 95.00, 'DV17',102),
(53, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 1, 95.00, 'DV17',103),
(54, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 1, 95.00, 'DV87',104),
(55, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 1, 95.00, 'DV57',105),
(56, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 1, 95.00, 'DV57',106),
(57, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 1, 95.00, 'DV57',107),
(58, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 7, 95.00, 'DV57',108),
(59, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 7, 95.00, 'DV15',111),
(510, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 1, 95.00, 'DV41',112),
(512, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 13, 95.00, 'DV41',113),
(513, 'Dérailleur Avant', '2024-01-01', '2024-12-31', 7, 11, 95.00, 'DV132',114),


-- Dérailleur Arrière
(61, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 80.00, 'DR87',102),
(62, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 80.00, 'DR87',103),
(63, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 80.00, 'DR87',107),
(64, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 80.00, 'DR87',108),
(65, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 85.00, 'DR86',104),
(66, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 85.00, 'DR86',105),
(67, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 85.00, 'DR86',106),
(68, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 85.00, 'DR23',111),
(69, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 85.00, 'DR76',113),
(610, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 85.00, 'DR76',112),
(611, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 85.00, 'DR52',114),
(612, 'Dérailleur Arrière', '2024-01-01', '2024-12-31', 7, 7, 85.00, 'DR52',115),

-- Roue avant
(71, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R48',102),
(72, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R48',103),
(73, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 125.00, 'R12',104),
(74, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R19',105),
(75, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R19',106),
(76, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R19',107),
(77, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R19',108),
(78, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R1',109),
(79, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R1',110),
(710, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R11',111),
(711, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R11',112),
(712, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R11',113),
(713, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R44',114),
(714, 'Roue avant', '2024-01-01', '2024-12-31', 7, 8, 120.00, 'R44',115),


-- Roue arrière
(81, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R47',102),
(82, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R47',103),
(83, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R47',114),
(84, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R47',115),
(85, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R32',104),
(86, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R18',105),
(87, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R18',106),
(88, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R18',107),
(89, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R18',108),
(810, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R2',109),
(811, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R2',110),
(812, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R12',111),
(813, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R12',112),
(814, 'Roue arrière', '2024-01-01', '2024-12-31', 7, 9, 130.00, 'R12',113),


-- Réflecteurs
(91, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 11, 10.00, 'R02',105),
(92, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 11, 10.00, 'R02',106),
(93, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 11, 10.00, 'R02',107),
(94, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 11, 10.00, 'R02',108),
(95, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 11, 10.00, 'R09',109),
(96, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 11, 10.00, 'R09',110),
(97, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 9, 10.00, 'R10',111),
(98, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 9, 10.00, 'R10',112),
(99, 'Réflecteurs', '2024-01-01', '2024-12-31', 7, 9, 10.00, 'R10',113),


-- Pédalier
(101, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P12',102),
(102, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P12',103),
(103, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P12',104),
(104, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P12',114),
(105, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P12',115),
(106, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P34',105),
(107, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P34',106),
(108, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P34',107),
(109, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P34',108),
(1001, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P1',109),
(1002, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P1',110),
(1003, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P15',111),
(1004, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P15',112),
(1005, 'Pédalier', '2024-01-01', '2024-12-31', 7, 11, 60.00, 'P15',113),


-- Ordinateur
(1101, 'Ordinateur', '2024-01-01', '2024-12-31', 7, 13, 40.00, 'O2',103),
(1102, 'Ordinateur', '2024-01-01', '2024-12-31', 7, 13, 45.00, 'O4',107),
(1103, 'Ordinateur', '2024-01-01', '2024-12-31', 7, 13, 45.00, 'O4',108),

-- Panier
(1201, 'Panier', '2024-01-01', '2024-12-31', 7, 14, 20.00, 'S01',109),
(1202, 'Panier', '2024-01-01', '2024-12-31', 7, 14, 20.00, 'S05',110),
(1203, 'Panier', '2024-01-01', '2024-12-31', 7, 14, 25.00, 'S74',111),
(1204, 'Panier', '2024-01-01', '2024-12-31', 7, 14, 25.00, 'S74',112),
(1205, 'Panier', '2024-01-01', '2024-12-31', 7, 14, 25.00, 'S73',113);




INSERT INTO PROGRAMME (ID_PROGRAMME, DESCRIPTION,COUT, DUREE, RABAIS) VALUES
(1, 'Fidélio' , 15, 1,0.05),
(2, 'Fidélio Or', 25,2,0.08),
(3, 'Fidélio Platine', 60,2,0.1),
(4, 'Fidélio Max', 100,3,0.12);


SELECT * FROM PIECES_RECHANGE;
