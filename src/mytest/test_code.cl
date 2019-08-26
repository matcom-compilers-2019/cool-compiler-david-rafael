class Main inherits IO {
  exp(x : Int) : Int {
    if (x >= 1)
    then
      (exp((x / 2)) + 1 )
    else
      1
         
      
     
    fi
  };
  main() : Object { {
    out_int(exp(3));
   
    
  } };
};
