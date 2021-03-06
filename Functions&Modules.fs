﻿(*

OBJECTIVE: Practing functions and modules with F#

*)




module BasicFunctions = 



    /// You use 'let' to define a function. This one accepts an integer argument and returns an integer. 
    /// Parentheses are optional for function arguments, except for when you use an explicit type annotation.
    let sampleFunction1 x = x*x + 3



    /// Apply the function, naming the function return result using 'let'. 
    /// The variable type is inferred from the function return type.
    let result1 = sampleFunction1 4573



    // This line uses '%d' to print the result as an integer. This is type-safe.
    // If 'result1' were not of type 'int', then the line would fail to compile.
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1




    /// When needed, annotate the type of a parameter name using '(argument:type)'.  Parentheses are required.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3
    let result2 = sampleFunction2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2




    /// Conditionals use if/then/elif/else.
    ///
    /// Note that F# uses white space indentation-aware syntax, similar to languages like Python.
    let sampleFunction3 x = 
        if x < 100.0 then 
            2.0*x*x - x/5.0 + 3.0
        else 
            2.0*x*x + x/5.0 - 37.0


    let result3 = sampleFunction3 (6.5 + 4.5)


    // This line uses '%f' to print the result as a float.  As with '%d' above, this is type-safe.
    printfn "The result of applying the 3rd sample function to (6.5 + 4.5) is %f" result3







module Immutability =


    
    /// Binding a value to a name via 'let' makes it immutable.
    ///
    /// The second line of code fails to compile because 'number' is immutable and bound.
    /// Re-defining 'number' to be a different value is not allowed in F#.
    let number = 2
    //let number = 3




    /// A mutable binding.  This is required to be able to mutate the value of 'otherNumber'.
    let mutable otherNumber = 2
    printfn "'otherNumber' is %d" otherNumber

    // When mutating a value, use '<-' to assign a new value.
    //
    // Note that '=' is not the same as this.  '=' is used to test equality.
    otherNumber <- otherNumber + 1
    printfn "'otherNumber' changed to be %d" otherNumber








(*

    Functions and Modules

The most fundamental pieces of any F# program are functions organized into modules. 
Functions perform work on inputs to produce outputs, and they are organized under 
Modules, which are the primary way you group things in F#. 

They are defined using the let binding, which give the function a name and define 
its arguments.


'let' bindings are also how you bind a value to a name, similar to a variable in other 
languages. let bindings are immutable by default, which means that once a value or 
function is bound to a name, it cannot be changed in-place. This is in contrast to 
variables in other languages, which are mutable, meaning their values can be changed 
at any point in time. If you require a mutable binding, you can use let mutable ... syntax.

*)



//REFERENCE: https://docs.microsoft.com/en-us/dotnet/fsharp/tour