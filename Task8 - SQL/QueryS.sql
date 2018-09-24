/* 
1.1 Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate)
включительно и которые доставлены с ShipVia >= 2. Формат указания даты должен быть верным при любых 
региональных настройках, согласно требованиям статьи “Writing International Transact-SQL Statements”
в Books Online раздел “Accessing and Changing Relational Data Overview”. 
Этот метод использовать далее для всех заданий. Запрос должен высвечивать только колонки
OrderID, ShippedDate и ShipVia. 
Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate. 
*/

SELECT ORDERID, 
		SHIPPEDDATE, 
		SHIPVIA 
FROM Northwind.Orders  
WHERE ShippedDate >= {d' 1998-05-06'} AND ShipVia>=2


/*
1.2 Написать запрос, который выводит только недоставленные заказы из таблицы Orders. 
В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’ – 
использовать системную функцию CASЕ. Запрос должен высвечивать только колонки OrderID и ShippedDate.
*/

SELECT OrderID, 
		ShippedDate = 
		CASE 
			WHEN ShippedDate IS NULL 
			THEN 'Not Shipped'
		END 
FROM Northwind.Orders 
Where ShippedDate is NULL

/*
1.3	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate) 
не включая эту дату или которые еще не доставлены. В запросе должны высвечиваться только колонки 
OrderID (переименовать в Order Number) и ShippedDate (переименовать в Shipped Date).
В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’, 
для остальных значений высвечивать дату в формате по умолчанию.
*/

SELECT OrderID as "Order Number", 
		'Shipped date' = 
		CASE 
			WHEN ShippedDate IS NULL 
			THEN 'Not Shipped'
			ELSE Convert(nvarchar(20),ShippedDate)	
		END 
FROM Northwind.Orders 
WHERE (ShippedDate > {d' 1998-05-06'} OR ShippedDate is NULL)

/* 
2.1	Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada. 
Запрос сделать с только помощью оператора IN. Высвечивать колонки с именем пользователя и 
названием страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков и по месту 
проживания.
*/

SELECT ContactName, 
		Country 
FROM Northwind.Customers 
WHERE Country IN ('USA','CANADA') 
ORDER BY ContactName , 
		Country

/*
2.2	Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. 
Запрос сделать с помощью оператора IN. Высвечивать колонки с именем пользователя и названием страны в 
результатах запроса. Упорядочить результаты запроса по имени заказчиков.
*/

SELECT ContactName, 
		Country 
FROM Northwind.Customers 
WHERE Country NOT IN ('USA','CANADA') 
ORDER BY ContactName


/*
2.3	Выбрать из таблицы Customers все страны, в которых проживают заказчики. 
Страна должна быть упомянута только один раз и список отсортирован по убыванию.
Не использовать предложение GROUP BY. Высвечивать только одну колонку в результатах запроса.
*/

SELECT DISTINCT Country 
FROM Northwind.Customers 
ORDER BY Country DESC

/*
3.1	Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться),
где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity 
в таблице Order Details. Использовать оператор BETWEEN. 
Запрос должен высвечивать только колонку OrderID.
*/

SELECT DISTINCT OrderID 
FROM Northwind.[Order Details] 
WHERE Quantity between 3 and 10 

/*
3.2	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы 
из диапазона b и g. Использовать оператор BETWEEN. Проверить, что в результаты запроса попадает Germany. 
Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
*/

SELECT CustomerID , Country 
FROM Northwind.Customers 
WHERE Country between 'b%' and  'h%' 
ORDER BY Country


/*
3.3	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из 
диапазона b и g, не используя оператор BETWEEN. С помощью опции “Execution Plan” определить какой запрос 
предпочтительнее 3.2 или 3.3 – для этого надо ввести в скрипт выполнение текстового Execution Plan-a 
для двух этих запросов, результаты выполнения Execution Plan надо ввести в скрипт в виде комментария 
и по их результатам дать ответ на вопрос – по какому параметру было проведено сравнение. 
Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
Ответ: Так как планы идентичны, то оба запроса можно считать предпочтительными или наоборот.
*/
SELECT CustomerID , Country
FROM Northwind.Customers
WHERE Country >= 'b%' and  Country <='h%' 
ORDER BY Country


/*
4.1	В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'.
Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине - найти все продукты, 
которые удовлетворяют этому условию. Подсказка: результаты запроса должны высвечивать 2 строки.
*/

SELECT ProductName 
FROM Northwind.Products
WHERE ProductName LIKE '%cho_olade%'

/*
5.1	Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных товаров и 
скидок по ним. Результат округлить до сотых и высветить в стиле 1 для типа данных money.  
Скидка (колонка Discount) составляет процент из стоимости для данного товара. 
Для определения действительной цены на проданный продукт надо вычесть скидку из указанной 
в колонке UnitPrice цены. Результатом запроса должна быть одна запись с одной колонкой с названием 
колонки 'Totals'.
*/

SELECT CONVERT(money,Round(SUM(Quantity*UnitPrice*(1-Discount)),2),1) as 'Totals'
FROM Northwind.[Order Details]

/*
5.2	По таблице Orders найти количество заказов, которые еще не были доставлены 
(т.е. в колонке ShippedDate нет значения даты доставки). Использовать при этом запросе только 
оператор COUNT. Не использовать предложения WHERE и GROUP.
*/
SELECT COUNT(
	Case 
		WHEN ShippedDate IS NULL 
		THEN 1 else NULL 
	END) as 'Count'
FROM Northwind.Orders 

/*
таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы. 
Использовать функцию COUNT и не использовать предложения WHERE и GROUP.
*/
SELECT COUNT(DISTINCT CustomerID) as 'Different customers count' 
FROM Northwind.Orders

/*
6.1	По таблице Orders найти количество заказов с группировкой по годам. 
В результатах запроса надо высвечивать две колонки c названиями Year и Total. 
Написать проверочный запрос, который вычисляет количество всех заказов.
*/

SELECT year(Orderdate) as 'Year', 
		Count(OrderID) as 'Total'
FROM Northwind.Orders 
GROUP BY year(OrderDate)

/*
6.1 Проверочный запрос 
*/
Select COUNT(OrderID) as 'Amount' 
From Northwind.Orders

/*
6.2	По таблице Orders найти количество заказов, cделанных каждым продавцом. Заказ для указанного 
продавца – это любая запись в таблице Orders, где в колонке EmployeeID задано значение для данного продавца.
В результатах запроса надо высвечивать колонку с именем продавца (Должно высвечиваться имя полученное 
конкатенацией LastName & FirstName. Эта строка LastName & FirstName должна быть получена отдельным запросом 
в колонке основного запроса. Также основной запрос должен использовать группировку по EmployeeID.) 
с названием колонки ‘Seller’ и колонку c количеством заказов высвечивать с названием 'Amount'.
Результаты запроса должны быть упорядочены по убыванию количества заказов
*/

SELECT (CONVERT(varchar , 
	(SELECT TOP 1 FirstName+' '+LastName 
	FROM Northwind.Employees 
	WHERE EmployeeID = Northwind.Orders.EmployeeID)))as 'Seller', 
	Count(EmployeeID) as Amount
FROM Northwind.Orders 
GROUP BY EmployeeID 
ORDER BY Amount DESC 

/*
6.3	По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя.
Необходимо определить это только для заказов сделанных в 1998 году. В результатах запроса надо высвечивать 
колонку с именем продавца (название колонки ‘Seller’), колонку с именем покупателя (название колонки 
‘Customer’)  и колонку c количеством заказов высвечивать с названием 'Amount'. В запросе необходимо 
использовать специальный оператор языка T-SQL для работы с выражением GROUP (Этот же оператор поможет 
выводить строку “ALL” в результатах запроса). Группировки должны быть сделаны по ID продавца и покупателя.
Результаты запроса должны быть упорядочены по продавцу, покупателю и по убыванию количества продаж.
В результатах должна быть сводная информация по продажам. Т.е. в резульирующем наборе должны присутствовать
дополнительно к информации о продажах продавца для каждого покупателя следующие строчки: 
*/

SELECT 'Seller' = 
		CASE 
			WHEN EmployeeID IS NULL 
			THEN 'ALL' 
			ELSE 
			(SELECT TOP 1 FirstName+' '+ LastName  
			FROM Northwind.Employees 
			WHERE EmployeeID = Northwind.Orders.EmployeeID) 
		END , 
	'Customer' =  
		CASE 
			WHEN CustomerID IS NULL 
			THEN 'ALL' 
			ELSE 
			(SELECT TOP 1 ContactName 
			FROM Northwind.Customers 
			WHERE CustomerID = Northwind.Orders.CustomerID ) 
		END ,
		Count(CustomerID) as 'Amount' 
FROM Northwind.Orders WHERE year(OrderDate)=1998  
Group by CUBE(EmployeeID , CustomerID ) 
ORDER BY 'Seller','Customer','Amount'



/*
6.4	Найти покупателей и продавцов, которые живут в одном городе. Если в городе живут только один или 
несколько продавцов или только один или несколько покупателей, то информация о таких покупателя и 
продавцах не должна попадать в результирующий набор. Не использовать конструкцию JOIN. В результатах
запроса необходимо вывести следующие заголовки для результатов запроса: ‘Person’, ‘Type’ 
(здесь надо выводить строку ‘Customer’ или  ‘Seller’ в завимости от типа записи), ‘City’. 
Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.
*/

SELECT Cust.ContactName as 'Person' , 
		Cust.City as 'City', 'Type' = 'Customer'
FROM Northwind.Customers as Cust
WHERE (SELECT COUNT(*) 
	FROM Northwind.Employees as EM 
	WHERE Cust.City = EM.City) > 0 

UNION 

Select Emp.FirstName+' '+Emp.LastName as 'Person', 
		Emp.City as 'City', 'Type' = 'Employee'
From Northwind.Employees as Emp
WHERE (SELECT COUNT(*) 
	FROM Northwind.Customers as Cus 
	WHERE Emp.City = Cus.City) > 0 
ORDER by 'City', 'Person'

/*
6.5	Найти всех покупателей, которые живут в одном городе. В запросе использовать соединение таблицы 
Customers c собой - самосоединение. Высветить колонки CustomerID и City. Запрос не должен высвечивать 
дублируемые записи. Для проверки написать запрос, который высвечивает города, которые встречаются более 
одного раза в таблице Customers. Это позволит проверить правильность запроса.
*/

SELECT DISTINCT Cust1.CustomerID, 
		Cust1.City
FROM Northwind.Customers as Cust1 INNER JOIN Northwind.Customers as Cust2 ON Cust1.City = Cust2.City
WHERE Cust1.CustomerID != Cust2.CustomerID

/* 
6.5 Проверочный запрос 
*/
SELECT City, 
		Count(City) as 'Quantity'
FROM Northwind.Customers
Group by City
HAVING Count(City)>1

/*
6.6	По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты. 
Высветить колонки с именами 'User Name' (LastName) и 'Boss'. В колонках должны быть высвечены имена из 
колонки LastName. Высвечены ли все продавцы в этом запросе?
Высвечиваютс все продавцы в данном запросе, но не у всех имеются руководители (такие как Fuller).
*/
SELECT LastName as 'User name', 
	(SELECT TOP 1 LastName 
	FROM Northwind.Employees as Em 
	WHERE EmployeeID=Emp.ReportsTo) as 'Boss'
FROM Northwind.Employees as Emp
Order by 'User name'


/*
7.1	Определить продавцов, которые обслуживают регион 'Western' (таблица Region). Результаты запроса 
должны высвечивать два поля: 'LastName' продавца и название обслуживаемой территории 
('TerritoryDescription' из таблицы Territories). Запрос должен использовать JOIN в предложении FROM. 
Для определения связей между таблицами Employees и Territories надо использовать графические диаграммы 
для базы Northwind.
*/

SELECT E.LastName as LastName, 
		T.TerritoryDescription
FROM Northwind.EmployeeTerritories as ET INNER JOIN Northwind.Employees as E 
	ON ET.EmployeeID = E.EmployeeID
	INNER JOIN Northwind.Territories T 
	ON ET.TerritoryID = T.TerritoryID
	INNER JOIN Northwind.Region R 
	ON R.RegionID = T.RegionID 
WHERE R.RegionDescription = 'Western'

/*
8.1	Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное количество их 
заказов из таблицы Orders. Принять во внимание, что у некоторых заказчиков нет заказов, но они также должны 
быть выведены в результатах запроса. Упорядочить результаты запроса по возрастанию количества заказов.
*/

SELECT C.ContactName as 'Name' , 
		COUNT(O.CustomerID) as 'Quantity'
FROM Northwind.Customers C FULL OUTER JOIN Northwind.Orders O ON C.CustomerID = O.CustomerID 
Group by C.CustomerID , ContactName 
Order by 'Quantity' 


/*
9.1	Высветить всех поставщиков колонка CompanyName в таблице Suppliers, у которых нет хотя бы одного 
продукта на складе (UnitsInStock в таблице Products равно 0). Использовать вложенный SELECT для этого 
запроса с использованием оператора IN. Можно ли использовать вместо оператора IN оператор '=' ?
Нельзя в данной ситуации использовать '=' вместо IN т.к. подзапрос возвращает более 1 записи. 
*/

SELECT CompanyName 
FROM Northwind.Suppliers as S
WHERE S.SupplierID in (SELECT SupplierID 
	FROM Northwind.Products 
	WHERE UnitsInStock = 0)


/*
10.1 Высветить всех продавцов, которые имеют более 150 заказов.
Использовать вложенный коррелированный SELECT.
*/

SELECT FirstName+' '+LastName as 'Name'
FROM Northwind.Employees
WHERE EmployeeID IN 
	(SELECT EmployeeID
	FROM Northwind.Orders as P 
	GROUP BY EmployeeID
	HAVING COUNT(EmployeeID)>150)

/*
11.1	Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа 
(подзапрос по таблице Orders). Использовать коррелированный SELECT и оператор EXISTS.
*/

SELECT Cust.ContactName
FROM Northwind.Customers as Cust
WHERE NOT EXISTS (SELECT DISTINCT CustomerID 
	FROM Northwind.Orders as O 
	WHERE Cust.CustomerID = O.CustomerID )

/*
12.1	Для формирования алфавитного указателя Employees высветить из таблицы Employees список только 
тех букв алфавита, с которых начинаются фамилии Employees (колонка LastName ) из этой таблицы. 
Алфавитный список должен быть отсортирован по возрастанию.
*/

SELECT LEFT(LastName,1) as Letter
FROM Northwind.Employees
ORDER BY Letter


/*
13.1 Вызов процедуры. Первый аргумен - год, для которого нужно найти максимальные заказы, второй 
аргумент - колличество выводимых записей. 
*/
EXEC Northwind.GreatesOrders 1998, 9

/*
13.1 Проверочный запрос
*/

SELECT DISTINCT Emp.FirstName+' '+Emp.LastName as 'Name', 
	O.OrderID, 
	SUM((1-Dets.Discount)*Dets.Quantity*Dets.UnitPrice+O.Freight) as Price
FROM Northwind.Orders as O 
	INNER JOIN Northwind.Employees as Emp 
	ON O.EmployeeID = Emp.EmployeeID
	INNER JOIN Northwind.[Order Details] as Dets 
	ON O.OrderID = Dets.OrderID
WHERE year(O.OrderDate) = 1998
Group by Emp.FirstName, Emp.LastName, O.OrderID, O.Freight
Order By 'Name', Price


/*
13.2 Вызов процедуры где аргумент - колличество дней разницы между заказом и доставкой
*/

EXEC Northwind.ShippedOrdersDiff 14

/*
/13.3 Вызов процедуры, где аргумент - id работника, для которого нужно найти подчиненных
*/

EXEC Northwind.SubordinationInfo 2

/*
13.4 Пример использования функции IsBoss. В данном примере определяется для каждоого работника есть ли у 
него подчиненные при помощи функции IsBoss, которая принимает ID работника
*/

SELECT Firstname+' '+Lastname as 'Name' , 'Is Boss' = Case WHEN Northwind.IsBoss(EmployeeID) = 1 THEN 'Boss' ELSE 'Not boss' END
FROM Northwind.Employees
