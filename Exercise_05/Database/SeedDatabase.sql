CREATE SCHEMA trip;
GO

IF OBJECT_ID('trip.Country_Trip', 'U') IS NOT NULL
    ALTER TABLE trip.Country_Trip DROP CONSTRAINT Country_Trip_Country;

IF OBJECT_ID('trip.Country_Trip', 'U') IS NOT NULL
    ALTER TABLE trip.Country_Trip DROP CONSTRAINT Country_Trip_Trip;

IF OBJECT_ID('trip.Country_Trip', 'U') IS NOT NULL
    ALTER TABLE trip.Client_Trip DROP CONSTRAINT Table_5_Client;

IF OBJECT_ID('trip.Country_Trip', 'U') IS NOT NULL
    ALTER TABLE trip.Client_Trip DROP CONSTRAINT Table_5_Trip;

IF OBJECT_ID('trip.Client', 'U') IS NOT NULL
    DROP TABLE trip.Client;

IF OBJECT_ID('trip.Country_Trip', 'U') IS NOT NULL
    DROP TABLE trip.Client_Trip;

IF OBJECT_ID('trip.Country', 'U') IS NOT NULL
    DROP TABLE trip.Country;

IF OBJECT_ID('trip.Country_Trip', 'U') IS NOT NULL
    DROP TABLE trip.Country_Trip;

IF OBJECT_ID('trip.Trip', 'U') IS NOT NULL
    DROP TABLE trip.Trip;

CREATE TABLE trip.Client (
    IdClient int  NOT NULL,
    FirstName nvarchar(120)  NOT NULL,
    LastName nvarchar(120)  NOT NULL,
    Email nvarchar(120)  NOT NULL,
    Telephone nvarchar(120)  NOT NULL,
    Pesel nvarchar(120)  NOT NULL,
    CONSTRAINT Client_pk PRIMARY KEY  (IdClient)
);

CREATE TABLE trip.Client_Trip (
    IdClient int  NOT NULL,
    IdTrip int  NOT NULL,
    RegisteredAt datetime  NOT NULL,
    PaymentDate datetime  NULL,
    CONSTRAINT Client_Trip_pk PRIMARY KEY  (IdClient,IdTrip)
);

CREATE TABLE trip.Country (
    IdCountry int  NOT NULL,
    Name nvarchar(120)  NOT NULL,
    CONSTRAINT Country_pk PRIMARY KEY  (IdCountry)
);

CREATE TABLE trip.Country_Trip (
    IdCountry int  NOT NULL,
    IdTrip int  NOT NULL,
    CONSTRAINT Country_Trip_pk PRIMARY KEY  (IdCountry,IdTrip)
);

CREATE TABLE trip.Trip (
    IdTrip int  NOT NULL,
    Name nvarchar(120)  NOT NULL,
    Description nvarchar(220)  NOT NULL,
    DateFrom datetime  NOT NULL,
    DateTo datetime  NOT NULL,
    MaxPeople int  NOT NULL,
    CONSTRAINT Trip_pk PRIMARY KEY  (IdTrip)
);

ALTER TABLE trip.Country_Trip ADD CONSTRAINT Country_Trip_Country
    FOREIGN KEY (IdCountry)
    REFERENCES trip.Country (IdCountry);

ALTER TABLE trip.Country_Trip ADD CONSTRAINT Country_Trip_Trip
    FOREIGN KEY (IdTrip)
    REFERENCES trip.Trip (IdTrip);

ALTER TABLE trip.Client_Trip ADD CONSTRAINT Table_5_Client
    FOREIGN KEY (IdClient)
    REFERENCES trip.Client (IdClient);

ALTER TABLE trip.Client_Trip ADD CONSTRAINT Table_5_Trip
    FOREIGN KEY (IdTrip)
    REFERENCES trip.Trip (IdTrip);

INSERT INTO trip.Client (IdClient,FirstName,LastName,Email,Telephone,Pesel)
VALUES
  (1,'John','Smith','dolor.tempus.non@protonmail.couk','(0766) 52574466',32080718531),
  (2,'Jake','Doe','et.pede.nunc@yahoo.edu','(01334) 4841396',52121471467),
  (3,'Isadora','Clarke','eget.tincidunt.dui@aol.ca','(034568) 645965',92110685522),
  (4,'Hilel','Meyers','tempus.scelerisque@hotmail.com','(0654) 92477496',50110114541),
  (5,'Orla','West','nunc.quisque@hotmail.couk','(0663) 16138381',48050201844),
  (6,'Chandler','Chavez','magna.praesent@yahoo.couk','(04851) 2449635',78080785107),
  (7,'Conan','Christensen','consequat.dolor.vitae@google.couk','(034824) 376192',87010737651),
  (8,'Jane','Landry','molestie.orci.tincidunt@aol.org','(06631) 1921542',88112655578),
  (9,'Gloria','Potts','donec.dignissim@protonmail.org','(037994) 352565',23050354026),
  (10,'Colorado','Norman','cursus@protonmail.edu','(0543) 62363536',66080382706);


INSERT INTO trip.Country (IdCountry,Name)
VALUES
  (1,'Spain'),
  (2,'Poland'),
  (3,'Germany'),
  (4,'France'),
  (5,'Austria'),
  (6,'Singapore'),
  (7,'Czech republic'),
  (8,'Singapore'),
  (9,'Italy'),
  (10,'Russian Federation');
  
INSERT INTO trip.Trip (IdTrip,Name,Description,DateFrom,DateTo,MaxPeople)
VALUES 
  (1, 'ABC', 'Lorem ipsum...', '2023-04-01', '2023-04-10', 2),
  (2, 'DEF', 'Lorem...', '2023-03-01', '2023-02-10', 4);
  
INSERT INTO trip.Country_Trip (IdCountry, IdTrip)
VALUES
  (2, 1),
  (3, 1),
  (1, 2),
  (4, 2),
  (7, 2);
  
INSERT INTO trip.Client_Trip (IdClient,IdTrip,RegisteredAt,PaymentDate)
VALUES
  (1, 1, '2023-03-22', '2023-03-24'),
  (2, 1, '2023-03-24', '2023-02-26'),
  (3, 2, '2023-03-24', '2023-02-26'),
  (4, 2, '2023-03-24', '2023-02-26'),
  (5, 2, '2023-03-24', '2023-02-26');