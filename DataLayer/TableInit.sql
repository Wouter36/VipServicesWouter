create table Limosine(

EersteUurPrijs int NOT NULL,
NightLifePrijs int NOT NULL,
WeddingPrijs int NOT NULL,
WellnessPrijs int NOT NULL,
Naam varchar(255) NOT NULL,
LimosineID int NOT NULL PRIMARY KEY
);

create table Klant(

Naam varchar(255) NOT NULL,
KlantID int NOT NULL PRIMARY KEY
);

create table Reservatie(

Naam varchar(255) NOT NULL,
ReservatieID int NOT NULL PRIMARY KEY,
KlantID int NOT NULL FOREIGN KEY REFERENCES Klant(KlantID)
);