(*

OBJECTIVE: Practicing tuples with F#

*)





module Tuples =

    /// A simple tuple of integers.
    let tuple1 = (1, 2, 3)
    printfn "tuple1: %A" tuple1
    /// A simple tuple of strings
    let tuple2 = ("a", "b", "c")
    printfn "tuple2: %A" tuple2
    /// A simple tuple of booleans
    let tuple3 = (true, false, true)
    printfn "tuple3: %A\n\n" tuple3


    /// A function that swaps the order of two values in a tuple. 
    ///
    /// F# Type Inference will automatically generalize the function to have a generic type,
    /// meaning that it will work with any type.
    let swapElems (a, b) = (b, a)
    printfn "The result of swapping (1, 2) is %A" ( swapElems (1,2) )
    printfn "The result of swapping (r, u) is %A" ( swapElems ("r","u") )
    printfn "The result of swapping (true, false) is %A\n\n" ( swapElems (true, false) )



    /// A tuple consisting of an integer, a string,
    /// and a double-precision floating point number.
    let tuple4 = (1, "fred", 3.1415)

    printfn "tuple1: %A \t tuple2: %A" tuple1 tuple4






module Struct_Tuples = 

    /// Tuples are normally objects, but they can also be represented as structs.
    ///
    /// These interoperate completely with structs in C# and Visual Basic.NET; however,
    /// struct tuples are not implicitly convertible with object tuples (often called reference tuples).
    ///
    /// The second line below will fail to compile because of this.  Uncomment it to see what happens.
    let sampleStructTuple = struct (1, 2)
    printfn "\n\n\nsampleStructTuple: %A" sampleStructTuple




    //let thisWillNotCompile: (int*int) = struct (1, 2)




    // Although you can
    let convertFromStructTuple ( struct(a, b) ) = (a, b)
    let aTuple = (sampleStructTuple |> convertFromStructTuple)
    printfn "convertFromStructTuple: %A" aTuple

    let convertToStructTuple (a,b) = struct(a, b)
    let sampleTuple = (1,2)
    let aStructTuple = ( sampleTuple |> convertToStructTuple) 
    printfn "convertToStructTuple: %A\n\n" aStructTuple





    printfn "Struct Tuple: %A \nReference tuple made from the Struct Tuple: %A" sampleStructTuple (sampleStructTuple |> convertFromStructTuple)







(*

    Tuples

Tuples are a big deal in F#. They are a grouping of unnamed, but ordered values,
where the tuples themselves can be treated as values themselves. Think of 
them as values which are aggregated from other values. 

They have many uses, such as conveniently returning multiple values from a function, 
or grouping values for some ad-hoc convenience.        

*)




(*

    Struct Tuples

It's important to note that because struct tuples are value types, they cannot be 
implicitly converted to reference tuples, or vice versa. You must explicitly 
convert between a reference and struct tuple.

*)




//REFERENCE: https://docs.microsoft.com/en-us/dotnet/fsharp/tour