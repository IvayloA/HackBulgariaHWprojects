USE HackCompany

CREATE TABLE [Departments]
(
   [DepartmentID] [smallint] IDENTITY(1,1) PRIMARY KEY,
   [DepartmentsName] [varchar](50) NOT NULL,
);

CREATE TABLE [Employees]
(
  [EmployeeID] [smallint] IDENTITY(1,1) PRIMARY KEY,
  [EmployeeName] [nvarchar](50) NOT NULL,
  [EmployeeEmail] [nvarchar](40) NOT NULL,
  [EmployeeDateofBirth] [datetime] NOT NULL,
  [ManagerID] [smallint]  NULL, 
  [DepartmentID] [smallint]  NULL,
  FOREIGN KEY (DepartmentID) REFERENCES [Departments](DepartmentID),
  FOREIGN KEY (ManagerID) REFERENCES [Employees](EmployeeID),
);


CREATE TABLE [Categories]
(
  [CategoryID] [smallint] IDENTITY(1,1) PRIMARY KEY,
  [CategoryCode] [nchar](3) UNIQUE,
  [CategoryName] [nvarchar](40) NOT NULL,
);

CREATE TABLE [Products]
(
 [ProductID] [smallint] IDENTITY(1,1) PRIMARY KEY,
 [ProductName] [varchar](50) NOT NULL,
 [ProductSinglePrice] [smallint] NOT NULL,
 [CategoryID] [smallint] NOT NULL,
 FOREIGN KEY (CategoryID) REFERENCES [Categories](CategoryID),
);

CREATE TABLE [Customer]
(
 [CustomerID] [smallint] IDENTITY(1,1)  PRIMARY KEY,
 [CustomerName] [nvarchar](50) NOT NULL,
 [CustomerEmail] [nvarchar](40) NOT NULL,
 [CustomerAddress] [nvarchar](80) NOT NULL,
 [CustomerDiscount] [tinyint] NOT NULL,
);

CREATE TABLE [Orders]
(
 [OrderID] [smallint] IDENTITY(1,1) PRIMARY KEY,
 [OrderDateNTime] [datetime] NOT NULL, 
 [CustomerID] [smallint] NOT NULL, 
 [OrderTotalPrice] [smallint] NOT NULL,
 FOREIGN KEY (CustomerID) REFERENCES [Customer](CustomerID),
);

CREATE TABLE [ProductOrders]
(
 [OrderID] [smallint] NOT NULL,
 [ProductID] [smallint] NOT NULL,
 FOREIGN KEY (OrderID) REFERENCES [Orders](OrderID),
 FOREIGN KEY (ProductID) REFERENCES [Products](ProductID),
);

