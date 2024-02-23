-- Create Categories Table
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255) NOT NULL
);


-- Insert data into Categories table
INSERT INTO Categories (Name) VALUES
('Fiction'),
('Non-Fiction'),
('Science Fiction'),
('Mystery'),
('Romance');