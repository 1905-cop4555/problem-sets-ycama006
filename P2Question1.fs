(*


OBJECTIVE: (Problem set 2: Question 1) Define a F# function curry f that converts an uncurried function to a curried function, 
           and an F# function uncurry f that does the opposite conversion.

*)



module P2Question1 = 

    // The curry type is    : int -> int -> int
    //The uncurry type is   : int * int -> int


   //curry f = converts an uncurried function to a curried function


   //uncurry f = converts a curry function to a uncurried function


   ///-----------------------------------------------------------------------


    let addp (x,y) = x + y
    printfn "\n\n(uncurry)addp function outputs: %d" ( addp (2,3) )

    let addc x y = x + y
    printfn "(curry)addc function outputs: %d" ( addc 3 10 )


    ///---------------------------------------------------------------------


    let uncurry f (a,b) = f a b
    let uncurriedPlus = uncurry (+) 
    printfn "\n\n(uncurry)plus function outputs: %d" ( uncurriedPlus (2,3) )



    let curry f a b = f (a,b)
    let curriedPlus = curry uncurriedPlus
    let plus3 = curriedPlus 3
    printfn "(curry)plus function outputs: %d" ( plus3 10 )
    
