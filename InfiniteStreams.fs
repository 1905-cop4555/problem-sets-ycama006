(*

OBJECTIVE: Attempting to understand how Infinite Streams work by testing and analyzing examples from lecture notes

*)


module InfinteStreams = 


    // An 'a stream thus has the form Cons(x, xsf), where x is a the head of the stream, 
    // and xsf is a function that can be called to give the tail of the stream.
    type 'a stream = 
        Cons of 'a * (unit -> 'a stream)



    // A stream consisting of the natural numbers 0, 1, 2, and so on
    let rec upfrom n = Cons( n, fun () -> upfrom(n+1) )

    let nats = upfrom 0



    // We can define a function 'take n' that returns a list consisting of the first n elements of stream s
    let rec take n (Cons(x,xsf)) =
          if n = 0 then []
                   else x :: take (n-1) ( xsf () )


    // We can define a function drop n s that drops the first n elements of stream s
    let rec drop n (Cons (x, xsf)) =
          if n = 0 then Cons (x, xsf)
                   else drop (n-1) ( xsf () )


    // We can filter a stream, selecting only those elements that satisfy a given predicate
    let rec filter p (Cons(x, xsf)) =
          if p x then Cons(x, fun () -> filter p ( xsf() )  )
                 else filter p (xsf())

    


    printfn "\nInfiniteStreams: %A" (take 2 nats)
    printfn "%A" (drop 2 nats)
    printfn "%A" ( take 2 (filter (fun n -> n%2 = 0) nats) )
