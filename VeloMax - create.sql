drop database if exists VeloMax;

create database VeloMax;

use VeloMax;

create table Bicyclette (
	numero_prod_B int not null,
    nom_B varchar(45),
    grandeur_B enum('Adulte', 'Homme', 'Femme', 'Jeune', 'Fille', 'Garçon'),
    prix_B int,
    ligne_produit_B enum('VTT', 'Vélo de course', 'Classique', 'BMX' ),
    date_intro_B date,
    date_disc_B date,
    primary key(numero_prod_B)
);

create table Pièce (
	numero_prod_P int not null,
    desc_prod_P varchar(200),
    date_intro_P date,
    date_disc_P date,
    quantite_P int,
    type_P enum('Cadre','Guidon','Freins','Selle','Dérailleur Avant','Dérailleur Arrière','Roue avant','Roue arrière','Réflecteurs','Pédalier','Ordinateur','Panier'),
    prix_P int,
    primary key(numero_prod_P)
);

create table Fournisseur (
	siret_F varchar(14) not null,
    nom_F varchar(45),
    contact_F varchar(45),
    adresse_F varchar(100),
    libelle_F int,
    primary key(siret_F)
);

create table Entreprise (
	email_E varchar(45) not null,
    nom_E varchar(45),
    telephone_E varchar(10),
    nom_contact_E varchar(45),
    prenom_contact_E varchar(45),
    rue_E varchar(45),
    ville_E varchar(45),
    code_postal_E varchar(5),
    province_E varchar(45),
    remise_E int 
		check(remise_E >= 0 and remise_E <= 100),
    primary key(email_E)
);

create table Particulier (
	email_P varchar(45) not null,
    nom_P varchar(45),
    prenom_P varchar(45),
    rue_P varchar(45),
    ville_P varchar(45),
    code_postal_P varchar(5),
    province_P varchar(45),
    telephone_P varchar(10),
    primary key(email_P)
);

create table Commande (
	numero_C varchar(45) not null,
    date_C date,
    date_livraison_C date,
    adresse_livraison_C varchar(45),
    email_E varchar(45),
    email_P varchar(45),
    primary key(numero_C),
    foreign key(email_E) 
		references Entreprise(email_E) 
		on delete no action 
        on update cascade,
    foreign key(email_P) 
		references Particulier(email_P) 
        on delete no action 
        on update cascade
);

create table Fidelio (
	numero_programme int not null,
    description_programme varchar(200),
    cout_programme int,
    duree_programme int,
    rabais_programme int,
    primary key(numero_programme)
);

create table Assembler (
	numero_prod_B int,
    numero_prod_P int,
    primary key(numero_prod_B, numero_prod_P),
    foreign key(numero_prod_B) 
		references Bicyclette(numero_prod_B) 
		on delete cascade 
		on update cascade,
    foreign key(numero_prod_P) 
		references Pièce(numero_prod_P) 
        on delete cascade 
        on update cascade
);

create table Fourni (
	siret_F varchar(14),
    numero_prod_P int,
    numero_prod_F int,
    nom_fournisseur_P varchar(45),
    delai_F int,
    prix_F int,
    primary key(siret_F, numero_prod_P),
    foreign key(siret_F) 
		references Fournisseur(siret_F) 
        on delete cascade 
        on update cascade, 
    foreign key(numero_prod_P) 
		references Pièce(numero_prod_P) 
        on delete cascade 
        on update cascade
);

create table Contient_B (
	numero_prod_B int,
    numero_C varchar(45),
	quantite_commande_B int,
    primary key(numero_prod_B, numero_C),
    foreign key(numero_prod_B) 
		references Bicyclette(numero_prod_B) 
        on delete no action 
        on update cascade, 
    foreign key(numero_C) 
		references Commande(numero_C) 
        on delete no action 
        on update cascade
);

create table Contient_P (
	numero_prod_P int,
    numero_C varchar(45),
	quantite_commande_P int,
    primary key(numero_prod_P, numero_C),
    foreign key(numero_prod_P) 
		references Pièce(numero_prod_P) 
        on delete no action 
        on update cascade, 
    foreign key(numero_C) 
		references Commande(numero_C) 
        on delete no action 
        on update cascade
);

create table Adhere (
	numero_programme int,
    email_P varchar(45),
    date_adhesion date,
    primary key(numero_programme, email_P),
    foreign key(numero_programme) 
		references Fidelio(numero_programme) 
        on delete no action 
        on update no action,
    foreign key(email_P) 
		references Particulier(email_P) 
        on delete no action 
        on update no action 
);
drop user if exists 'test'@'localhost';
create user 'test'@'localhost' identified by 'password';
grant all PRIVILEGES ON `VeloMax` . * TO 'test'@'localhost';