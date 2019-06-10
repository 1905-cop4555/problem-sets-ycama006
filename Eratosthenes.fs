(*

OBJECTIVE = Attempted the stream of primes by using the sieve of Eratosthenes from lecture notes

*)


module Erastosthenes = 


    type 'a stream = 
        Cons of 'a * (unit -> 'a stream)


    let rec filter p (Cons(x, xsf)) =
          if p x then Cons(x, fun () -> filter p ( xsf () )  )
                 else filter p (xsf () )


    let rec upfrom n = Cons( n, fun () -> upfrom(n+1) )


    let rec eratosthenes (Cons(x, xsf)) =
          Cons(  x, fun () -> eratosthenes ( filter (fun n -> n%x <> 0) ( xsf () )   )    )
          

    let primes = eratosthenes (upfrom 2)



    let rec take n (Cons(x,xsf)) =
          if n = 0 then []
                   else x :: take (n-1) ( xsf () )


    let rec drop n (Cons (x, xsf)) =
          if n = 0 then Cons (x, xsf)
                   else drop (n-1) ( xsf () )

                   


    printfn "\n\nErastosthenes: %A" (take 10 primes)
    printfn "%A" ( take 5 (drop 9 primes) )
