USE QuanLyThuCung
GO

PRINT '===================================='
PRINT 'TẠO DỮ LIỆU MẪU HỆ THỐNG THÚ CƯNG'
PRINT '===================================='

DECLARE @Password NVARCHAR(255) = '123456'

DECLARE @SoLuongUsers INT = 15
DECLARE @Counter INT = 1

DECLARE @Username NVARCHAR(50)
DECLARE @FullName NVARCHAR(100)
DECLARE @Email NVARCHAR(100)

-- =============================================
-- TẠO BẢNG TẠM TÊN NGƯỜI
-- =============================================

CREATE TABLE #TempNames
(
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50)
)

INSERT INTO #TempNames VALUES
(N'Nguyễn Văn',N'An'),
(N'Trần Thị',N'Bình'),
(N'Lê Văn',N'Cường'),
(N'Phạm Thị',N'Dung'),
(N'Hoàng Văn',N'Đức'),
(N'Ngô Thị',N'Hương'),
(N'Vũ Văn',N'Hùng'),
(N'Đỗ Thị',N'Lan'),
(N'Bùi Văn',N'Minh'),
(N'Lý Thị',N'Nga'),
(N'Đinh Văn',N'Phong'),
(N'Mai Thị',N'Quỳnh'),
(N'Tạ Văn',N'Sơn'),
(N'Võ Thị',N'Trang'),
(N'Phan Văn',N'Tuấn')

-- =============================================
-- TẠO USERS
-- =============================================

WHILE @Counter <= @SoLuongUsers
BEGIN

SELECT TOP 1
    @FullName = FirstName + ' ' + LastName
FROM #TempNames
ORDER BY NEWID()

SET @Username = 'user' + CAST(@Counter AS VARCHAR)
SET @Email = @Username + '@example.com'

INSERT INTO Users
(
Username,
PasswordHash,
FullName,
Email,
CreatedDate,
IsActive
)
VALUES
(
@Username,
@Password,
@FullName,
@Email,
GETDATE(),
1
)

PRINT 'Đã tạo user: ' + @Username

SET @Counter = @Counter + 1

END

-- =============================================
-- TẠO ADMIN
-- =============================================

IF NOT EXISTS (SELECT 1 FROM Users WHERE Username='admin')
BEGIN

INSERT INTO Users
(
Username,
PasswordHash,
FullName,
Email,
CreatedDate,
IsActive
)
VALUES
(
'admin',
@Password,
N'Quản trị viên',
'admin@example.com',
GETDATE(),
1
)

PRINT 'Đã tạo admin'

END

-- =============================================
-- TẠO BẢNG CUSTOMERS
-- =============================================

IF OBJECT_ID('Customers') IS NULL
BEGIN

CREATE TABLE Customers
(
Id INT IDENTITY PRIMARY KEY,
CustomerName NVARCHAR(100),
Phone NVARCHAR(20),
Address NVARCHAR(200)
)

END

-- =============================================
-- TẠO BẢNG PETS
-- =============================================

IF OBJECT_ID('Pets') IS NULL
BEGIN

CREATE TABLE Pets
(
Id INT IDENTITY PRIMARY KEY,
PetName NVARCHAR(100),
Species NVARCHAR(50),
Breed NVARCHAR(100),
Age INT,
CustomerId INT
)

END

-- =============================================
-- TẠO BẢNG SERVICES
-- =============================================

IF OBJECT_ID('Services') IS NULL
BEGIN

CREATE TABLE Services
(
Id INT IDENTITY PRIMARY KEY,
ServiceName NVARCHAR(100),
Price DECIMAL(10,2)
)

END

-- =============================================
-- TẠO BẢNG APPOINTMENTS
-- =============================================

IF OBJECT_ID('Appointments') IS NULL
BEGIN

CREATE TABLE Appointments
(
Id INT IDENTITY PRIMARY KEY,
PetId INT,
ServiceId INT,
AppointmentDate DATETIME
)

END

-- =============================================
-- TẠO CUSTOMERS
-- =============================================

INSERT INTO Customers(CustomerName,Phone,Address) VALUES
(N'Nguyễn Văn Nam','0901234567',N'Hà Nội'),
(N'Trần Thị Mai','0902345678',N'Hồ Chí Minh'),
(N'Lê Văn Hùng','0903456789',N'Đà Nẵng'),
(N'Phạm Thị Lan','0904567890',N'Cần Thơ'),
(N'Hoàng Văn Đức','0905678901',N'Hải Phòng')

PRINT 'Đã tạo Customers'

-- =============================================
-- TẠO PETS
-- =============================================

INSERT INTO Pets(PetName,Species,Breed,Age,CustomerId) VALUES
(N'Milu','Dog','Poodle',3,1),
(N'Mimi','Cat','Anh lông ngắn',2,2),
(N'Lucky','Dog','Golden',4,3),
(N'Kitty','Cat','Ba Tư',1,4),
(N'Bông','Dog','Chihuahua',2,5)

PRINT 'Đã tạo Pets'

-- =============================================
-- TẠO SERVICES
-- =============================================

INSERT INTO Services(ServiceName,Price) VALUES
(N'Khám sức khỏe',100000),
(N'Tiêm phòng',150000),
(N'Tắm rửa',80000),
(N'Cắt tỉa lông',120000)

PRINT 'Đã tạo Services'

-- =============================================
-- TẠO APPOINTMENTS
-- =============================================

INSERT INTO Appointments(PetId,ServiceId,AppointmentDate) VALUES
(1,1,GETDATE()),
(2,2,DATEADD(day,1,GETDATE())),
(3,3,DATEADD(day,2,GETDATE())),
(4,1,DATEADD(day,3,GETDATE())),
(5,4,DATEADD(day,4,GETDATE()))

PRINT 'Đã tạo Appointments'

DROP TABLE #TempNames

PRINT '===================================='
PRINT 'TẠO DỮ LIỆU HOÀN TẤT'
PRINT '===================================='

SELECT * FROM Users
SELECT * FROM Customers
SELECT * FROM Pets
SELECT * FROM Services
SELECT * FROM Appointments

PRINT '===================================='
PRINT 'THÔNG TIN ĐĂNG NHẬP'
PRINT 'admin / 123456'
PRINT 'user1 / 123456'
PRINT '===================================='
GO