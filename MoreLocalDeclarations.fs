(*

OBJECTIVE: Practicing more local declaration techniques with F#, specifically concepts such as 
           recomputation and auxiliary functions


*)



module MoreLocalDeclarations = 

   

    (*
        In roots, for example, we calculate disc and twoa only once, 
        but use them twice. While the savings in this case is modest, 
        sometimes avoiding recomputation can be critical to the efficiency 
        of a program.
    *)
    // Here is a function to find the roots of a quadratic polynomial

    let roots (a,b,c) =
        let disc = sqrt (b*b - 4.0*a*c)
        let twoa = 2.0*a
        (  (-b + disc)/twoa, (-b-disc)/twoa  )

    printfn "\n\nroot function outputs: %A" ( roots (1.0, 5.0, 6.0) )




    (*

        Another (less important) use of local declarations is to define 
        auxiliary functions within the definition of an outer function. 
        Such auxiliary functions are not visible outside; also, they 
        have access to the outer function's parameters. 

    *)
    ///????????????????????????????
    (*
    let map f xs = 
        let rec map_aux = functions
        | []     ->  []
        |y::ys  ->  f y :: map_aux ys
        map_aux xs

    printfn "\nmap function outputs: %d" ( map  )
    *)





    (*

        When defining functions, simultaneous declaration using
        permits mutual recursion

    *)
    /// Here is Factorial function
    let rec fFunction n =     if n = 0 then 1   else gFunction n 
    and gFunction m =  m * fFunction(m-1)

    printfn "fFunction outputs: %d" ( fFunction 3 )
