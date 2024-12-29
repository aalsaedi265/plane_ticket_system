
CREATE TRIGGER UpdatedFlightTimestamp On Flights
AFTER UPDATE
AS
BEGIN
    UPDATE Flights
    SET UpdatedAt = GETDATE()
    FROM Flights f
    INNER JOIN inserted i ON f.FlightId = i.FlightId
END
GO

CREATE TRIGGER UpdateBookingTimestamp
ON Bookings
AFTER UPDATE
AS
BEGIN
    UPDATE Bookings
    SET UpdatedAt = GETDATE()
    FROM Bookings b
        INNER JOIN inserted i ON b.BookingId = i.BookingId
END
GO

CREATE TRIGGER UpdatePassengerTimestamp
ON Passengers
AFTER UPDATE
AS
BEGIN
    UPDATE Passengers
    SET UpdatedAt = GETDATE()
    FROM Passengers p
        INNER JOIN inserted i ON p.PassengerId = i.PassengerId
END