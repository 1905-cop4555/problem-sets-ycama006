(*

OBJECTIVE: Practice more pattern matching techniques with F#, specifically the 4 advantages given in lecture

*)




module LecturesPatternMatching = 

    
    // Here are functions that find the last element of a list
    
    
    
    let rec last0 = function
        |[x]    ->  x
        |x::xs  -> last0 xs

    printfn "\n\nLast element of the list0 [1;2;3;4;5] is: %d" ( last0 [1;2;3;4;5] )
    ///printfn "Last element of the list0 [] is %d\n\n" ( last0 [] )


    let rec last1 = function
        |[]     ->  failwith "empty list has no last element"
        |[x]    ->  x
        |x::xs  -> last1 xs
        
    printfn "\n\nLast element of the list1 [1;2;3;4;5] is: %d" ( last1 [1;2;3;4;5] )
    ///printfn "Last element of the list1 [] is %d\n\n" ( last1 [] )



    let rec last2 xs = 
        if List.isEmpty (List.tail xs) then List.head xs else last2 (List.tail xs)

    printfn "\n\nLast element of the list2 [1;2;3;4;5] is: %d" ( last2 [1;2;3;4;5] )
   ///printfn "Last element of the list2 [] is %d\n\n" ( last2 [] )



   ///Not fully polymorphic because of " = [] "
    let rec last3 xs = 
        if List.tail xs = [] then List.head xs else last3 (List.tail xs)

    printfn "\n\nLast element of the list3 [1;2;3;4;5] is: %d" ( last3 [1;2;3;4;5] )
    ///printfn "Last element of the list3 [] is %d\n\n" ( last3 [] )


    
    let rec last4 = function 
    |[]    -> failwith "empty list has no last element"
    |x::xs -> last4 xs
    |[x]   -> x

    printfn "\n\nLast element of the list4 [1;2;3;4;5] is: %d" ( last4 [1;2;3;4;5] )
    ///printfn "Last element of the list4 [] is %d\n\n" ( last4 [] )
