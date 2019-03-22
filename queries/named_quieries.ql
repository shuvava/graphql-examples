query all  
{  
  employees {name certifications {title}}  
}  
query E1  
{  
  E1:employee(id:1){name, certifications {title}}  
}