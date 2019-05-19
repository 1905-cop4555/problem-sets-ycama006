(*

OBJECTIVE: Practing different data types with F#

*)





//NUMERIC TYPES

module IntegersAndNumbers = 

    /// This is a sample integer.
    let sampleInteger = 176
    printfn "sampleInteger: %d\n" sampleInteger


    /// This is a sample floating point number.
    let sampleDouble = 4.1
    printfn "sampleDouble: %f\n" sampleDouble 



    /// This computed a new number by some arithmetic.  Numeric types are converted using
    /// functions 'int', 'double' and so on.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    let testConvert = int 5.5
    printfn "Testing Integer Conversion: %d\n" testConvert



    /// This is a list of the numbers from 0 to 99.
    let sampleNumbers = [ 0 .. 99 ]
    printfn "sampleList: %A\n" sampleNumbers


    /// This is a list of all tuples containing all the numbers from 0 to 99 and their squares.
    ///prints a list that includes tuples, using '%A' for generic printing.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]
    printfn "sampleTableofSquares: %A\n\n" sampleTableOfSquares






//BOOLEAN TYPE

module Booleans =

    /// Booleans values are 'true' and 'false'.
    let boolean1 = true
    printfn "boolean1: %b" boolean1
    let boolean2 = false
    printfn "boolean2: %b" boolean2



    /// Operators on booleans are 'not', '&&' and '||'.
    let boolean3 = not boolean1 && (boolean2 || false)

    // This line uses '%b'to print a boolean value.  This is type-safe.
    printfn "The expression 'not boolean1 && (boolean2 || false)' is: %b\n\n\n" boolean3


    



//STRING TYPE

module StringManipulation = 

    /// Strings use double quotes.
    let string1 = "Hello"
    printfn "string1: %s" string1
    let string2  = "world"
    printfn "string2: %s" string2



    /// Strings can also use @ to create a verbatim string literal.
    /// This will ignore escape characters such as '\', '\n', '\t', etc.
    let string3 = @"C:\Program Files\"
    printfn "string3: %s" string3



    /// String literals can also use triple-quotes.
    let string4 = """The computer said "hello world" when I told it to!"""
    printfn "string4: %s" string4




    /// String concatenation is normally done with the '+' operator.
    let string5 = string1 + " " + string2 
 
    // This line uses '%s' to print a string value.  This is type-safe.
    printfn "string5: %s" string5




    /// Substrings use the indexer notation.  This line extracts the first 7 characters as a substring.
    /// Note that like many languages, Strings are zero-indexed in F#.
    let substring = string5.[0..6]
    printfn "substring of string5: %s" substring








// REFERENCE: https://docs.microsoft.com/en-us/dotnet/fsharp/tour