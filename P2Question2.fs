(*

OBJECTIVE: (Problem set 2: Question 3) In the Notes on Programming Language Syntax page, an example syntax checker 
for a simple language is given, using C syntax. Write the syntax checker using F#, but 
you may only use functional programming and immutable date.

*)


module P2Question3 = 



    type TERMINAL = IF|THEN|ELSE|BEGIN|PRINT|END|SEMICOLON|ID|EOF


    let eat token = function
    | []       -> failwith "Premature termination of input"
    | x::xs    ->
        if x = token
        then xs
        else failwith (sprintf "want %A, got %A" token x)

    let E = eat ID

    let rec S = function
    | []    -> failwith "Premature termination of input"
    | x::xs ->
        match x with
        | IF    -> xs |> E |> eat THEN |> S |> eat ELSE |> S
        | BEGIN -> xs |> S |> L
        | PRINT -> xs |> E
        | EOF   -> x::xs 
        | _     -> failwith (sprintf "wanted IF, BEGIN, PRINT, OR EOF, got %A" x )

    and L = function
    | []       -> failwith "Premature termination of input"
    | x::xs    -> 
        match x with 
        | END       -> xs
        | SEMICOLON -> xs |> S |> L
        | _         -> failwith (sprintf "wanted END or SEMICOLON, got %A" x)
        





    let accept() = printfn "Program Accepted"
    let error() = printfn "Program Failed"


    let test_program program_tokens =
          let result = program_tokens |> S 
          match result with 
          | [] -> failwith "Early termination or missing EOF"
          | x::xs -> if x = EOF then accept() else error()





    //Program Accepted
    test_program [IF;ID;THEN;BEGIN;PRINT;ID;SEMICOLON;PRINT;ID;END;ELSE;PRINT;ID;EOF]

    //Program Accepted
    test_program [IF;ID;THEN;IF;ID;THEN;PRINT;ID;ELSE;PRINT;ID;ELSE;BEGIN;PRINT;ID;END;EOF]

    //Program Error
    test_program [IF;ID;THEN;BEGIN;PRINT;ID;SEMICOLON;PRINT;ID;SEMICOLON;END;ELSE;PRINT;ID;EOF]
