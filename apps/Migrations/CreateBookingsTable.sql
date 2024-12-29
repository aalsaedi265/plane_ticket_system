
CREATE TABLE Bookings
(
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    FlightId INT NOT NULL,
    BookingReference VARCHAR(10) NOT NULL UNIQUE,
    BookingStatus VARCHAR(20) NOT NULL CHECK (BookingStatus IN ('Pending', 'Confirmed', 'Cancelled')),
    TotalAmount DECIMAL(10,2) NOT NULL,
    PaymentStatus VARCHAR(20) NOT NULL CHECK (PaymentStatus IN ('Pending', 'Completed', 'Refunded')),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (FlightId) REFERENCES Flights(FlightId)
)
GO