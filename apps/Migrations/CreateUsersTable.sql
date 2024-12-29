
CREATE TABLE users (
    UserId INT PRIMARY KEY IDENTITY(1, 1),
    email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(20),
    UserType VARCHAR(20) NOT NULL CHECK (UserType  IN ('Admin','Customer')),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    UpdatedAt DATETIME2 DEFAULT GETDATE()
)

GO