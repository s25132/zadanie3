CREATE TABLE Animal (
    IdAnimal INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200),
    Description NVARCHAR(200) NOT NULL,
    Category NVARCHAR(200),
    Area NVARCHAR(200)
);


INSERT INTO Animal (Name, Description, Category, Area) VALUES ('Lion', 'Large carnivorous feline with a golden coat.', 'Mammal', 'Africa');
INSERT INTO Animal (Name, Description, Category, Area) VALUES ('Elephant', 'Giant herbivorous mammal with a trunk and tusks.', 'Mammal', 'Africa');
INSERT INTO Animal (Name, Description, Category, Area) VALUES ('Tiger', 'Large carnivorous feline with distinctive stripes.', 'Mammal', 'Asia');
INSERT INTO Animal (Name, Description, Category, Area) VALUES ('Giraffe', 'Tall, long-necked herbivorous mammal with spotted coat.', 'Mammal', 'Africa');
INSERT INTO Animal (Name, Description, Category, Area) VALUES ('Penguin', 'Flightless aquatic bird with black and white plumage.', 'Bird', 'Antarctica');
