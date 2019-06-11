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

