USE Northwind;
GO

DROP PROCEDURE IF EXISTS [Northwind].[GreatesOrders] 
GO

DROP PROCEDURE IF EXISTS [Northwind].[ShippedOrdersDiff] 
GO

DROP PROCEDURE IF EXISTS [Northwind].[SubordinationInfo] 
GO

DROP FUNCTION IF EXISTS [Northwind].[IsBoss]
GO

/*
13.1	Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за определенный 
год. В результатах не может быть несколько заказов одного продавца, должен быть только один и самый крупный.
В результатах запроса должны быть выведены следующие колонки: колонка с именем и фамилией продавца 
(FirstName и LastName – пример: Nancy Davolio), номер заказа и его стоимость. В запросе надо учитывать 
Discount при продаже товаров. Процедуре передается год, за который надо сделать отчет, и количество
возвращаемых записей. Результаты запроса должны быть упорядочены по убыванию суммы заказа. Процедура должна
быть реализована с использованием оператора SELECT и БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ. Название функции 
соответственно GreatestOrders. Необходимо продемонстрировать использование этих процедур. Также помимо
демонстрации вызовов процедур в скрипте Query.sql надо написать отдельный ДОПОЛНИТЕЛЬНЫЙ проверочный запрос 
для тестирования правильности работы процедуры GreatestOrders. Проверочный запрос должен выводить в
удобном для сравнения с результатами работы процедур виде для определенного продавца для всех его заказов 
за определенный указанный год в результатах следующие колонки: имя продавца, номер заказа, сумму заказа.
Проверочный запрос не должен повторять запрос, написанный в процедуре, - он должен выполнять только то, 
что описано в требованиях по нему.
*/

CREATE PROCEDURE [Northwind].[GreatesOrders]
	@year int = 1998,
	@count int = 30

AS
SELECT TOP (@count) SubQ.FullName, 
		SubQ.OrderID,
		SUM((1-Dets.Discount)*Dets.Quantity*Dets.UnitPrice+CONVERT(float,Ords.Freight)) as Price
FROM (SELECT DISTINCT Emps.FirstName+' '+Emps.LastName as FullName, 
		(SELECT TOP 1 Ords.OrderID From Northwind.Orders as Ords 
			INNER JOIN Northwind.[Order Details] as Dets  
			ON Ords.OrderID = Dets.OrderID
		WHERE Emps.EmployeeID = Ords.EmployeeID AND year(Ords.OrderDate) = (@year)
		GROUP BY Ords.OrderID
		Order By SUM((1-Dets.Discount)*Dets.Quantity*Dets.UnitPrice) DESC ) as OrderID
		FROM Northwind.Employees as Emps) as SubQ 
			INNER JOIN Northwind.[Order Details] as Dets 
			ON SubQ.OrderID = Dets.OrderID
			INNER JOIN Northwind.Orders as Ords
			ON Subq.OrderID = Ords.OrderID
GROUP BY SubQ.FullName, 
	SubQ.OrderID
GO


/*
13.2	Написать процедуру, которая возвращает заказы в таблице Orders, согласно указанному сроку 
доставки в днях (разница между OrderDate и ShippedDate).  В результатах должны быть возвращены заказы, 
срок которых превышает переданное значение или еще недоставленные заказы. Значению по умолчанию для 
передаваемого срока 35 дней. Название процедуры ShippedOrdersDiff. Процедура должна высвечивать 
следующие колонки: OrderID, OrderDate, ShippedDate, ShippedDelay (разность в днях между ShippedDate и
OrderDate), SpecifiedDelay (переданное в процедуру значение).  Необходимо продемонстрировать использование
этой процедуры.
*/
CREATE PROCEDURE [Northwind].[ShippedOrdersDiff]
	@daysdiff int = 35
AS
SELECT OrderID, 
Convert(date,OrderDate) as 'Order date', 
'Shipped date' = Case when ShippedDate IS NULL THEN 'Not Shipped' ELSE Convert(nchar(13),Convert(date,ShippedDate)) end, 
'Shipped Delay' = CASE WHEN ShippedDate IS NOT NULL THEN Convert(nvarchar(13),DATEDIFF(day,OrderDate,ShippedDate)) ELSE 'Not shipped' END , (@daysdiff) as 'Specified Delay'
FROM Northwind.Orders
WHERE DATEDIFF(day,OrderDate,ShippedDate) >= (@daysdiff) OR ShippedDate IS NULL
GO


/*
13.3	Написать процедуру, которая высвечивает всех подчиненных заданного продавца, как непосредственных, 
так и подчиненных его подчиненных. В качестве входного параметра функции используется EmployeeID. 
Необходимо распечатать имена подчиненных и выровнять их в тексте (использовать оператор PRINT) 
согласно иерархии подчинения. Продавец, для которого надо найти подчиненных также должен быть высвечен.
Название процедуры SubordinationInfo. В качестве алгоритма для решения этой задачи надо использовать 
пример, приведенный в Books Online и рекомендованный Microsoft для решения подобного типа задач. 
Продемонстрировать использование процедуры.
*/

CREATE PROCEDURE [Northwind].[SubordinationInfo]
	@id int = 0
AS
DECLARE @Fullname nvarchar(20), @Sid int, @message nvarchar(50)
DECLARE @ChildFullname nvarchar(20), @Childid int

DECLARE Emps_q Cursor FOR
SELECT FirstName+' '+LastName ,EmployeeID
FROM Northwind.Employees
Where ReportsTo = (@id)

OPEN Emps_q

    Select @message = Firstname+' '+Lastname 
	FROM Northwind.Employees 
	where EmployeeID = (@id)

	Print 'Subordinates for selected employee '+@message+'  id = '+Convert(nvarchar(2),(@id))

	print '_________________________________________________________________'
	
	
		Fetch next from Emps_q
		INTO @Fullname, @Sid

	While @@FETCH_STATUS = 0
	begin

		SELECT @message = Convert(nvarchar(2) ,@Sid)+'    '+@Fullname
		print  @message 

		DECLARE Childs CURSOR FOR 
		SELECT Firstname+' '+Lastname, EmployeeID FROM Northwind.Employees WHERE ReportsTo = (@Sid)
		

		OPEN Childs 

		SELECT @message = '  Subordinates:'
		PRINT @message

		FETCH NEXT FROM CHILDS INTO @ChildFullName, @Childid

		WHILE @@FETCH_STATUS = 0
		begin
			
			SELECT @message = '         '+Convert(nvarchar(2),@Childid)+'  '+@ChildFullname
			Print @message
			Print ' '
			FETCH NEXT FROM CHILDS INTO @ChildFullName, @Childid
		end

		CLOSE Childs
		DEALLOCATE Childs 
		
		Fetch next from Emps_q
		INTO @Fullname, @Sid
	end

CLOSE Emps_q
Deallocate Emps_q
GO


/*
Написать функцию, которая определяет, есть ли у продавца подчиненные. Возвращает тип данных BIT. 
В качестве входного параметра функции используется EmployeeID. Название функции IsBoss. 
Продемонстрировать использование функции для всех продавцов из таблицы Employees.
*/

CREATE FUNCTION [Northwind].[IsBoss] (

@id int = 0

)
RETURNS bit
AS
begin
IF ((SELECT Count(*) FROM Northwind.Employees WHERE ReportsTo = (@id)) > 0) 
	RETURN CONVERT(bit,'True');

Return Convert(bit,'False');
end
GO 