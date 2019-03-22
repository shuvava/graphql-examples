query E1($EmployeeId : ID!)  
{  
  employee(id:$EmployeeId){name, certifications {title}}  
}