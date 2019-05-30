(*

OBJECTIVE: (Problem set 2: Question5) Given vectors u = (u1, u2,..., un) and v = (v1, v2,..., vn), 
the inner product of u and v is defined to be u1*v1 + u2*v2 + ... + u n*vn. 
Write a curried F# function inner that takes two vectors represented as 
int list and returns their inner product.

*)



module P2Question5 = 




    let rec innerNonTail x y = 
        match (x,y) with
        | ([], [])        -> 0
        | (_, [])         -> failwith ("lists do not have the same length")
        | ([], _)         -> failwith ("lists do not have the same length")
        | (x::xs, y::ys)  -> x * y + innerNonTail xs ys

    printfn "\n\ninnerNonTail output is: %d" ( innerNonTail [1;2;3] [4;5;6] )




    let rec inner_Tail x y tail =
        match (x,y) with
        | ([], [])         -> tail
        | (_, [])          -> failwith ("lists do not have the same length")
        | ([], _)          -> failwith ("lists do not have the same length")
        | (x::xs, y::ys)   -> inner_Tail xs ys (tail + x * y)


    let innerTail x y = inner_Tail x y 0
        

    printfn "innerTail output is: %d\n\n" ( innerTail [1;2;3] [4;5;6] )
