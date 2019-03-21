{  
  E1:employee(id:1){...employeeList}  
  E2:employee(id:2){...employeeList}  
}  
  
fragment employeeList on EmployeeType{  
  name, certifications {title}  
} 