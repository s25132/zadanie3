CREATE TABLE Animal (
    IdAnimal INT PRIMARY KEY,
    Name NVARCHAR(200),
    Description NVARCHAR(200) NOT NULL,
    Category NVARCHAR(200),
    Area NVARCHAR(200)
);


INSERT INTO Animal (IdAnimal, Name, Description, Category, Area) VALUES (1, 'Lion', 'Large carnivorous feline with a golden coat.', 'Mammal', 'Africa');
INSERT INTO Animal (IdAnimal, Name, Description, Category, Area) VALUES (2, 'Elephant', 'Giant herbivorous mammal with a trunk and tusks.', 'Mammal', 'Africa');
INSERT INTO Animal (IdAnimal, Name, Description, Category, Area) VALUES (3, 'Tiger', 'Large carnivorous feline with distinctive stripes.', 'Mammal', 'Asia');
INSERT INTO Animal (IdAnimal, Name, Description, Category, Area) VALUES (4, 'Giraffe', 'Tall, long-necked herbivorous mammal with spotted coat.', 'Mammal', 'Africa');
INSERT INTO Animal (IdAnimal, Name, Description, Category, Area) VALUES (5, 'Penguin', 'Flightless aquatic bird with black and white plumage.', 'Bird', 'Antarctica');
