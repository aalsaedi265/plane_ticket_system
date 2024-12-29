

-- creating these indexes, the
-- database can more efficiently query data based on these columns, such
-- as:

-- Retrieving all flights departing at a specific time
-- Finding all bookings made by a specific user
-- Retrieving all bookings associated
-- with a specific flight
-- Finding all passengers associated
-- with a specific booking

CREATE INDEX IDX_Flights_DepartureTime ON Flights(DepartureTime)
CREATE INDEX IDX_Bookings_UserId ON Bookings(UserId)
CREATE INDEX IDX_Bookings_FlightId ON Bookings(FlightId)
CREATE INDEX IDX_Passengers_BookingId ON Passengers(BookingId)
GO