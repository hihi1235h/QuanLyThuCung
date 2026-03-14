USE QuanLyThuCung;
IF OBJECT_ID('sp_GetPets', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetPets;
GO

CREATE PROCEDURE sp_GetPets
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id,
        p.PetName,
        p.Species,
        p.Breed,
        p.Age,
        c.CustomerName
    FROM Pets p
    INNER JOIN Customers c ON p.CustomerId = c.Id
END;
GO

IF OBJECT_ID('sp_AddPet', 'P') IS NOT NULL
    DROP PROCEDURE sp_AddPet;
GO

CREATE PROCEDURE sp_AddPet
    @PetName NVARCHAR(100),
    @Species NVARCHAR(50),
    @Breed NVARCHAR(100),
    @Age INT,
    @CustomerId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Pets (PetName, Species, Breed, Age, CustomerId)
    VALUES (@PetName, @Species, @Breed, @Age, @CustomerId);
END;
GO

IF OBJECT_ID('sp_UpdatePet', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdatePet;
GO

CREATE PROCEDURE sp_UpdatePet
    @PetId INT,
    @PetName NVARCHAR(100),
    @Species NVARCHAR(50),
    @Breed NVARCHAR(100),
    @Age INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Pets
    SET PetName = @PetName,
        Species = @Species,
        Breed = @Breed,
        Age = @Age
    WHERE Id = @PetId;
END;
GO

IF OBJECT_ID('sp_DeletePet', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeletePet;
GO

CREATE PROCEDURE sp_DeletePet
    @PetId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Pets
    WHERE Id = @PetId;
END;
GO

CREATE PROCEDURE sp_GetCustomers
AS
BEGIN
    SELECT * FROM Customers
END
GO

CREATE PROCEDURE sp_GetServices
AS
BEGIN
    SELECT * FROM Services
END
GO

CREATE PROCEDURE sp_CreateAppointment
    @PetId INT,
    @ServiceId INT,
    @AppointmentDate DATETIME
AS
BEGIN
    INSERT INTO Appointments (PetId, ServiceId, AppointmentDate)
    VALUES (@PetId, @ServiceId, @AppointmentDate)
END
GO

CREATE PROCEDURE sp_GetDashboardStats
AS
BEGIN
    SELECT 
        (SELECT COUNT(*) FROM Pets) AS TotalPets,
        (SELECT COUNT(*) FROM Customers) AS TotalCustomers,
        (SELECT COUNT(*) FROM Services) AS TotalServices,
        (SELECT COUNT(*) FROM Sales) AS TotalSales
END
GO

ALTER DATABASE QuanLyThuCung COLLATE Vietnamese_CI_AS;
