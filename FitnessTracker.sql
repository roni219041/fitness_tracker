IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'FitnessTracker')
  BEGIN
    CREATE DATABASE FitnessTracker

CREATE TABLE Users(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	FirstName nvarchar(150) NOT NULL,
	LastName nvarchar(150) NOT NULL,
	Age int NOT NULL,
	[Weight] int NOT NULL,
	Height int NOT NULL,
)

CREATE TABLE Foods(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	[Name] nvarchar(150) NOT NULL,
	Calories int NOT NULL,
	Fat int NOT NULL,
	Protein int NOT NULL,
	Carbohydrates int NOT NULL,
	UserId int Foreign key references Users(Id)
)

CREATE TABLE Categories(
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(150) NOT NULL
)

CREATE TABLE BodyPart(
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(100) NOT NULL
)

CREATE TABLE Excercises(
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(150) NOT NULL,
	UserId int FOREIGN KEY REFERENCES Users(Id),
	BodypartId int FOREIGN KEY REFERENCES BodyPart(Id),
	CategoryId int FOREIGN KEY REFERENCES Categories(Id)
)

--ADD CATEGORIES AND BODY PARTS
INSERT INTO BodyPart ([Name]) VALUES
('Core'),
('Arms'),
('Back'),
('Chest'),
('Legs'),
('Shoulders'),
('Other'),
('Full Body')

INSERT INTO Categories ([Name]) VALUES
('Cardio'),
('Dumbbell'),
('Bodyweight'),
('Barbell'),
('Machine/Other')

END