delete from TicketType where TicketTypeId!=1

go

delete from Ticket where EmployeeId!=2

go

delete from EmployeeSupervisors where EmployeeId!=2

go 

delete from EmployeePayroll

go

delete from Attendance where EmployeeId!=2

go 

delete from Employee where EmployeeId!=2

go

delete from [Charge]

go

delete from [Case] 

go

delete from [Order]  

go

delete from OrderStatus

go

delete from MenuRight where Role_Id!=1

--go 

--delete from Designation where DesignationId!=2

go 
 
delete from County

go 

delete from Country

go

delete from CategoryLog

go 

delete from Category

go

delete from AspNetUserRoles where UserId!='53752d93-51ba-4374-86fe-c289a8662872'

go

delete from AspNetUsers where Id!='53752d93-51ba-4374-86fe-c289a8662872'

--go

--delete from AllowanceType 