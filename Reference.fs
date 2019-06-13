module ImperativeFSharp = 


    let factorial n =
        let ans = ref 1
        let cnt = ref 1
        while !cnt <= n do
          ans := !ans * !cnt;
          cnt := !cnt + 1
        !ans

    printfn "ImperativeFSharp: %d" (factorial 3)


//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------


module ImperativeOOPBankAccount = 


    type Account = 

        {

            deposit : int -> unit 
            balance : unit -> int

        }

    let account =
        let bal = ref 1000
        {

            deposit = fun d -> bal := !bal + d;
            balance = fun () -> !bal;

        }


    printfn "\n\nImperativeOOPBankAccount: %d" ( account.balance () )
    account.deposit 200 
    printfn "ImperativeOOPBankAccount: %d" ( account.balance () )



//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------


module ImperativeStack = 
    

    let mkstack init =
            let stk = ref init
            (    (fun x -> stk := x ::(!stk)), (fun () -> stk := List.tail(!stk)),  (fun () -> List.head (!stk))    )


    let (push, pop, top) = mkstack [] 



//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------




module InfinteStreams = 


    // An 'a stream thus has the form Cons(x, xsf), where x is a the head of the stream, 
    // and xsf is a function that can be called to give the tail of the stream.
    type 'a stream = 
        Cons of 'a * (unit -> 'a stream)



    // A stream consisting of the natural numbers 0, 1, 2, and so on
    let rec upfrom n = Cons( n, fun () -> upfrom(n+1))

    let nats = upfrom 1



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
          if p x then Cons(x, fun () -> filter p ( xsf () )  )
                 else filter p (xsf())

    


    printfn "\nInfiniteStreams: %A" (take 10 nats)
    printfn "%A" (drop 2 nats)
    printfn "%A" ( take 2 (filter (fun n -> n%2 = 0) nats) )


//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------


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
    printfn "Erastosthenes: %A" ( take 5 (drop 9 primes) )


//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------


module InfiniteSequences = 

    

    // The following example shows the use of Seq.initInfinite to create a sequence 1/n^2,  
    // with alternating signs.
    let seqInfinite = Seq.initInfinite (fun index -> 
        let n = float (index + 1) 
        1.0 / (n * n * (if ( (index + 1) % 2 = 0) then 1.0 
                        else - 1.0) ) )

    printfn "\n\nInfinite Sequences: %A" (seqInfinite)


//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------


(*


    * QUESTION 15 *

    An interesting use of first-class functions and ref cells in F# is to create a monitored version of a function.


    First, explain why F# does not allow the following declaration:
      let mrev = makeMonitoredFun List.rev


    Now suppose we rewrite the declaration using the technique of eta expansion:
      let mrev = fun x -> (makeMonitoredFun List.rev) x


    Does this solve the problem? Explain why or why not.

*)
module P3Question15 = 



    let makeMonitoredFun f =
          let c = ref 0
          (fun x -> c := !c+1; printf "Called %d times.\n" !c; f x )


    let msqrt = makeMonitoredFun sqrt 



    //let mrev = makeMonitoredFun List.rev
    let mrev = fun x -> (makeMonitoredFun List.rev) x

    //printfn "%f" (msqrt 16.0 + msqrt 25.0)
    printfn "P3Question15: %A" (mrev [])


    (*

        F# does now allow 'let mrev = makeMonitoredFun List.rev' because the expression 'makeMonitoredFun List.rev'
        is not in restricted form or syntactic value. 


        If it's not a syntactic value, then it cannot be given a polymorphic type, since F# can't tell what 
        type List.rev should be.
    *)

    (*

        The new declaration of the function rewritten as eta expansion solves the value restriction issue, 
        because F# knows that it's a polymorphic list by changing its type, giving it a syntactic value.
    *)

    // let msqrt = 
    //    let c = ref 0
    //    (fun 16.0 -> c := !c+1; printf "Called %d times.\n" !c; (sqrt 16.0) )


    // let msqrt = 
    //    let c = ref 0
    //    (fun 25.0 -> c := !c+1; printf "Called %d times.\n" !c; (sqrt 25.0) )





(*

    * QUESTION 11 *

    Write a non-recursive fibonacci function using imperative F#. Compare the timing with a tail-recursive fibonacci.

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


    (*

    Non-Tail Recursive

    let rec fib = function
        | n when n < 2 -> 1
        | n -> fib(n-1) + fib(n-2)
    *)

    // Tail Recursive
    let fib n =
        let rec tfib n1 n2 = function
        | 0 -> n1
        | n -> tfib n2 (n2 + n1) (n - 1)
        tfib 0 1 n  


    printfn "Tail Recursive: %d" (fib 5)




(*

    * QUESTION 12 *

    Using imperative F#, create a record type for a student. The record will have a function that returns 
    the student's GPA, a function that adds credit hours and a function that adds grade points. Initialize 
    an instance of the record with appropriate functions and values. Use the instance to add grade points 
    and credits several times, and display the GPA.
    

*)
module P3Question12 = 


    type Student = 

        {
            creditHours : float -> unit
            gradePoints : float -> float -> unit
            studentGPA : unit -> float
        }



    let student = 
        let totalCredits = ref 0.0
        let totalGradePoints = ref 0.0
        let gpa = ref 0.0
        {
            creditHours = fun credits -> totalCredits := !totalCredits + credits;
            gradePoints = fun points credits -> totalGradePoints := !totalGradePoints + (points * credits);
            studentGPA = fun () -> !totalGradePoints / !totalCredits;
        }


    student.creditHours 2.0
    student.gradePoints 4.0 2.0

    student.creditHours 2.0
    student.gradePoints 3.3 2.0


    student.creditHours 4.0
    student.gradePoints 4.0 4.0


    student.creditHours 1.0
    student.gradePoints 1.7 1.0

    student.creditHours 2.0
    student.gradePoints 3.0 2.0
   

    student.creditHours 1.0
    student.gradePoints 2.7 1.0

    student.creditHours 1.0
    student.gradePoints 4.0 1.0
   

    printfn "\n\n\nP3Question12: %f" ( student.studentGPA ())



 (*

    * QUESTION 13 *

    Using imperative F#, create a tuple for an integer stack, including push, pop, top and isEmpty functions. 
    Use the stack to implement factorial. Use a loop to push all the values from 1 through the parameter, 
    then use another loop to pop the values and calculate factorial. Compare the timing with a tail-recursive 
    factorial.   

 *)
module P3Question13 = 


    
      

    let mkstack init =
            let stk = ref init
            (    (fun x -> stk := x ::(!stk)), (fun () -> stk := List.tail(!stk)),  (fun () -> List.head (!stk))    )


    let (push, pop, top) = mkstack [] 


    let factorial n = 
        let factBase = ref 1
        let factNum = ref n
        let factResult = ref 1

        if n = 0 then push 1                
        else
            while !factBase <= !factNum do
                push !factNum
                factNum := !factNum - 1

            factNum := n
            while !factBase <= !factNum do
                factResult := ( top () ) * !factResult
                pop ()
                factNum := !factNum - 1


        !factResult
        


    printfn "\n\n\nP3Question13: %d" (factorial 3)


    (*

    //Non Tail Recursive
    let rec factorialRec n = function
        | 0 | 1 -> 1
        | _ -> n * factorialRec(n-1)

    *)
     
       
    //Tail Recursive
    let rec factorialTail n tail =
        match n with 
        | 0 | 1 -> tail
        | _ ->  factorialTail (n-1) (tail * n)


    printfn "Tail Recursive: %d" (factorialTail 8 1)


//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------


(*

    * QUESTION 10 *
    
    List the steps that F# follows to determine the type for f: (fun f -> f (f 17.3)).

*)
module P3Question10 = 

    (*
    let add1 x = x + 1
    let evalWith5ThenAdd2 fn = fn 5 + 2 
    printfn "%d" (evalWith5ThenAdd2 add1) 
    *)

    (*
    let bfunction x = x + 3
    let afunction f = f (f 2)
    printfn "\n\n%d\n\n" (afunction bfunction)
    *)
    

    printfn "\n\n\nP3Question10: %f" ( (fun f -> f (f 17.3)) (fun x -> x + 1.0;) )



    // f: (fun f -> f (f 17.3))



(*

    * QUESTION 14 *

    Refer to the lecture on types and the subset of the C language that was used. Perform a type derivation 
    to verify that the following code is well-typed.


*)
module P3Question14 = 



    // The following C code is well-typed, although there exists a semantic error



    //int *x;

    (*
            E(x) = int* var
            ------------------------- (ID)
            E |- x : int* var   
    *)


    //int a[15];

    (*
        E |- 15: int   E[a: int*] |- e2: void
        --------------------------------- (LETARR)
        E |- {int a[15]; e2} : void
    *)
   

    //*x = 7;

    (*
        E(x) = int* var
        ------------------------- (ID)
        E |- x : int* var
        -------------------------(R-VAL)
        E |- x: int*
        -------------------------(L-VAL) 
        E |- *x: int var                      E |- 7: int (LIT)
        -------------------------------------------------------- (ASSIGN)
        E |- *x = 7 : int 
    *)

    //a[*x] = *x + 4;

    (*



        E(x) = int* var                                 E(x) = int* var
        ------------------------- (ID)                  ------------------------- (ID)
        E |- x : int* var                               E |- x : int* var
        -------------------------(R-VAL)                -------------------------(R-VAL)
        E |- x: int*                                    E |- x: int*
        -------------------------(L-VAL)                -------------------------(L-VAL) 
        E |- *x: int var                                E |- *x: int var  
        -------------------------(R-VAL)                -------------------------(R-VAL)

        E |- *x: int                                    E |- *x: int              E |- 4 : int (LIT)  
        -------------------------                       ------------------------------------------------ (ADD)

        E |- a: int*    E |- *x: int 
        ------------------------------ (SUBSCRIPT)      
        E |- a[*x] : int var                                E |- *x + 4 : int
        --------------------------------------------------------------------------------------- (ASSIGN)
                                        E |- a[*x] =  *x + 4: int 


    *)




(*

    * QUESTION 18 *

*)
module P3Question18 = 


    // Declare type measures for seconds, microseconds, millseconds, and nanoseconds.

    [<Measure>] type seconds
    [<Measure>] type microseconds
    [<Measure>] type milliseconds
    [<Measure>] type nanoseconds

    // Declare constants for the number of seconds in each of the other types.

    let micro = 0.000001<seconds/microseconds>
    let milli = 0.001<seconds/milliseconds>
    let nano = 0.000000001<seconds/nanoseconds>

    // Create functions that convert seconds to each of the other types. What is the principal type of each function?
    
    let secondsToMicro sec = micro * sec            // float<'u> -> float<'u seconds/microseconds>

    let secondsToMilli sec = milli * sec            // float<'u> -> float<'u seconds/milliseconds>

    let secondsToNano sec = nano * sec              // float<'u> -> float<'u seconds/nanoseconds>

    // Create functions that convert each of the other types to seconds. What is the principal type of each function?

    let microsecondsToSec micros = micros / micro

    let millisecondsToSec ms = ms / milli

    let nanosecondsToSec ns = ns / nano

    // Convert 5000 milliseconds to seconds and then to microseconds.


//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------



(*

    * QUESTION 6 *

    Alternating series

    Generate an infinite sequence for the alternating series of 1/(2**n):
    1/2, -1/4, 1/8, -1/16, 1/32, -1/64, ...

    Display the 5th through 15th numbers in the series. The numbers should display as the floating point 
    version of the fractions.

    Repeat the exercise using an infinite stream.

*)


module P3Question6 = 

        

        let altSeriesA = Seq.initInfinite (fun index ->
            let powerNtimes = float (index + 1)
            let rec two = function
                |0.0 -> 1.0
                |powerNtimes -> 2.0 * two (powerNtimes-1.0)

            1.0 / (two powerNtimes) * (if ( (index + 2) % 2 = 0) then 1.0 else -1.0)
            )


        printfn "\n\nP3Question6A: %A" (altSeriesA)
        



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




        printfn "\nP3Question6C: %A" (take 15 altSeriesC)

        








        let altSeriesD = upfrom 5.0


        printfn "\nP3Question6D: %A\n\n\n" (take 11 altSeriesD)


//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------



(*
    * QUESTION 1 *
    
    Building a simple tree.
    a. Create a discriminated union that can represent a linked list of integers.
    b. Write a function that converts a list into a linked list of nodes.
*)
module P3Question1 = 


        type linkedList = 
            | Empty 
            | Cons of head:int * tail:linkedList

        let rec convert = function
            | [] -> Empty
            | x::xs -> Cons(head = x, tail = convert xs)

//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------

