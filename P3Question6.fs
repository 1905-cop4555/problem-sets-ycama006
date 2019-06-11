(*

OBJECTIVE: (Problem Set 3, Question 6) 

*)


module P3Question6 = 

    let altSeries = Seq.initInfinite (fun index ->
        let powerNtimes = float (index + 1)
        let rec two = function
            |0.0 -> 1.0
            |powerNtimes -> 2.0 * two (powerNtimes-1.0)

        1.0 / (two powerNtimes) * (if ( (index + 2) % 2 = 0) then 1.0 else -1.0)
        )


    printfn "\n\nP3Question6: %A" (altSeries)
