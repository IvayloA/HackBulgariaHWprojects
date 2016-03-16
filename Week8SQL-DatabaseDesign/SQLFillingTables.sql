USE HackCompany 

INSERT INTO Departments(DepartmentsName)
VALUES ('Sales'),
('Production'),
('Financial');

INSERT INTO Employees(EmployeeName,EmployeeEmail,EmployeeDateofBirth,ManagerID,DepartmentID)
VALUES('Ivan','Ivan@gmail.com','04-03-1970',null,null)

INSERT INTO Employees(EmployeeName,EmployeeEmail,EmployeeDateofBirth,ManagerID,DepartmentID)
VALUES('Todor','Todor@gmail.com','11-06-1975',1,1),
('Bill','Bill@gmail.com','03-06-1974',1,2),
('Mandy','Mandy@gmail.com','06-13-1977',1,3);

INSERT INTO Employees(EmployeeName,EmployeeEmail,EmployeeDateofBirth,ManagerID,DepartmentID)
VALUES('Sarah','Sarah@gmail.com','01-12-1976',2,1),
('Joe','Joe@yahoo.com','02-11-1982',2,1),
('Tim','Tim@gmail.com','11-23-1983',2,1),
('Dave','Dave@yahoo.com','05-22-1986',2,1),
('Rado','Rado@gmail.com','11-02-1987',2,1);

INSERT INTO Employees(EmployeeName,EmployeeEmail,EmployeeDateofBirth,ManagerID,DepartmentID)
VALUES('Mike','Mike@gmail.com','01-10-1979',3,2),
('Jennifer','Jennifer@yahoo.com','02-11-1989',3,2),
('Tom','Tom@gmail.com','11-13-1986',3,2),
('Jerry','Jerry@yahoo.com','06-14-1982',3,2),
('Alex','Akex@gmail.com','02-14-1987',3,2);

INSERT INTO Employees(EmployeeName,EmployeeEmail,EmployeeDateofBirth,ManagerID,DepartmentID)
VALUES('Mia','Mia@gmail.com','05-18-1976',4,3),
('Lisa','Lisa@yahoo.com','04-19-1982',4,3),
('Eric','Eric@gmail.com','01-17-1986',4,3),
('Peter','Peter@yahoo.com','09-15-1985',4,3),
('Finn','Finn@gmail.com','08-13-1983',4,3);

INSERT INTO Employees(EmployeeName,EmployeeEmail,EmployeeDateofBirth,ManagerID,DepartmentID)
VALUES('Amy','Amy@gmail.com','05-18-1988',4,3)

/* Execute below */

INSERT INTO Categories(CategoryCode,CategoryName)
VALUES('se2','Books'),
('d2a','Music'),
('dw2','Hardware'),
('gs2','Software');

INSERT INTO Products(ProductName,CategoryID,ProductSinglePrice)
VALUES('Lord Of The Rings',1,29),
('Hunger Games',1,30),
('C# for dummies',1,50),
('The power of habbit',1,70),
('Hip-Hop',2,60),
('Metal',2,60),
('RockNRoll',2,60),
('Razor Naga',3,90),
('Razor Blackwidow',3,120),
('Steelseries KeyBoard',3,80),
('AntiVirusSys',4,50),
('VisualStudio',4,1),
('Eclipse',4,1);

INSERT INTO Customer(CustomerName,CustomerEmail,CustomerAddress,CustomerDiscount)
VALUES('Maria','Maria@gmail.com','Bulgaria, Sofia',10),
('Jenny','Jenny@panda.com','France, Paris',13),
('Arnold','Arnold@gmail.com','Germany, Berlin',5),
('Rafael','Rafael@yahoo.com','Spain, Madrid',9),
('Steve','Steve@gmail.com','USA, Nevada',15);

INSERT INTO Orders(CustomerID,OrderDateNTime,OrderTotalPrice)
VALUES(1,'05-07-2015',60),
(2,'08-11-2015',25),
(1,'05-07-2015',50),
(2,'08-11-2016',60),
(3,'09-10-2016',100);

INSERT INTO ProductOrders(ProductID,OrderID)
VALUES (1,1),
(2,1),
(7,1),
(5,2),
(9,2),
(3,3),
(10,3);

INSERT INTO ProductOrders(ProductID,OrderID)
VALUES (11,2), 
(4,2)

INSERT INTO Orders(CustomerID,OrderDateNTime,OrderTotalPrice)
VALUES(2,'06-08-2015',50)