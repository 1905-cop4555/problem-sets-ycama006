(* 

OBJECTIVE: Practicing arrays with F#

*)




module Arrays =


    /// This is The empty array.  Note that the syntax is similar to that of Lists, but uses `[| ... |]` instead.
    let array1 = [| |]
    printfn "array1: %A" array1



    /// Arrays are specified using the same range of constructs as lists.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]
    printfn "array2: %A" array2



    /// This is an array of numbers from 1 to 1000.
    let array3 = [| 1 .. 1000 |]
    printfn "\narray3: %A\n" array3



    /// This is an array containing only the words "hello" and "world".
    let array4 = 
        [| for word in array2 do
               if word.Contains("l") then 
                   yield word |]

    printfn "array4: %A" array4




    /// This is an array initialized by index and containing the even numbers from 0 to 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2) 
    printfn "\nevenNumbers: %A\n" evenNumbers

    
    /// Sub-arrays are extracted using slicing notation.
    let evenNumbersSlice = evenNumbers.[0..50]
    printfn "evenNumbersSlice: %A\n\n" evenNumbersSlice



    /// You can loop over arrays and lists using 'for' loops.
    for word in array4 do 
        printfn "word: %s" word



    // You can modify the contents of an array element by using the left arrow assignment operator.
    //
    // To learn more about this operator, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"
    printfn "\n\narray2: %A" array2



    /// You can transform arrays using 'Array.map' and other functional programming operations.
    /// The following calculates the sum of the lengths of the words that start with 'h'.
    let sumOfLengthsOfWords = 
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn "\nThe sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords






(*

Arrays

Arrays are fixed-size, mutable collections of elements of the same type. 
They support fast random access of elements, and are faster than F# lists 
because they are just contiguous blocks of memory.

*)



//REFERENCE: https://docs.microsoft.com/en-us/dotnet/fsharp/tour
   