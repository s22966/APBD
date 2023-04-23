IF OBJECT_ID('Animals', 'U') IS NOT NULL
    DROP TABLE Animals

CREATE TABLE Animals (
   ID INT PRIMARY KEY,
   Name NVARCHAR(200),
   Description NVARCHAR(200) NULL,
   Category VARCHAR(200),
   Area VARCHAR(200)
);

INSERT INTO Animals (ID, Name, Description, Category, Area)
VALUES
    (1, 'Lion', 'The king of the jungle', 'Mammal', 'Africa'),
    (2, 'Tiger', NULL, 'Mammal', 'Asia'),
    (3, 'Giraffe', 'The tallest living land animal', 'Mammal', 'Africa'),
    (4, 'Penguin', 'Flightless bird that live in the Southern Hemisphere', 'Bird', 'Antarctica'),
    (5, 'Kangaroo', 'Marsupials that are found only in Australia', 'Mammal', 'Australia'),
    (6, 'Grizzly Bear', NULL, 'Mammal', 'North America'),
    (7, 'Koala', 'Marsupials that are native to Australia', 'Mammal', 'Australia'),
    (8, 'Emu', 'The second-largest living bird by height', 'Bird', 'Australia'),
    (9, 'Llama', 'South American camelids used as pack animals', 'Mammal', 'South America');