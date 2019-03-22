query all($ShowLongDescription : Boolean!)  
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