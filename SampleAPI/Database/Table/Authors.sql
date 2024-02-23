-- Create Authors Table
CREATE TABLE Authors (
    AuthorId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL
);

-- Insert data into Authors table
INSERT INTO Authors (FirstName, LastName) VALUES
('John', 'Doe'),
('Jane', 'Smith'),
('Michael', 'Johnson'),
('Emily', 'Williams'),
('Robert', 'Davis');