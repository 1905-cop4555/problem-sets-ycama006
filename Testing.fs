(*

OBJECTIVE: Create first F# program using Visual Studio for Mac, 
and testing F# Interactive.

*)



module HelloSquare

let square x = x * x


[<EntryPoint>]
//FUNCTION
let main argv =
    printfn "%d squared is: %d!" 12 (square 12)
    0 // Return an integer exit code



(* 

In this code sample, a function square has been defined which 
takes an input named x and multiplies it by itself. 

Because F# uses Type Inference, the type of x doesn't need to 
be specified. The F# compiler understands the types where 
multiplication is valid, and will assign a type to x based on 
how square is called. 

If you hover over square, you should see the following: 
val square: x:int -> int

*)




(* 

    val square: x:int -> int

This is what is known as the function's type signature. It can be read 
like this: "Square is a function which takes an integer named x and 
produces an integer".

Note that the compiler gave square the int type for now - this is because 
multiplication is not generic across all types, but rather is generic 
across a closed set of types. The F# compiler picked int at this point,
but it will adjust the type signature if you call square with a different 
input type, such as a float.

*) 





(* 

Another function, main, is defined, which is decorated with the EntryPoint 
attribute to tell the F# compiler that program execution should start there. 
It follows the same convention as other C-style programming languages, where 
command-line arguments can be passed to this function, and an integer code 
is returned (typically 0).

Another function, main, is defined, which is decorated with the EntryPoint 
attribute to tell the F# compiler that program execution should start there. 
It follows the same convention as other C-style programming languages, where 
command-line arguments can be passed to this function, and an integer code is 
returned (typically 0).


It is in this function that we call the square function with an argument of 12. 
The F# compiler then assigns the type of square to be int -> int (that is, a 
function which takes an int and produces an int). The call to printfn is a 
formatted printing function which uses a format string, similar to C-style 
programming languages, parameters which correspond to those specified in the 
format string, and then prints the result and a new line.

*)




(*

    F# Interactive


> square 12;;
val it : int = 144


This shows the same function signature for the square function, which you 
saw earlier when you hovered over the function. Because square is now defined 
in the F# Interactive process, you can call it with different values.

This executes the function, binds the result to a new name it, and displays 
the type and value of it. This is how F# Interactive knows when your function 
call is finished. 

*)


// REFERENCE: https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-with-visual-studio-for-mac