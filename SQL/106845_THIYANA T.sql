CREATE TABLE CUSTOMER 
( CustomerId int IDENTITY(1,1) PRIMARY KEY, CustomerNumber int NOT NULL UNIQUE, LastName varchar(50) NOT NULL, 
FirstName varchar(50) NOT NULL,AreaCode int NULL, Address varchar(50) NULL, Phone varchar(50) NULL)
insert into CUSTOMER(CustomerNumber,LastName,FirstName,AreaCode,Address,Phone)Values(123,'Smith','joe',33,'US',7896542)
insert into CUSTOMER(CustomerNumber,LastName,FirstName,AreaCode,Address,Phone)Values(345,'rya','thiya',44,'ST',12092022)
update CUSTOMER set Phone =1234567 where CustomerNumber=345
delete from CUSTOMER where CustomerNumber=123
update CUSTOMER set AreaCode=46 where CustomerId=2
select * from CUSTOMER order by LastName
select * from CUSTOMER order by Address, LastName
select distinct FirstName from CUSTOMER
select * from CUSTOMER where LastName like 'J%'
select * from CUSTOMER where LastName like '%a%'
select * from CUSTOMER where LastName not like '%a%'
SELECT * FROM CUSTOMER WHERE LastName LIKE 'J_cks_n'
SELECT * FROM CUSTOMER WHERE CustomerNumber LIKE '[10]%'
select * from CUSTOMER where LastName='Smith' and FirstName='John'
select * from CUSTOMER where LastName='Smith' or FirstName='John'
select * from CUSTOMER 
where LastName='Smith' and (FirstName='John' or FirstName='Smith')
select TOP 1 * from CUSTOMER
select TOP 60 percent * from CUSTOMER
declare @mylastname varchar(50)
select @mylastname=LastName from CUSTOMER where CustomerId=2
print @mylastname
declare @find varchar(30)
set @find = 'J%'
select * from CUSTOMER
where LastName LIKE @find
declare @customerNumber int
select @customerNumber=CustomerNumber from CUSTOMER 
where CustomerId=2
if @customerNumber > 1000
print 'The Customer Number is larger than 1000'
else
print 'The Customer Number is not larger than 1000'
select @customerNumber=CustomerNumber from CUSTOMER where CustomerId=2
if @customerNumber > 1000
begin
print 'The Customer Number is larger than 1000'
update CUSTOMER set AreaCode=46 where CustomerId=2
end
else
print 'The Customer Number is not larger than 1000'
while (select AreaCode from CUSTOMER where CustomerId=1) < 20
begin
update CUSTOMER set AreaCode = AreaCode + 1
end
select * from CUSTOMER



DECLARE
@CustomerId int, 
@phone varchar(50) 
DECLARE db_cursor CURSOR 
FOR SELECT CustomerId from CUSTOMER 
OPEN db_cursor 
FETCH NEXT FROM db_cursor INTO @CustomerId 
WHILE @@FETCH_STATUS = 0 
BEGIN 

select @phone=Phone from CUSTOMER where CustomerId=@CustomerId

if LEN(@phone) < 8
update CUSTOMER set Phone='Phone number is not valid' where 
CustomerId=@CustomerId
FETCH NEXT FROM db_cursor INTO @CustomerId 
END 
CLOSE db_cursor 
DEALLOCATE db_cursor
select COUNT(*) as NumbersofCustomers from CUSTOMER
select FirstName, MAX(AreaCode) from CUSTOMER
group by FirstName
Select FirstName, MAX(AreaCode) from CUSTOMER
if EXISTS (SELECT name 
FROM sysobjects 
WHERE name = 'CheckPhoneNumber' 
AND type = 'TR')
DROP TRIGGER CheckPhoneNumber
GO
CREATE TRIGGER CheckPhoneNumber ON CUSTOMER
FOR UPDATE, INSERT
AS
DECLARE
@CustomerId int,
@Phone varchar(50),
@Message varchar(50)
set nocount on
select @CustomerId = CustomerId from INSERTED
select @Phone = Phone from INSERTED



set @Message = 'Phone Number ' + @Phone + ' is not valid'
if len(@Phone) < 8 --Check if Phone Number have less than 8 digits 
update CUSTOMER set Phone = @Message where CustomerId = @CustomerId
set nocount off
GO



INSERT INTO CUSTOMER
(CustomerNumber, LastName, FirstName, AreaCode, Address, Phone) 
VALUES
('1003', 'Obama', 'Barak', 51, 'Nevada', '4444')



update CUSTOMER set Phone = '44444444' where CustomerNumber = '1003'









if not exists (select * from dbo.sysobjects where id = object_id(N'[CUSTOMER]') and 
OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE CUSTOMER
(
CustomerId int PRIMARY KEY,
CustomerNumber int NOT NULL UNIQUE,
LastName varchar(50) NOT NULL,
FirstName varchar(50) NOT NULL,
AreaCode int NULL,
Address varchar(50) NULL,
Phone varchar(50) NULL,
)
GO
if exists(select * from dbo.syscolumns where id = object_id(N'[CUSTOMER]') and OBJECTPROPERTY(id, 
N'IsUserTable') = 1 and name = 'CustomerId')
ALTER TABLE CUSTOMER ALTER COLUMN CustomerId int 
Else
ALTER TABLE CUSTOMER ADD CustomerId int 
GO
if exists(select * from dbo.syscolumns where id = object_id(N'[CUSTOMER]') and OBJECTPROPERTY(id, 
N'IsUserTable') = 1 and name = 'CustomerNumber')
ALTER TABLE CUSTOMER ALTER COLUMN CustomerNumber int 
Else
ALTER TABLE CUSTOMER ADD CustomerNumber int 
GO

---STUDENT TABLE

CREATE TABLE STUDENT (
    Studentld INT IDENTITY(1,1) NOT NULL,
    Classid INT NOT NULL,
    StudentName VARCHAR(255) NOT NULL,
    StudentNumber VARCHAR(255) NOT NULL,
    TotalGrade DECIMAL(10,2) NOT NULL,
    Address VARCHAR(255),
    Phone VARCHAR(255),
    EMail VARCHAR(255)
);





CREATE TABLE GRADE (
    Gradeld INT IDENTITY(1,1) NOT NULL,
    Studentld INT NOT NULL,
    Courseld INT NOT NULL,
    Grade DECIMAL(10,2) NOT NULL,
    Comment VARCHAR(255)
);





CREATE TABLE COURSE (
    Courseld INT IDENTITY(1,1) NOT NULL,
  CourseName VARCHAR(255) NOT NULL,
    Schoolld INT NOT NULL,
    Description VARCHAR(255)
);





CREATE TABLE SCHOOL (
    Schoolld INT IDENTITY(1,1) NOT NULL,
    SchoolName VARCHAR(255) NOT NULL,
  Description VARCHAR(255),
    Address VARCHAR(255),
    Phone VARCHAR(255),
    PostCode VARCHAR(255),
    PostAddress VARCHAR(255)
);





CREATE TABLE CLASS (
    Classid INT IDENTITY(1,1) NOT NULL,
  SchoolId INT NOT NULL,
  ClassName VARCHAR (255) NOT NULL,
    Description VARCHAR (255) NOT NULL,



);
CREATE TABLE TEACHER (
    Teacherld INT IDENTITY(1,1) NOT NULL,
    Schoolld INT NOT NULL,
    TeacherName VARCHAR(255) NOT NULL,
    Description VARCHAR(255)
);



CREATE TABLE TEACHER_COURSE (
    Teacherld INT NOT NULL,
    Courseld INT NOT NULL
);



insert into STUDENT(Classid ,StudentName,StudentNumber ,TotalGrade ,Address,Phone ,EMail)
values (4588,'Den',67890,7.09,'78 ghj st thai',765432,'hyj@ef.com')





insert into GRADE( Studentld,Courseld,Grade,Comment)
values (4,7,7.7,'good')



declare @SchoolId int
-- Insert Data into SCHOOL table
insert into SCHOOL(SchoolName) values ('MIT')
select @SchoolId = @@IDENTITY
-- Insert Courses for the specific School above in the COURSE table
Select * from GRADE







