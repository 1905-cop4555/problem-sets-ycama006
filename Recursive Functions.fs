(*

OBJECTIVE: Practicing recursive functions with F#

*)



module RecursiveFunctions = 
   
              
    /// This example shows a recursive function that computes the factorial of an 
    /// integer. It uses 'let rec' to define a recursive function.
    let rec factorial n = 
        if n = 0 then 1 else n * factorial (n-1)

    printfn "Factorial of 6 is: %d\n" (factorial 6)




    /// Computes the greatest common factor of two integers.
    ///
    /// Since all of the recursive calls are tail calls,
    /// the compiler will turn the function into a loop,
    /// which improves performance and reduces memory consumption.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn "The Greatest Common Factor of 300 and 620 is %d\n" (greatestCommonFactor 300 620)




    /// This example computes the sum of a list of integers using recursion.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + (sumList ys)

    printfn "sumList: %d\n" ( sumList [1;2] )




    /// This makes 'sumList' tail recursive, using a helper function with a result accumulator.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys
                
    printfn "sumListTailRecHelper: %d" ( sumListTailRecHelper 0 [1;3] )
    printfn "sumListTailRecHelper: %d\n" ( sumListTailRecHelper 1 [1;3] )



    
    /// This invokes the tail recursive helper function, providing '0' as a seed accumulator.
    /// An approach like this is common in F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)





    /// Classic recursion for Fibonacci numbers, using function:
    
    let rec fib1 = function
        | 0    -> 0I
        | 1    -> 1I
        | n    -> fib1(n-1) + fib1(n-2)
    

    /// keyword: function is a shorthand
    /// Without using 'function', include the parameter and include
    /// the 'match' statement with the parameter
    /// 
    ///Calculating Fibonacci numbers, using match:
    let rec fib2 x =
        match x with
        | 0    -> 0I
        | 1    -> 1I
        | n    -> fib1(n-1) + fib1(n-2)






(*

    Recursive Functions

Processing collections or sequences of elements is typically done with recursion 
in F#. Although F# has support for loops and imperative programming, recursion is 
preferred because it is easier to guarantee correctness.

*)



//REFERENCE: https://docs.microsoft.com/en-us/dotnet/fsharp/tour
