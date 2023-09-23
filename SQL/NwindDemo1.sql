use Northwind;
Select *from Employees;
Select EmployeeID, FirstName,LastName,HireDate,City From Employees
Select EmployeeID, FirstName,LastName,HireDate,City From Employees Where City='London';
Select EmployeeID, FirstName,LastName,HireDate,City From Employees Where City<>'London';
Select EmployeeID, FirstName,LastName,HireDate,City From Employees Where HireDate>='1-july-1993';
Select CategoryName, Description From Categories;
Select ContactName, CompanyName, ContactTitle, Phone From Customers;
Select EmployeeID,Title,FirstName,LastName,Region From Employees;
Select RegionID,RegionDescription From Region;
Select CompanyName, Fax, Phone,HomePage From Suppliers;
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees WHERE (HireDate>='1-june-1992') AND (HireDate>='15-december-1993')
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees WHERE HireDate BETWEEN '1-june-1992' AND '15-december-1993'
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees WHERE HireDate NOT BETWEEN'1-june-1992' AND'15-december-1993'
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees WHERE City ='London' OR City='Seattle'
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees WHERE City IN('Seattle','Tacoma','Redmond')
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees WHERE City NOT IN('Seattle','Tacoma','Redmond')
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees WHERE (FirstName NOT LIKE 'M%' ) AND (FirstName NOT LIKE 'A%')
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees WHERE FirstName LIKE '[a-M]%'
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees WHERE FirstName LIKE '[^a-M]%'
Select EmployeeID,FirstName,LastName,HireDate,City FROM Employees ORDER BY City
Select EmployeeID,FirstName,LastName,HireDate,Country,City FROM Employees ORDER BY Country, City DESC
Select EmployeeID,FirstName,LastName,HireDate,Country,City FROM Employees ORDER BY Country DESC, City DESC
Select EmployeeID,FirstName,LastName,HireDate,Country,City FROM Employees ORDER BY Country ASC, City DESC
Select Title,FirstName,LastName FROM Employees ORDER BY 1,3;
Select Title,FirstName,LastName FROM Employees ORDER BY Title, LastName
Select CategoryName, Description From Categories ORDER BY CategoryName
Select ContactName, CompanyName, ContactTitle, Phone From Customers ORDER BY Phone
Select FirstName,LastName,HireDate FROM Employees ORDER BY HireDate DESC
Select OrderID,OrderDate, ShippedDate,CustomerID,Freight FROM Orders ORDER BY Freight DESC
Select CompanyName, Fax, Phone, HomePage, Country FROM Suppliers ORDER BY CompanyName
Select Title,FirstName,LastName FROM Employees ORDER BY Title ASC , LastName DESC
Select FirstName,LastName,Region FROM Employees WHERE Region IS NULL
Select FirstName,LastName,Region FROM Employees WHERE Region IS NOT NULL
Select CompanyName, ContactName FROM Customers WHERE City = 'Buenos Aries'
Select ProductName, UNitPrice, QuantityPErUNit FROM Products WHERE UnitsInStock=0;
Select OrderDate,ShippedDate,CustomerID,Freight FROM ORDERS WHERE OrderDATE='19-may-1997'
Select FIrstName,LastNAme, COUNTRY FROM Employees WHERE Country <> 'USA'
SElect OrderDATE, CustomerID,Freight FROM ORDERS Where OrderDate='1997-05-19'
Select FIrstName+''+LastNAme FROM Employees
Select [OrderID],[Freight],[Freight]*0.1Tax FROM Orders where Freight>= 500;
Select OrderID,Freight,Freight*1.1AS FreightTotal FROM Orders where Freight>= 500;
Select COUNT(*) AS NumEmployees from Employees
Select SUM (Quantity) As TotalUNits from [Order Details] where ProductID=3
select AVG(UnitPrice) As AveragePrice from Products
Select city,COUNT(EmployeeID) As Numemployees from Employees group by city
Select city,COUNT(EmployeeID) As numemployees from Employees group by city Having Count (employeeID)>1;
SELECT DISTINct city from Employees order by city
SELECT count (DISTINct city )As NumCities from Employees 
select ProductID , sum(Quantity) as totalunits from [order Details] group by ProductID having Sum(quantity)<200;
select ProductID ,AVg (unitPrice) As AveragePrice From Products group by ProductID having AVg(UnitPrice)>70 order By AveragePrice;
Select Customerid , Count (Orderid) AS NumOrders from Orders Group by CustomerID having Count (OrderId)>15 order by numOrders desc;
Select productID , unitprice from Products where UnitPrice>70 order by UnitPrice
Select Freight, Round (Freight,1) AS ApproxFreight from Orders

--Select unitprice as is and as Char(10)
select unitprice, cast(unitPrice As Char(10)) from products
select unitprice, '$'+cast(unitPrice As Char(10)) from products
select UPPER(FIrstname),UPPER(lastname) from Employees
Select SUBSTRING(Address,1,10) from Customers

select LastName, birthDate ,HireDate, DATEDIFF (year,BirthDate,HireDAte) AS hireAge From Employees order by HireAge
Select FirstName,LASTName,DATENAME(month,BirthDate)AS BirthMonth,Datepart(month,BirthDate) AS num from Employees order by Datepart(month,BirthDate); 

select customerID from Orders Where OrderID=10290;
Select companyName from customers where CustomerID=(select customerID from Orders Where OrderID=10290);
Select companyName from customers where CustomerID in(select customerID from Orders Where OrderDate between '1-jan-1997' and '31-dec-1997');
Select companyName from customers where CustomerID in(select customerID from Orders Where OrderDate between '1997-01-01' and '311997');
select *from Suppliers where CompanyName = 'Grandma Kell''s Homestead';
--Ex
Select productName from products where CategoryID =(Select CategoryID From categories where CategoryName='Seafood'); 
Select CompanyName from suppliers where SupplierID in (select SupplierID from Products where CategoryID=8);
Select CompanyName from suppliers where SupplierID in (select SupplierID from Products where CategoryID=(Select CategoryID From categories where CategoryName='Seafood'));
Select productName,SupplierID from products where SupplierID in(Select SupplierID From Suppliers where CompanyName in('exotic liquids','Grandma Kell''s Homestead','TOkyo traders'));
--join
select Employees.EmployeeID, Employees.FirstName, Employees.LastName,orders.OrderID,orders.OrderDate from Employees Join orders on (Employees.EmployeeID=orders.EmployeeID) order by Orders.OrderDate
select e.EmployeeID, e.FirstName, e.LastName,o.OrderID,o.OrderDate from Employees e Join orders o on (e.EmployeeID=o.EmployeeID) order by O.OrderDate

select o.OrderID,c.CompanyName,e.FirstName, e.LastName 
from orders o join Employees e on (e.EmployeeID=o.EmployeeID)join Customers c on (c.CustomerID=o.CustomerID) 
where o.ShippedDate>o.RequiredDate AND o.OrderDate>'1-Jan-1998' order by c.CompanyName 

-- no of emp and customer from each city that has emp in it(inner join)
select Count(Distinct e.EmployeeID)AS numEmployees, Count(Distinct c.CustomerID) AS numCompanies,e.City,c.city
From Employees e join customers c on (e.City=c.city) Group by e.City,c.city order by numEmployees DESC;

-- no of emp and customer from each city that has emp in it(left join)
select Count(Distinct e.EmployeeID)AS numEmployees, Count(Distinct c.CustomerID) AS numCompanies,e.City,c.city
From Employees e left join customers c on (e.City=c.city) Group by e.City,c.city order by numEmployees DESC;

-- no of emp and customer from each city that has emp in it(right join)
select Count(Distinct e.EmployeeID)AS numEmployees, Count(Distinct c.CustomerID) AS numCompanies,e.City,c.city
From Employees e right join customers c on (e.City=c.city) Group by e.City,c.city order by numEmployees DESC;

select Count(e.EmployeeID)AS numEmployees, Count(c.CustomerID) AS numCompanies,e.City,c.city
From Employees e left join customers c on (e.City=c.city) Group by e.City,c.city order by numEmployees DESC;

-- no of emp and customer from each city that has emp in it(outer join)
select Count(Distinct e.EmployeeID)AS numEmployees, Count(Distinct c.CustomerID) AS numCompanies,e.City,c.city
From Employees e full join customers c on (e.City=c.city) Group by e.City,c.city order by numEmployees DESC;

--unions
Select CompanyName,Phone From Shippers UNION Select CompanyName,Phone from Customers UNION select CompanyName,Phone from Suppliers order by CompanyName
--1
select e.firstName, e.lastname,o.OrderID from Employees e join orders o on (e.EmployeeID=o.EmployeeID) 
where o.RequiredDate<o.ShippedDate order by e.LastName,e.FirstName
--2
select p.ProductName ,Sum(od.Quantity) as Totalunits from [Order Details] od  join Products p on (p.ProductID=od.ProductID)
group by p.ProductName having sum(quantity)<200
--3
select c.companyName , count(o.OrderID) As numOrders from Customers c join Orders o ON (c.CustomerID = o.CustomerID)  where OrderDate >'31-dec-1996'
group by c.CompanyName having count(o.OrderDate)>15  order by numOrders DESC

select c.companyName , count(o.OrderID) As numOrders from Customers c join Orders o ON (c.CustomerID = o.CustomerID)  where OrderDate >'1996-12-31'
group by c.CompanyName having count(o.OrderDate)>15  order by numOrders DESC
--4
SELECT c.CompanyName, o.OrderID,od.UnitPrice * od.Quantity*(1-od.discount) AS TotalPrice FROM [Order details] od JOIN Orders o ON (o.OrderID = od.OrderID)
join Customers c on (c.CustomerID=o.CustomerID) WHERE od.UnitPrice * od.Quantity*(1-od.discount) > 10000 order by TotalPrice desc;
--5
--Select FirstName,HomePhone From Employees UNION Select CompanyName,Phone from Customers UNION select CompanyName,Phone from Suppliers
use Northwind
GO
BEGIN TRANSACTION
update dbo.Categories
set CategoryName='FishFood'
where CategoryName='seafood';
--RollBack Transaction
commit Transaction
select *from dbo.Categories

BEGIN TRANSACTION
update dbo.Categories
set CategoryName='seafood'
where CategoryName='Fishfood';
RollBack Transaction
select *from dbo.Categories

--join between same table -self join
select EmployeeID, FirstName,ReportsTo,Title from Employees
select e1.EmployeeID, e1.FirstName,e2.FirstName as ManagerName,e1.Title from Employees e1 inner join Employees e2 on e1.ReportsTo=e2.EmployeeID;

--select *from orders where Freight in (select Freight from orders order by Freight desc)
select *from orders where Freight in (select top 3 Freight from orders order by Freight desc)

--inline/derived table
select min(Birthdate)  from (select top 3 birthDate from Employees order by BirthDate desc)a;
select min(Birthdate)  from Employees where BirthDate in (select top 3 birthDate from Employees order by BirthDate desc)--no table formed as sq is part of where
 --example
select *from emp where sal=(select max(sal)from emp where sal<(select max(sal) from emp where sal<(select max(sal) from emp)));  
select *from emp where sal=(select min(sal) from (select top 3 sal from emp order by sal desc));
select max(Birthdate)  from (select top 3 birthDate from Employees order by BirthDate Asc)a;

--third highest freight
select top 3 freight from orders order by Freight desc
select min(freight)from (select top 3 freight from orders order by freight desc)a
select top 2 freight from orders order by Freight desc 
select min(freight)from (select top 2 freight from orders order by freight desc)a


