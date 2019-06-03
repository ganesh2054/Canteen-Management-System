  
Alter procedure GetEmployeeDetails  
as  
begin  
select Emp_id,Name,DOB,Salary,Gender,Email_address,Mobile,EmploymentDate from EmployeeDetails  
end