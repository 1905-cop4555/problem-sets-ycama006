(*

OBJECTIVE: (Problem Set 3, Question 6) 

*)


module P3Question6 = 


    // Generate an infinite sequence for the alternating series of 1/(2**n):
    // 1/2, -1/4, 1/8, -1/16, 1/32, -1/64, ...

    let altSeriesA = Seq.initInfinite (fun index ->
        let powerNtimes = float (index + 1)
        let rec two = function
            |0.0 -> 1.0
            |powerNtimes -> 2.0 * two (powerNtimes-1.0)

        1.0 / (two powerNtimes) * (if ( (index + 2) % 2 = 0) then 1.0 else -1.0)
        )


    printfn "\n\nP3Question6A: %A" (altSeriesA)
    
    
    
    
    //------------------------------------------------------------
    
    
    // Display the 5th through 15th numbers in the series. 
    // The numbers should display as the floating point version of the fractions.
    
    let altSeriesB = Seq.initInfinite (fun index ->
        let powerNtimes = float (index + 5)
        let rec two = function
            |0.0 -> 1.0
            |powerNtimes -> 2.0 * two (powerNtimes-1.0)

        1.0 / (two powerNtimes) * (if ( (index + 2) % 2 = 0) then 1.0 else -1.0)
        )

    let specificElements = 
        altSeriesB 
        |> Seq.take 11
        |> Seq.toList
        

    printfn "\nP3Question6B: %A" (specificElements)   
    
    
    /------------------------------------------------------------
    
    
    // Generate an infinite stream for the alternating series of 1/(2**n):
    // 1/2, -1/4, 1/8, -1/16, 1/32, -1/64, ...
    type 'a stream = 
        Cons of 'a * (unit -> 'a stream)


    let rec two = function
        |0.0 -> 1.0
        |powerNtimes -> 2.0 * two (powerNtimes-1.0)


    let rec upfrom powerNtimes = Cons( 1.0 / (two powerNtimes) * (if ( (powerNtimes + 1.0) % 2.0 = 0.0) then 1.0 else -1.0), fun () -> upfrom(powerNtimes+1.0))


    let altSeriesC = upfrom 1.0

    
    let rec take n (Cons(x,xsf)) =
          if n = 0 then []
                   else x :: take (n-1) ( xsf () )



    // Display numbers up to the 15th number in the series. 
    // The numbers should display as the floating point version of the fractions.
    printfn "\nP3Question6C: %A" (take 15 altSeriesC)
    
    
    /------------------------------------------------------------
    
    // Display the 5th through 15th numbers in the series. 
    // The numbers should display as the floating point version of the fractions.
    let altSeriesD = upfrom 5.0
    printfn "\nP3Question6D: %A" (take 11 altSeriesD)


