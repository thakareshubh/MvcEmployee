create database EmployeeMVC
--------------create table--------------

Create table tblEmployee(        
    EmployeeId int IDENTITY(1,1) NOT NULL,        
    Name varchar(20) NOT NULL,        
    profileImage varchar(250) NOT NULL,        
    Gender varchar(20) NOT NULL,        
    Department varchar(6) NOT NULL,
	salary BIGINT NOT NULL,        
	startDate  DATETIME NOT NULL,
	notes varchar(200) NOT NULL
);

select * from tblEmployee

-----------------Added-------------

Create procedure spAddEmployee         
(        
    @Name VARCHAR(20),         
    @profileImage VARCHAR(250),        
    @Gender VARCHAR(20),        
    @Department VARCHAR(6), 
	@salary BIGINT,
	@startDate DATETIME ,
	@notes VARCHAR(200) 	       
)        
as         
Begin         
    Insert into tblEmployee (Name,profileImage,Gender,Department,salary,startDate,notes)         
    Values (@Name,@profileImage,@Gender,@Department,@salary,@startDate,@notes)         
End  

----------------Update---------------

Create procedure spUpdateEmployee          
(          
   @EmployeeId INTEGER ,        
  @Name VARCHAR(20),
  @profileImage VARCHAR(250),             
   @Gender VARCHAR(20),           
    @Department VARCHAR(6),         
  @salary BIGINT,
  @startDate DATETIME , 
  @notes VARCHAR(200)       
)          
as          
begin          
   Update tblEmployee           
   set Name=@Name,          
   profileImage=@profileImage,          
   Gender=@Gender,        
   Department=@Department,
   salary=@salary,    
   startDate=@startDate,  
   notes=@notes 
   where EmployeeId=@EmployeeId          
End  


Create procedure spGetAllEmployees      
as      
Begin      
    select *      
    from tblEmployee      
End   


Create procedure spDeleteEmployee         
(          
   @EmployeeId int          
)          
as           
begin          
   Delete from tblEmployee where EmployeeId=@EmployeeId          
End