query all($ShowLongDescription : Boolean=false)  
{  
  employees  
  {  
    id  
    name  
    email  
    mobile  
    address  
    shortDescription  
    longDescription @include(if: $ShowLongDescription)  
}  
} 