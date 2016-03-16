USE HackCompany
/* Select the big boss  */

SELECT  *
FROM Employees 


/* Select all department managers  */

SELECT *
FROM Employees 
WHERE Employees.ManagerID = 1

/* Select all employees in the Sales department ordered by Name  */

SELECT Employees.EmployeeName, Departments.DepartmentsName 
FROM Departments 
JOIN Employees  ON Departments.DepartmentID = Employees.DepartmentID 
WHERE Departments.DepartmentID = 1
ORDER BY Employees.EmployeeName

/* Select all departments with employees that are born after 1985  */

SELECT Employees.EmployeeName,Employees.EmployeeEmail,Employees.EmployeeDateofBirth, Departments.DepartmentsName
FROM Departments 
join Employees  ON Departments.DepartmentID = Employees.DepartmentID
WHERE Employees.EmployeeDateofBirth > '12-31-1985'

/* Select all departments with more than 3 employees */

SELECT RealResult.DepartmentID, Departments.DepartmentsName
FROM (SELECT Employees.DepartmentID, COUNT (Employees.DepartmentID) AS Result 
      FROM Employees  
	  GROUP BY Employees.DepartmentID) AS RealResult, Departments
WHERE Result > 3 and RealResult.DepartmentID = Departments.DepartmentID

/* Select the department having the most employees */

SELECT TOP 1  COUNT(Employees.DepartmentID), Departments.DepartmentsName
FROM Departments
JOIN Employees  ON Employees.DepartmentID = Departments.DepartmentID
GROUP BY Employees.DepartmentID, Departments.DepartmentsName
ORDER BY COUNT(Employees.DepartmentID) DESC

/* Select the order having the maximum  number of products */

SELECT TOP 1 COUNT(Orders.OrderID) AS NumberOfProducts , Orders.OrderID
 FROM Orders
 JOIN ProductOrders ON ProductOrders.OrderID = Orders.OrderID
 JOIN Products ON ProductOrders.ProductID = Products.ProductID
 GROUP BY Orders.OrderID 
 ORDER BY COUNT(Orders.OrderID) DESC


/* Select the average discount of all customers*/

SELECT	AVG(Customer.CustomerDiscount) AS CustomerDiscount
FROM Customer
WHERE Customer.CustomerDiscount > 0



/* Manipulating data */

/* Update all employees adding 1 year to their birth date */
UPDATE Employees
SET EmployeeDateofBirth = DATEADD(YEAR,1,Employees.EmployeeDateofBirth)


/* Double the discount of the customer with most orders */
DECLARE @DER INT
SELECT top 1 @DER = Orders.CustomerID
FROM Orders
JOIN Customer ON Orders.CustomerID = Customer.CustomerID
GROUP BY  Orders.CustomerID
ORDER BY COUNT(Orders.CustomerID) DESC

UPDATE Customer
SET CustomerDiscount = CustomerDiscount * 2 
WHERE Customer.CustomerID = @DER
