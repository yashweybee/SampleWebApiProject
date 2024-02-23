
--Create Books table
CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    PublicationDate DATE,
    CategoryId INT,
    AuthorId INT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId),
    FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId)
);


-- Insert data into Books table
INSERT INTO Books (Title, Description, Price, PublicationDate, CategoryId, AuthorId) VALUES
('The Great Gatsby', 'A classic novel about the American Dream', 19.99, '1925-04-10', 6, 1),
('To Kill a Mockingbird', 'A novel exploring racial injustice in the American South', 24.99, '1960-07-11', 7, 2),
('Dune', 'A science fiction epic set in a distant future', 29.99, '1965-08-01', 8, 3),
('Gone Girl', 'A psychological thriller about a missing woman', 14.99, '2012-06-05', 9, 4),
('Pride and Prejudice', 'A classic romance novel by Jane Austen', 17.99, '1813-01-28', 10, 5);