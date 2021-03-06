(*

OBJECTIVE: (Problem Set 3, Question 11) Write a non-recursive fibonacci function using imperative F#.

*)

module P3Question11 = 

    let fibonacci n = 
        let fiboElement1 = ref 0
        let fiboElement2 = ref 1
        let fiboSum = ref 0
        let counter = ref 2
        while !counter <= n do
            fiboSum := !fiboElement1 + !fiboElement2
            fiboElement1 := !fiboElement2
            fiboElement2 := !fiboSum
            counter := !counter + 1
        if (n = 0) then (0)
        else if (n = 1) then (1)
        else if (n > 1) then (!fiboElement2)
        else (-1)


    printfn "\n\n\nP3Quesiton11: %d" (fibonacci 3)



    // Tail Recursive
    let fib n =
        let rec tfib n1 n2 = function
        | 0 -> n1
        | n -> tfib n2 (n2 + n1) (n - 1)
        tfib 0 1 n  


    printfn "\n\n\nTail Recursive: %d" (fib 5)
