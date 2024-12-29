
CREATE TABLE Flights
(
    FlightId INT IDENTITY(1,1) PRIMARY KEY,
    FlightNumber VARCHAR(20) NOT NULL UNIQUE,
    DepartureCity VARCHAR(100) NOT NULL,
    ArrivalCity VARCHAR(100) NOT NULL,
    DepartureTime DATETIME2 NOT NULL,
    ArrivalTime DATETIME2 NOT NULL,
    TotalSeats INT NOT NULL,
    AvailableSeats INT NOT NULL,
    BasePrice DECIMAL(10,2) NOT NULL,
    Status VARCHAR(20) DEFAULT 'Scheduled' CHECK (Status  IN ('Scheduled', 'Delayed', 'Cancelled', 'Completed')),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE()


)

GO