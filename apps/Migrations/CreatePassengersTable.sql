
CREATE TABLE Passengers (
    PassengerId INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DocumentType VARCHAR(20) NOT NULL,
    DocumentNumber VARCHAR(50) NOT NULL,
    SeatNumber VARCHAR(10),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
)

GO